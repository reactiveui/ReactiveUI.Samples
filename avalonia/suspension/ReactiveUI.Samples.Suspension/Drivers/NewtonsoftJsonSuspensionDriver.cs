using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.IO;
using System.Reactive.Concurrency;
using Newtonsoft.Json;

namespace ReactiveUI.Samples.Suspension.Drivers
{
    public sealed class NewtonsoftJsonSuspensionDriver : ISuspensionDriver
    {
        private readonly string _stateFilePath;
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public NewtonsoftJsonSuspensionDriver(string stateFilePath) => _stateFilePath = stateFilePath;

        public IObservable<Unit> InvalidateState()
        {
            if (File.Exists(_stateFilePath)) 
                File.Delete(_stateFilePath);
            return Observable.Return(Unit.Default);
        }

        public IObservable<object> LoadState()
        {
            var lines = File.ReadAllText(_stateFilePath);
            var state = JsonConvert.DeserializeObject<object>(lines, _settings);
            return Observable.Return(state);
        }

        public IObservable<Unit> SaveState(object state)
        {
            var lines = JsonConvert.SerializeObject(state, Formatting.Indented, _settings);
            File.WriteAllText(_stateFilePath, lines);
            return Observable.Return(Unit.Default);
        }
    }
}