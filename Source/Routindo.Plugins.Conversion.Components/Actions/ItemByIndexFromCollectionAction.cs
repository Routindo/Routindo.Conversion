using System.Collections.Generic;
using System.Linq;
using Routindo.Contract.Attributes;
using Routindo.Plugins.Conversion.Components.Actions.@base;

namespace Routindo.Plugins.Conversion.Components.Actions
{
    [PluginItemInfo(ComponentId, nameof(ItemByIndexFromCollectionAction),
        "Get and item from a given collection at a specific index", Category = "Conversion", FriendlyName = "Get Collection Item by Index")]
    [ExecutionArgumentsClass(typeof(ItemFromCollectionConverterExecutionArgs))]
    [ResultArgumentsClass(typeof(ItemFromCollectionConverterResultsArgs))]
    public class ItemByIndexFromCollectionAction: ItemFromCollectionConverter
    {
        public const string ComponentId = "5C4C33F8-EDB7-4CD1-B22A-25FB34641A73";

        [Argument(ItemByIndexFromCollectionActionArgs.Index, true)] public int Index { get; set; }
        protected override T GetItem<T>(IEnumerable<T> collection)
        {
            return collection.ElementAt(Index);
        }
    }
}
