using System.Collections;

namespace WinForms.Reactive.Client.Helpers;

public static class ListExtensionMethods
{
	/// <summary>
	/// Find the first element that matches the expression. IList is implemented by many collection objects, like ObjectCollection.
	/// </summary>
	public static int IndexOf<T>(this IList collection, Func<(T value, int index), bool> expression)
	{
		var index =
			collection
				.OfType<T>()
				.Select((value, index) => (value, index))
				.FirstOrDefault(item =>
				{
					var x = expression(item);
					return x;
				})
				.index;
		return index;
	}
}
