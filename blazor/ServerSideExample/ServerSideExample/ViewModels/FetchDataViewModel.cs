using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ServerSideExample.Data;

namespace ServerSideExample.ViewModels
{
    public class FetchDataViewModel : ReactiveObject
    {
        private readonly WeatherForecastService _weatherForecastService;

        public FetchDataViewModel(WeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
            LoadForecasts = ReactiveCommand.CreateFromTask(LoadWeatherForecastsAsync);
        }

        public ReactiveCommand<Unit, Unit>  LoadForecasts { get; }

        public List<WeatherForecast> Forecasts { get; set; } = new List<WeatherForecast>();

        private async Task LoadWeatherForecastsAsync()
        {
            Forecasts =  (await _weatherForecastService.GetForecastAsync(DateTime.Now)).ToList();
        }

    }
}
