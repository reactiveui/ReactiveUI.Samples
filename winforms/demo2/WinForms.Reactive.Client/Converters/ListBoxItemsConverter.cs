//using System.Collections;
//using ReactiveUI;

//namespace NordSoft.Reactive.Client.Converters;

//public class ListBoxItemsConverter : IBindingTypeConverter
//{
//	public int GetAffinityForObjects(Type fromType, Type toType)
//	{
//		if (toType != typeof(ListBox.ObjectCollection))
//		{
//			return 0;
//		}

//		if (fromType.GetInterface("IEnumerable") == null)
//		{
//			return 0;
//		}

//		return 10;
//	}

//	public bool TryConvert(object? @from, Type toType, object? conversionHint, out object? result)
//	{
//		var enumerable = (IEnumerable)from;

//		if (enumerable == null)
//		{
//			result = null;
//			return false;
//		}

//		var list = new List<string>();

//		foreach (var item in enumerable)
//		{
//			var s = item.ToString();
//			list.Add(s);
//		}
//		result = list;
//		return true;
//	}
//}
