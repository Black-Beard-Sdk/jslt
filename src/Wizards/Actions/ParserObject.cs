using System;

namespace Wizards.Actions
{

    [System.Diagnostics.DebuggerDisplay("{Label}")]
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



