using System.Net.Http;
using System.Reactive;
using System.Threading.Tasks;
using HostedExample.Shared;
using Microsoft.AspNetCore.Components;
using ReactiveUI;

namespace HostedExample.Client.ViewModels
{
    public class FetchDataViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<WeatherForecast[]> _forecasts;

        private readonly HttpClient _http;
        public FetchDataViewModel(HttpClient http)
        {
            _http = http;
            LoadForecasts = ReactiveCommand.CreateFromTask(LoadWeatherForecastsAsync);

            _forecasts = LoadForecasts.ToProperty(this, x => x.Forecasts, scheduler: RxApp.MainThreadScheduler);
        }

        public ReactiveCommand<Unit, WeatherForecast[]> LoadForecasts { get; }

        public WeatherForecast[] Forecasts => _forecasts.Value;

        private async Task<WeatherForecast[]> LoadWeatherForecastsAsync()
        {
            return await _http.GetJsonAsync<WeatherForecast[]>("WeatherForecast");
        }

    }
}
