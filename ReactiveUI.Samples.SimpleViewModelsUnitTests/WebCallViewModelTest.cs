using Microsoft.Reactive.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReactiveUI.Samples.SimpleViewModels;
using ReactiveUI.Testing;
using System.Reactive.Linq;

namespace ReactiveUI.Samples.SimpleViewModelsUnitTests
{
    [TestClass]
    public class WebCallViewModelTest
    {
        /// <summary>
        /// Make sure no webservice call is send off until 800 ms have passed.
        /// </summary>
        [TestMethod]
        public void TestNothingTill800ms()
        {
            // Run a test scheduler to put time under our control.
            new TestScheduler().With(s =>
            {
                var fixture = new WebCallViewModel(new immediateWebService());
                fixture.InputText = "hi";

                // Run the clock forward to 800 ms. At that point, nothing should have happened.
                s.AdvanceToMs(799);
                Assert.AreEqual("", fixture.ResultText, "Result at 799");

                // Run the clock 1 tick past and the result should show up.
                s.AdvanceToMs(801);
                Assert.AreEqual("result hi", fixture.ResultText, "Result at 800");
            });
        }

        /// <summary>
        /// User types something, pauses, then types something again.
        /// </summary>
        [TestMethod]
        public void TestDelayAfterUpdate()
        {
            // Run a test scheduler to put time under our control.
            new TestScheduler().With(s =>
            {
                var fixture = new WebCallViewModel(new immediateWebService());
                fixture.InputText = "hi";

                // Run the clock forward 300 ms, where they type again.
                s.AdvanceToMs(300);
                fixture.InputText = "there";

                // Now, at 801, there should be nothing!
                s.AdvanceToMs(801);
                Assert.AreEqual("", fixture.ResultText, "result text at 801");

                // But, at 800+300+1, our result shoudl appear!
                s.AdvanceToMs(800 + 300 + 1);
                Assert.AreEqual("result there", fixture.ResultText, "result text at 1101");
            });
        }

        /// <summary>
        /// This dummy webservice takes zero time.
        /// </summary>
        class immediateWebService : IWebCaller
        {
            public System.IObservable<string> GetResult(string searchItems)
            {
                return Observable.Return("result " + searchItems);
            }
        }

    }
}
