using System;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ServerSideExample.Data;

namespace ServerSideExample.ViewModels
{
    public class FetchDataViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<WeatherForecast[]> _forecasts;
        private readonly WeatherForecastService _weatherForecastService;

        public FetchDataViewModel(WeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
            LoadForecasts = ReactiveCommand.CreateFromTask(LoadWeatherForecastsAsync);

            _forecasts = LoadForecasts.ToProperty(this, x => x.Forecasts, scheduler: RxApp.MainThreadScheduler);
        }

        public ReactiveCommand<Unit, WeatherForecast[]> LoadForecasts { get; }

        public WeatherForecast[] Forecasts => _forecasts.Value;

        private async Task<WeatherForecast[]> LoadWeatherForecastsAsync()
        {
            return await _weatherForecastService.GetForecastAsync(DateTime.Now);
        }

    }
}
