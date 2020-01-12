﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace HostedExample.Client.ViewModels
{
    public class GreetingViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, Unit> Clear { get; }

        [ObservableAsProperty]
        public bool CanClear { get; }

        [ObservableAsProperty]
        public string Greeting { get; }

        [Reactive]
        public string Name { get; set; } = string.Empty;

        public GreetingViewModel()
        {
            var canClear = this
                .WhenAnyValue(x => x.Name)
                .Select(name => !string.IsNullOrWhiteSpace(name));

            Clear = ReactiveCommand.Create(
                () => { Name = string.Empty; },
                canClear);

            Clear.CanExecute
                .ToPropertyEx(this, x => x.CanClear);

            this.WhenAnyValue(x => x.Name)
                .Select(x => string.IsNullOrWhiteSpace(x) ? string.Empty : $"Hello, {x}!")
                .ToPropertyEx(this, x => x.Greeting);
        }
    }
}
