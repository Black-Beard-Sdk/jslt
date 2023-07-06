using System;

namespace Bb.Asts
{
    public class StrategySerializationItem
    {

        public static StrategySerializationItem Default = new StrategySerializationItem("Default") { Indent = true };

        public StrategySerializationItem()
        {

        }

        public StrategySerializationItem(string ast1)
        {
            this.AstName = ast1;
        }


        public string AstName { get; set; }

        public bool Indent { get; set; }

        public bool ReturnLineBeforeStarting { get; set; }
        public bool ReturnLineAfterStarting { get; set; }

        internal void ApplyReturnLineBeforeStarting(Writer writer)
        {
            if (ReturnLineBeforeStarting)
                writer.AppendEndLine();
        }

        internal void ApplyReturnLineAfterStarting(Writer writer)
        {
            if (ReturnLineAfterStarting)
                writer.AppendEndLine();
        }





        public bool ReturnLineBeforeItems { get; set; }
        public bool ReturnLineAfterItems { get; set; }

        internal void ApplyReturnLineBeforeItems(Writer writer)
        {
            if (ReturnLineAfterItems)
                writer.AppendEndLine();
        }

        internal void ApplyReturnLineAfterItems(Writer writer)
        {
            if (ReturnLineAfterItems)
                writer.AppendEndLine();
        }



        public bool ReturnLineBeforeEnding { get; set; }
        public bool ReturnLineAfterEnding { get; set; }
        
        internal void ApplyReturnLineAfterEnding(Writer writer)
        {
            if (ReturnLineAfterEnding)
                writer.AppendEndLine();
        }

        internal void ApplyReturnLineBeforeEnding(Writer writer)
        {
            if (ReturnLineBeforeEnding)
                writer.AppendEndLine();
        }


    }


}
