using System.Collections.Generic;
using System.Net.Http;
using System.Reactive;
using System.Threading.Tasks;
using ClientSideExample.Data;
using Microsoft.AspNetCore.Components;
using ReactiveUI;


namespace ClientSideExample.ViewModels
{
    public class FetchDataViewModel : ReactiveObject
    {
        private List<WeatherForecast> _forecasts = new List<WeatherForecast>();
        private readonly HttpClient _http;
        public FetchDataViewModel(HttpClient http)
        {
            _http = http;
            LoadForecasts = ReactiveCommand.CreateFromTask(LoadWeatherForecastsAsync);
        }

        public ReactiveCommand<Unit, Unit> LoadForecasts { get; }

        public List<WeatherForecast> Forecasts
        { 
            get => _forecasts; 
            set => this.RaiseAndSetIfChanged(ref _forecasts, value);
            
        }

        private async Task LoadWeatherForecastsAsync()
        {
            Forecasts.AddRange(await _http.GetJsonAsync<WeatherForecast[]>("sample-data/weather.json"));
        }

    }
}
