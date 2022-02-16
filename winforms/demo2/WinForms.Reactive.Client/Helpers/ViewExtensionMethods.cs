using ReactiveUI;
using Splat;

namespace WinForms.Reactive.Client.Helpers;

public static class ViewExtensionMethods
{
	public static Form GetView<T>(this T viewModel) where T : ReactiveObject
	{
		var view = Splat.Locator.Current.GetService<IViewFor<T>>();
		if (view== null)
		{
			throw new TypeAccessException($"View {viewModel.GetType().Name} is not registered in DI.");
		}

		view.ViewModel = viewModel;

		var form = view as Form;
		if (form == null)
		{
			throw new TypeAccessException($"View {viewModel.GetType().Name} does not implement IViewFor.");
		}

		return form;
	}
}
