using System;
using System.Collections.Specialized;
using System.Windows.Input;
using AppKit;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Navigation;
using MvvmCross.Platforms.Mac.Views;
using MvvmCross.ViewModels;

namespace QuickLayout.Mac
{
    // This class is never actually executed, but when Xamarin linking is enabled it does ensure types and properties
    // are preserved in the deployed app
    [Foundation.Preserve(AllMembers = true)]
    public class LinkerPleaseInclude
    {
        public void Include(MvxTaskBasedBindingContext c)
        {
            c.Dispose();
            var c2 = new MvxTaskBasedBindingContext();
            c2.Dispose();
        }

        public void Include(NSButton uiButton)
        {
            uiButton.Activated += (s, e) => uiButton.Title = uiButton.Title;
        }

        //public void Include(NSBarButtonItem barButton)
        //{
        //    barButton.Clicked += (s, e) =>
        //                         barButton.Title = barButton.Title + "";
        //}

        public void Include(NSTextField textField)
        {
            textField.StringValue = textField.StringValue + "";
            textField.EditingBegan += (sender, args) => { textField.StringValue = ""; };
            textField.EditingEnded += (sender, args) => { textField.StringValue = ""; };
        }

        public void Include(NSTextView textView)
        {
            textView.Value = textView.Value + "";
            textView.TextStorage.DidProcessEditing += (sender, e) => textView.Value = "";
            textView.TextDidChange += (sender, args) => { textView.Value = ""; };
        }

        public void Include(NSImageView imageView)
        {
            imageView.Image = new NSImage(imageView.Image.CGImage, new CGSize(2, 2));
        }

        public void Include(NSDatePicker date)
        {
            date.DateValue = date.DateValue.AddSeconds(1);
            date.Activated += (sender, args) => { date.DateValue = NSDate.DistantFuture; };
        }

        public void Include(NSSlider slider)
        {
            slider.DoubleValue = slider.DoubleValue + 1;
            slider.Activated += (sender, args) => { slider.DoubleValue = 1; };
        }

        public void Include(MvxViewController vc)
        {
            vc.Title = vc.Title + "";
        }

        public void Include(NSStepper s)
        {
            s.IntValue = s.IntValue + 1;
            s.Activated += (sender, args) => { s.IntValue = 0; };
        }

        public void Include(INotifyCollectionChanged changed)
        {
            changed.CollectionChanged += (s, e) => { var test = $"{e.Action}{e.NewItems}{e.NewStartingIndex}{e.OldItems}{e.OldStartingIndex}"; };
        }

        public void Include(ICommand command)
        {
            command.CanExecuteChanged += (s, e) => { if (command.CanExecute(null)) command.Execute(null); };
        }

        public void Include(MvvmCross.IoC.MvxPropertyInjector injector)
        {
            injector = new MvvmCross.IoC.MvxPropertyInjector();
        }

        public void Include(System.ComponentModel.INotifyPropertyChanged changed)
        {
            changed.PropertyChanged += (sender, e) => { var test = e.PropertyName; };
        }

        public void Include(MvxNavigationService service, IMvxViewModelLoader loader)
        {
            service = new MvxNavigationService(null, loader);
        }

        public void Include(ConsoleColor color)
        {
            Console.Write("");
            Console.WriteLine("");
            color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public void Include(MvvmCross.Plugin.MethodBinding.Plugin p)
        {
            var _ = p;
        }
    }
}