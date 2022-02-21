using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace AppJsonEvaluator
{
    public static class ExtensionMethods
    {

        private static readonly Action EmptyDelegate = delegate
        {
            Thread.Sleep(1000);
        };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

    }
}
