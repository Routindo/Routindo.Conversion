using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routindo.Contract.Arguments;
using Routindo.Contract.Services;
using Routindo.Plugins.Conversion.Components.Actions;
using Routindo.Plugins.Conversion.Components.Actions.@base;

namespace Routindo.Plugins.Conversion.Tests
{
    [TestClass]
    public class ItemByIndexFromCollectionTests
    {
        [TestMethod]
        [TestCategory("Unit Test")]
        public void GetItemByIndexFromListTest()
        {
            List<string> list = new List<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");
            list.Add("last");

            ItemByIndexFromCollectionAction action = new ItemByIndexFromCollectionAction()
            {
                LoggingService =
                    ServicesContainer.ServicesProvider.GetLoggingService(nameof(FirstItemFromCollectionAction))
            };

            #region Index = 0 
            action.Index = 0;
            var actionResults = action.Execute(ArgumentCollection.New()
                .WithArgument(ItemFromCollectionConverterExecutionArgs.Collection, list));
            Assert.IsNotNull(actionResults);
            Assert.IsTrue(actionResults.Result);
            Assert.IsNotNull(actionResults.AdditionalInformation);
            Assert.IsTrue(actionResults.AdditionalInformation.HasArgument(ItemFromCollectionConverterResultsArgs.Item));
            var item = actionResults.AdditionalInformation.GetValue<string>(ItemFromCollectionConverterResultsArgs
                .Item);
            Assert.AreEqual("first", item);
            #endregion

            #region index = 1
            action.Index = 1;
            actionResults = action.Execute(ArgumentCollection.New()
                .WithArgument(ItemFromCollectionConverterExecutionArgs.Collection, list));
            Assert.IsNotNull(actionResults);
            Assert.IsTrue(actionResults.Result);
            Assert.IsNotNull(actionResults.AdditionalInformation);
            Assert.IsTrue(actionResults.AdditionalInformation.HasArgument(ItemFromCollectionConverterResultsArgs.Item));
            item = actionResults.AdditionalInformation.GetValue<string>(ItemFromCollectionConverterResultsArgs
                .Item);
            Assert.AreEqual("second", item);
            #endregion

            #region index = 2

            action.Index = 2;
            actionResults = action.Execute(ArgumentCollection.New()
                .WithArgument(ItemFromCollectionConverterExecutionArgs.Collection, list));
            Assert.IsNotNull(actionResults);
            Assert.IsTrue(actionResults.Result);
            Assert.IsNotNull(actionResults.AdditionalInformation);
            Assert.IsTrue(actionResults.AdditionalInformation.HasArgument(ItemFromCollectionConverterResultsArgs.Item));
            item = actionResults.AdditionalInformation.GetValue<string>(ItemFromCollectionConverterResultsArgs
                .Item);
            Assert.AreEqual("third", item);
            #endregion

            #region index=3
            action.Index = 3;
            actionResults = action.Execute(ArgumentCollection.New()
                .WithArgument(ItemFromCollectionConverterExecutionArgs.Collection, list));
            Assert.IsNotNull(actionResults);
            Assert.IsTrue(actionResults.Result);
            Assert.IsNotNull(actionResults.AdditionalInformation);
            Assert.IsTrue(actionResults.AdditionalInformation.HasArgument(ItemFromCollectionConverterResultsArgs.Item));
            item = actionResults.AdditionalInformation.GetValue<string>(ItemFromCollectionConverterResultsArgs
                .Item);
            Assert.AreEqual("last", item);
            #endregion 
        }
    }
}
