using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using Features.ComposeTweet;
using ReactiveUI;
using UnitTests;

namespace Tests.Features
{
    public sealed class ComposeTweetViewModelBuilder : IBuilder
    {
        private string _message;
        private IScheduler _scheduler;

        public ComposeTweetViewModelBuilder()
        {
            _scheduler = CurrentThreadScheduler.Instance;
        }

        public ComposeTweetViewModelBuilder WithMessage(string message) => this.With(ref _message, message);

        public ComposeTweetViewModelBuilder WithScheduler(IScheduler scheduler) => this.With(ref _scheduler, scheduler);

        public ComposeTweetViewModel Build()
        {
            var result = new ComposeTweetViewModel(_scheduler)
            {
                Message = _message
            };

            return result;
        }

        public static implicit operator ComposeTweetViewModel(ComposeTweetViewModelBuilder builder) =>
            builder.Build();
    }
}
