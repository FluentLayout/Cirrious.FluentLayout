using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Core.ViewModels;
using UIKit;

namespace QuickLayout.TvApp.Bindings
{
    public class TvOSButtonBinding: MvxTargetBinding
    {
        private IMvxCommand _buttonCommand;
        private UIButton _button;

        public TvOSButtonBinding(UIButton target): base(target)
        {
            _button = target;
            _button.PrimaryActionTriggered += Button_PrimaryActionTriggered;;
            _button.TouchUpInside += Button_PrimaryActionTriggered;
        }

        public override Type TargetType => typeof(IMvxCommand);

        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        public override void SetValue(object value)
        {
            _buttonCommand = value as IMvxCommand;
        }

        void Button_PrimaryActionTriggered(object sender, EventArgs e)
        {
            if (_buttonCommand != null && _buttonCommand.CanExecute())
            {
                _buttonCommand.Execute();
            }
        }
    }
}
