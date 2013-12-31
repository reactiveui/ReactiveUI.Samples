using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReactiveUI.Samples.SimpleViewModels;

namespace ReactiveUI.Samples.SimpleViewModelsUnitTests
{
    /// <summary>
    /// A few sample unit tests. Note how simple they are: since the concept of time
    /// is not involved we do not have to model it in our unit tests. We test these almost
    /// as if they were a non ReactiveUI object.
    /// </summary>
    [TestClass]
    public class CalculatorViewModelTest
    {
        [TestMethod]
        public void TestTypingStringGetsError()
        {
            var fixture = new CalculatorViewModel();
            fixture.InputText = "hi";
            Assert.AreEqual("Error", fixture.ErrorText, "ErrorText");
            Assert.AreEqual("", fixture.ResultText, "ResultText");
        }

        [TestMethod]
        public void TestTypingInteger()
        {
            var fixture = new CalculatorViewModel();
            fixture.InputText = "50";
            Assert.AreEqual("", fixture.ErrorText, "ErrorText");
            Assert.AreEqual("100", fixture.ResultText, "ResultText");
        }
    }
}
