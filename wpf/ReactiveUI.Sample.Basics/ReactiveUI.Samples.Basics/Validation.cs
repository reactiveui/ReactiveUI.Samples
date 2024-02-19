using Splat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Subjects;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Samples.Basics
{
    // XXX: Validation was removed in 5.0 but will return later
    // https://groups.google.com/forum/#!topic/reactivexaml/hlR3ajiXaFs
    [DataContract]
    public class ReactiveValidatedObject : ReactiveObject, IDataErrorInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReactiveValidatedObject"/> class.
        /// </summary>
        public ReactiveValidatedObject()
        {
            this.Changing.Subscribe(x =>
            {
                if (x.Sender != this)
                {
                    return;
                }

                if (_validationCache.ContainsKey(x.PropertyName))
                {
                    _validationCache.Remove(x.PropertyName);
                }
            });

            _validatedPropertyCount = new Lazy<int>(() =>
            {
                lock (allValidatedProperties)
                {
                    return allValidatedProperties.Get(this.GetType()).Count;
                }
            });
        }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        [IgnoreDataMember]
        public string Error
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the <see cref="string"/> with the specified column name.
        /// </summary>
        /// <value>
        /// The <see cref="string"/>.
        /// </value>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        [IgnoreDataMember]
        public string this[string columnName]
        {
            get
            {
                string ret;
                if (_validationCache.TryGetValue(columnName, out ret))
                {
                    return ret;
                }

                this.Log().Debug("Checking {0:X}.{1}...", this.GetHashCode(), columnName);
                ret = getPropertyValidationError(columnName);
                this.Log().Debug("Validation result: {0}", ret);

                _validationCache[columnName] = ret;

                Expression<Func<ReactiveValidatedObject, string>> expression = x => x.Error;

                _ValidationObservable
                    .OnNext(
                        new ObservedChange<object, bool>(this, expression.Body, ret != null));

                return ret;
            }
        }

        /// <summary>
        /// Determines whether [is object valid].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is object valid]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsObjectValid()
        {
            if (_validationCache.Count == _validatedPropertyCount.Value)
            {
                //return _validationCache.Values.All(x => x == null);
                foreach (var v in _validationCache.Values)
                {
                    if (v != null)
                    {
                        return false;
                    }
                }
                return true;
            }

            IEnumerable<string> allProps;
            lock (allValidatedProperties)
            {
                allProps = allValidatedProperties.Get(GetType()).Keys;
            };

            //return allProps.All(x => this[x] == null);
            foreach (var v in allProps)
            {
                if (this[v] != null)
                {
                    return false;
                }
            }
            return true;
        }

        protected void InvalidateValidationCache()
        {
            _validationCache.Clear();
        }

        [IgnoreDataMember]
        private readonly Subject<IObservedChange<object, bool>> _ValidationObservable = new Subject<IObservedChange<object, bool>>();

        [IgnoreDataMember]
        public IObservable<IObservedChange<object, bool>> ValidationObservable
        {
            get { return _ValidationObservable; }
        }

        [IgnoreDataMember]
        private readonly Lazy<int> _validatedPropertyCount;

        [IgnoreDataMember]
        private readonly Dictionary<string, string> _validationCache = new Dictionary<string, string>();

        private static readonly MemoizingMRUCache<Type, Dictionary<string, PropertyExtraInfo>> allValidatedProperties =
            new MemoizingMRUCache<Type, Dictionary<string, PropertyExtraInfo>>((x, _) =>
                PropertyExtraInfo.CreateFromType(x).ToDictionary(k => k.PropertyName, v => v),
                5);

        private string getPropertyValidationError(string propName)
        {
            PropertyExtraInfo pei;

            lock (allValidatedProperties)
            {
                if (!allValidatedProperties.Get(this.GetType()).TryGetValue(propName, out pei))
                {
                    return null;
                }
            }

            foreach (var v in pei.ValidationAttributes)
            {
                try
                {
                    var ctx = new ValidationContext(this, null, null) { MemberName = propName };
                    var getter = Reflection.GetValueFetcherForProperty(pei.Type.GetProperty(propName));
                    v.Validate(getter(this, new object[] { }), ctx);
                }
                catch (Exception ex)
                {
                    this.Log().Info("{0:X}.{1} failed validation: {2}",
                        this.GetHashCode(), propName, ex.Message);
                    return ex.Message;
                }
            }

            return null;
        }
    }

    internal class PropertyExtraInfo : IComparable
    {
        private string _typeFullName;
        private Type _Type;

        public Type Type
        {
            get { return _Type; }
            set { _Type = value; _typeFullName = value.FullName; }
        }

        public string PropertyName { get; set; }
        public ValidationAttribute[] ValidationAttributes { get; set; }

        public static PropertyExtraInfo CreateFromTypeAndName(Type type, string propertyName, bool nullOnEmptyValidationAttrs = false)
        {
            object[] attrs;
            var pi = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance);

            if (pi == null)
            {
                throw new ArgumentException("Property not found on type");
            }

            attrs = pi.GetCustomAttributes(typeof(ValidationAttribute), true) ?? new ValidationAttribute[0];
            if (nullOnEmptyValidationAttrs && attrs.Length == 0)
            {
                return null;
            }

            return new PropertyExtraInfo()
            {
                Type = type,
                PropertyName = propertyName,
                ValidationAttributes = attrs.Cast<ValidationAttribute>().ToArray(),
            };
        }

        public static PropertyExtraInfo[] CreateFromType(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(x => CreateFromTypeAndName(type, x.Name, true))
                .Where(x => x != null)
                .ToArray();
        }

        public int CompareTo(object obj)
        {
            var rhs = obj as PropertyExtraInfo;
            if (rhs == null)
            {
                throw new ArgumentException();
            }

            int ret = 0;
            if ((ret = this._typeFullName.CompareTo(rhs._typeFullName)) != 0)
            {
                return ret;
            }

            return this.PropertyName.CompareTo(rhs.PropertyName);
        }
    }

    /// <summary>
    /// Validation Base.
    /// </summary>
    public abstract class ValidationBase : ValidationAttribute
    {
        public bool AllowNull = false;
        public bool AllowBlanks = true;

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ret = base.IsValid(value, validationContext);
            if (ret == null || ret.ErrorMessage == null)
                return null;
            return getStandardMessage(validationContext);
        }

        /// <summary>
        /// Determines whether [is valid via null or blank] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is valid via null or blank] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        protected bool isValidViaNullOrBlank(object value)
        {
            if (value == null && !AllowNull)
                return false;

            string s = value as string;
            return !(s != null && !AllowBlanks && string.IsNullOrWhiteSpace(s));
        }

        /// <summary>
        /// Determines whether [is valid via null or blank] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ctx">The CTX.</param>
        /// <returns></returns>
        protected ValidationResult isValidViaNullOrBlank(object value, ValidationContext ctx)
        {
            if (isValidViaNullOrBlank(value))
                return null;

            return new ValidationResult(string.Format("{0} is blank",
                ctx.DisplayName ?? "The value"));
        }

        /// <summary>
        /// Gets the standard message.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        /// <returns></returns>
        protected virtual ValidationResult getStandardMessage(ValidationContext ctx)
        {
            return new ValidationResult(ErrorMessage ??
                string.Format("{0} is incorrect", ctx.DisplayName ?? "The value"));
        }
    }

    /// <summary>
    /// Validates Via Method Attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ValidatesViaMethodAttribute : ValidationBase
    {
        /// <summary>
        /// The name
        /// </summary>
        public string Name;

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var is_blank = isValidViaNullOrBlank(value, validationContext);
            if (is_blank != null)
                return is_blank;

            string func = Name ?? string.Format("Is{0}Valid", validationContext.MemberName);
            var mi = validationContext.ObjectType.GetMethod(func, BindingFlags.Public | BindingFlags.Instance);
            bool result = (bool)mi.Invoke(validationContext.ObjectInstance, new[] { value });

            return result ? null : getStandardMessage(validationContext);
        }
    }
}
