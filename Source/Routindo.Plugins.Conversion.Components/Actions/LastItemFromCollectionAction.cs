﻿using System.Collections.Generic;
using System.Linq;
using Routindo.Plugins.Conversion.Components.Actions.@base;

namespace Routindo.Plugins.Conversion.Components.Actions
{
    public class LastItemFromCollectionAction: ItemFromCollectionConverter
    {
        protected override T GetItem<T>(IEnumerable<T> collection)
        {
            return collection.LastOrDefault();
        }
    }
}