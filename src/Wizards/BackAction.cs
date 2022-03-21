using System;

namespace Wizards
{
    public class BackAction : ParserObject
    {


        public BackAction(DirectoryObject parent)
            : base("Back")
        {

            this._parent = parent;

        }


        public override void Click(object sender, ParserObbjectEventArgs e)
        {

            if (_parent != null)
            {

                e.Main.DataContext = this._parent.Subs;

            }

        }

        private readonly DirectoryObject _parent;

    }

}



