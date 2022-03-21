using System;

namespace Wizards
{

    public class ParserObject
    {

        public ParserObject(string label)
        {

            this.Label = label;

        }

        public virtual void Click(object sender, ParserObbjectEventArgs e)
        {


        }

        public string Label { get; }

    }

}



