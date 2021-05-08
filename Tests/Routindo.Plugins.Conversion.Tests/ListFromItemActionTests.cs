using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routindo.Contract.Arguments;
using Routindo.Contract.Services;
using Routindo.Plugins.Conversion.Components.Actions;

namespace Routindo.Plugins.Conversion.Tests
{
    [TestClass]
    public class ListFromItemActionTests
    {
        [TestMethod]
        [TestCategory("Unit Test")]
        public void GetListFromItemTest()
        {
            ListFromItemAction action = new ListFromItemAction()
            {
                LoggingService = ServicesContainer.ServicesProvider.GetLoggingService(nameof(ListFromItemAction))
            };

            var item = "sample string item";
            var actionResults = action.Execute(ArgumentCollection.New().WithArgument(ListFromItemActionExecutionArgs.Item, item));
            Assert.IsNotNull(actionResults);
            Assert.IsTrue(actionResults.Result);
            Assert.IsNotNull(actionResults.AdditionalInformation);
            Assert.IsTrue(actionResults.AdditionalInformation.HasArgument(ListFromItemActionResultsArgs.Collection));

            var collectionValue = actionResults.AdditionalInformation[ListFromItemActionResultsArgs.Collection];
            Assert.IsNotNull(collectionValue);
            var collection = collectionValue as List<string>;
            Assert.IsNotNull(collection);

            var innerItem = collection.SingleOrDefault();
            Assert.IsNotNull(innerItem);
            Assert.AreEqual(item, innerItem);
        }
    }
}
