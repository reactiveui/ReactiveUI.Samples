using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.ComposeTweet;
using Microsoft.Reactive.Testing;
using ReactiveUI.Testing;
using Shouldly;
using Xunit;

namespace Tests.Features
{
    public class ComposeTweetViewModelTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void CannotSendTweetIfMessageIsBlank(string message)
        {
            var sut = new ComposeTweetViewModelBuilder()
                .WithMessage(message)
                .Build();

            var canSend = sut.Send.CanExecute.FirstAsync().Wait();
            canSend.ShouldBe(false);
        }

        [Theory]
        [InlineData("hello world")]
        public void CanSendTweetIfMessageIsNotBlank(string message)
        {
            var sut = new ComposeTweetViewModelBuilder()
                .WithMessage(message)
                .Build();

            var canSend = sut.Send.CanExecute.FirstAsync().Wait();
            canSend.ShouldBe(true);
        }

        [Theory]
        [InlineData("hello world", 229)]
        public void AmountOfCharactersRemainingIsAsExpected(string message, int charactersRemaining)
        {
            var sut = new ComposeTweetViewModelBuilder()
                .WithMessage(message)
                .Build();

            sut.CharactersRemaining.ShouldBe(charactersRemaining);
        }
    }
}
