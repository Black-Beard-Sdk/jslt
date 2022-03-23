using System;
using System.Windows;
using System.Windows.Controls;

namespace Wizards.Actions
{

    public class ParserObbjectEventArgs : EventArgs
    {

        public ListView List { get; internal set; }

        public Button Button { get; internal set; }

        public Window Main { get; internal set; }

    }

}



