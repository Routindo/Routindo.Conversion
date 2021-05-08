using System.Collections.Generic;
using System.Linq;
using Routindo.Contract.Attributes;
using Routindo.Plugins.Conversion.Components.Actions.@base;

namespace Routindo.Plugins.Conversion.Components.Actions
{
    [PluginItemInfo(ComponentId, nameof(LastItemFromCollectionAction),
        "Get the last item from a given collection", Category = "Conversion", FriendlyName = "Get Last Item of Collection")]
    [ExecutionArgumentsClass(typeof(ItemFromCollectionConverterExecutionArgs))]
    [ResultArgumentsClass(typeof(ItemFromCollectionConverterResultsArgs))]
    public class LastItemFromCollectionAction: ItemFromCollectionConverter
    {
        public const string ComponentId = "40BADC62-BAE4-4813-AEF6-109B8E726B41";
        protected override T GetItem<T>(IEnumerable<T> collection)
        {
            return collection.LastOrDefault();
        }
    }
}
