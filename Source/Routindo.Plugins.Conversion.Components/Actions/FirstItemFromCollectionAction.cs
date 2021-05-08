using System.Collections.Generic;
using System.Linq;
using Routindo.Contract.Attributes;
using Routindo.Plugins.Conversion.Components.Actions.@base;

namespace Routindo.Plugins.Conversion.Components.Actions
{
    [PluginItemInfo(ComponentId, nameof(FirstItemFromCollectionAction),
        "Get the first item from a given collection", Category = "Conversion", FriendlyName = "Get First Item of Collection")]
    [ExecutionArgumentsClass(typeof(ItemFromCollectionConverterExecutionArgs))]
    [ResultArgumentsClass(typeof(ItemFromCollectionConverterResultsArgs))]
    public class FirstItemFromCollectionAction: ItemFromCollectionConverter
    {
        public const string ComponentId = "EEF306C4-F244-40B2-B334-D0F87AD0E0E1";

        protected override T GetItem<T>(IEnumerable<T> collection)
        {
            return collection.FirstOrDefault();
        }
    }
}
