using System.Diagnostics;
using System.Reactive.Concurrency;
using ReactiveUI;

namespace WinForms.Reactive.Client.Helpers;

public class CustomObservableExceptionHandler : IObserver<Exception>
{
	public void OnNext(Exception value)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}

		//Analytics.Current.TrackEvent("MyRxHandler", new Dictionary<string, string>()
		//{
		//	{"Type", value.GetType().ToString()},
		//	{"Message", value.Message},
		//});

		RxApp.MainThreadScheduler.Schedule(() => { throw value; });
	}

	public void OnError(Exception error)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}

		//Analytics.Current.TrackEvent("MyRxHandler Error", new Dictionary<string, string>()
		//{
		//	{"Type", error.GetType().ToString()},
		//	{"Message", error.Message},
		//});

		RxApp.MainThreadScheduler.Schedule(() =>
		{
			throw error;
		});
	}

	public void OnCompleted()
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}

		RxApp.MainThreadScheduler.Schedule(() =>
		{
			throw new NotImplementedException();
		});
	}
}
