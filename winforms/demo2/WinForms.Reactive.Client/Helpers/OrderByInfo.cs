namespace WinForms.Reactive.Client.Helpers;

public class OrderByInfo<T> where T:Enum
{
	public T Id { get; set; } = default;
	public string Name { get; set; } = string.Empty;
}
