using System.Collections.Generic;
using System.Linq;
using Routindo.Contract.Attributes;
using Routindo.Plugins.Conversion.Components.Actions.@base;

namespace Routindo.Plugins.Conversion.Components.Actions
{
    public class ItemByIndexFromCollectionAction: ItemFromCollectionConverter
    {
        [Argument(ItemByIndexFromCollectionActionArgs.Index, true)] public int Index { get; set; }
        protected override T GetItem<T>(IEnumerable<T> collection)
        {
            return collection.ElementAt(Index);
        }
    }
}
