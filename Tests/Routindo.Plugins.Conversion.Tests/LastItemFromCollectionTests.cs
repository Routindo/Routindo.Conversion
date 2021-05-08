using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routindo.Contract.Arguments;
using Routindo.Contract.Services;
using Routindo.Plugins.Conversion.Components.Actions;
using Routindo.Plugins.Conversion.Components.Actions.@base;

namespace Routindo.Plugins.Conversion.Tests
{
    [TestClass]
    public class LastItemFromCollectionTests
    {
        [TestMethod]
        [TestCategory("Unit Test")]
        public void GetLastItemFromListTest()
        {
            List<string> list = new List<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");
            list.Add("last");
            LastItemFromCollectionAction action = new LastItemFromCollectionAction()
            {
                LoggingService =
                    ServicesContainer.ServicesProvider.GetLoggingService(nameof(LastItemFromCollectionAction))
            };
            var actionResults = action.Execute(ArgumentCollection.New()
                .WithArgument(ItemFromCollectionConverterExecutionArgs.Collection, list));
            Assert.IsNotNull(actionResults);
            Assert.IsTrue(actionResults.Result);
            Assert.IsNotNull(actionResults.AdditionalInformation);
            Assert.IsTrue(actionResults.AdditionalInformation.HasArgument(ItemFromCollectionConverterResultsArgs.Item));
            var item = actionResults.AdditionalInformation.GetValue<string>(ItemFromCollectionConverterResultsArgs
                .Item);
            Assert.AreEqual("last", item);
        }
    }
}
