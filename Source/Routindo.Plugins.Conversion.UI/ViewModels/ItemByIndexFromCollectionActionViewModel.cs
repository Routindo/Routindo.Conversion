using Routindo.Contract.Arguments;
using Routindo.Contract.UI;
using Routindo.Plugins.Conversion.Components.Actions;

namespace Routindo.Plugins.Conversion.UI.ViewModels
{
    public class ItemByIndexFromCollectionActionViewModel: PluginConfiguratorViewModelBase
    {
        private int _index;

        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                ClearPropertyErrors();
                ValidateNumber(_index, i => i >= 0);
                OnPropertyChanged();
            }
        }

        public override void Configure()
        {
            InstanceArguments = ArgumentCollection.New()
                    .WithArgument(ItemByIndexFromCollectionActionArgs.Index, Index)
                ;
        }

        public override void SetArguments(ArgumentCollection arguments)
        {
            if (arguments != null && arguments.HasArgument(ItemByIndexFromCollectionActionArgs.Index))
                Index = arguments.GetValue<int>(ItemByIndexFromCollectionActionArgs.Index);
        }
    }
}
