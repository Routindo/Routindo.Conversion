using System;
using System.Collections;
using System.Collections.Generic;
using Routindo.Contract.Actions;
using Routindo.Contract.Arguments;
using Routindo.Contract.Attributes;
using Routindo.Contract.Exceptions;
using Routindo.Contract.Services;

namespace Routindo.Plugins.Conversion.Components.Actions
{
    [PluginItemInfo(ComponentId, nameof(ListFromItemAction), "Create a list from a given item",
        Category = "Conversion", FriendlyName = "List from Item")]
    [ExecutionArgumentsClass(typeof(ListFromItemActionExecutionArgs))]
    [ResultArgumentsClass(typeof(ListFromItemActionResultsArgs))]
    public class ListFromItemAction: IAction
    {
        public const string ComponentId = "8A62AC3F-DE67-4CEE-875E-B32057BAA162";

        public string Id { get; set; }
        public ILoggingService LoggingService { get; set; }
        public ActionResult Execute(ArgumentCollection arguments)
        {
            try
            {
                if(arguments == null || !arguments.HasArgument(ListFromItemActionExecutionArgs.Item))
                    throw new MissingArgumentException(ListFromItemActionExecutionArgs.Item);

                var item = arguments[ListFromItemActionExecutionArgs.Item];
                Type x = item.GetType();
                Type listType = typeof(List<>).MakeGenericType(x);
                IList list = Activator.CreateInstance(listType) as IList;

                if(list == null)
                    throw new Exception($"Unable to create a generic list from type {item.GetType()}");

                list.Add(item) ;

                return ActionResult.Succeeded().WithAdditionInformation(ArgumentCollection.New()
                    .WithArgument(ListFromItemActionResultsArgs.Collection, list)
                );
            }
            catch (Exception exception)
            {
                LoggingService.Error(exception);
                return ActionResult.Failed(exception);
            }
        }
    }
}
