using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace AppJsonEvaluator
{


    internal static class ExtensionMethods
    {


        private static readonly Action EmptyDelegate = delegate
        {
            Thread.Sleep(1000);
        };


        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }


        public static bool keyMatch(this KeyEventArgs e, Key key, bool ctrl = false, bool shift = false)
        {

            bool keyIsOk = e.Key == key;
            bool CtrlIsOk = ctrl == ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control);
            bool shiftIsOk = shift == ((e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift);
            //bool altIsOk = alt == ((e.KeyboardDevice.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt);

            return keyIsOk && CtrlIsOk && shiftIsOk; //&& altIsOk;

        }


    }

}
