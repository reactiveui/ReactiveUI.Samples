using System;

namespace TestApp.DataModels
{
    public class ListItemDataModel : IEquatable<ListItemDataModel>
    {
        public string Name { get; set; }
        public int Group { get; set; }
        public int Order { get; set; }

        public bool Equals(ListItemDataModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && Group == other.Group && Order == other.Order;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ListItemDataModel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Group;
                hashCode = (hashCode * 397) ^ Order;
                return hashCode;
            }
        }

        public static bool operator ==(ListItemDataModel left, ListItemDataModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ListItemDataModel left, ListItemDataModel right)
        {
            return !Equals(left, right);
        }
    }
}