using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Routindo.Contract.Actions;
using Routindo.Contract.Arguments;
using Routindo.Contract.Exceptions;
using Routindo.Contract.Services;

namespace Routindo.Plugins.Conversion.Components.Actions.@base
{
    public abstract class ItemFromCollectionConverter: IAction
    { 
        public string Id { get; set; }
        public ILoggingService LoggingService { get; set; }
        public ActionResult Execute(ArgumentCollection arguments)
        {
            try
            {
                if(arguments == null || !arguments.HasArgument(ItemFromCollectionConverterExecutionArgs.Collection))
                    throw new MissingArgumentException(ItemFromCollectionConverterExecutionArgs.Collection);

                var collectionValue = arguments[ItemFromCollectionConverterExecutionArgs.Collection];
                var collection = ((IEnumerable) collectionValue).Cast<object>();

                var item = GetItem(collection);

                return ActionResult.Succeeded().WithAdditionInformation(ArgumentCollection.New()
                    .WithArgument(ItemFromCollectionConverterResultsArgs.Item, item)
                );

            }
            catch (Exception exception)
            {
                LoggingService.Error(exception);
                return ActionResult.Failed(exception)
                        .WithAdditionInformation(ArgumentCollection.New().WithArgument(ItemFromCollectionConverterResultsArgs.Item, null))
                    ;
            }
        }

        protected abstract T GetItem<T>(IEnumerable<T> collection);  
    }
}
