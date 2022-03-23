using System;

namespace Wizards.Actions
{


    public class CustomAction : ParserObject
    {

        public CustomAction(string label, Action<object , ParserObbjectEventArgs> action)
            : base(label)
        {

            this._action = action;

        }

        public override void Click(object sender, ParserObbjectEventArgs e)
        {

            this._action(sender, e);

        }

        private readonly Action<object, ParserObbjectEventArgs> _action;

    }

}



