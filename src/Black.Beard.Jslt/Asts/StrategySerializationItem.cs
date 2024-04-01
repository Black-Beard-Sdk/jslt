using System;

namespace Bb.Asts
{
    public class StrategySerializationItem : ICloneable
    {

        public static StrategySerializationItem Default = new StrategySerializationItem("Default") {  };
        public static StrategySerializationItem DefaultJsltObject = new StrategySerializationItem("DefaultJsltObject") 
        {
            //IndentLineBeforeStarting = true,
            //ReturnLineBeforeStarting = true,

            IndentLineAfterStarting = true,
            ReturnLineAfterStarting = true,

            //ReturnLineBeforeEnding = true,
            //ReturnLineAfterEnding = true,
        };
        public static StrategySerializationItem DefaultJsltArray = new StrategySerializationItem("DefaultJsltArray") 
        {
            //IndentLineBeforeStarting = true,
            //ReturnLineBeforeStarting = true,

            IndentLineAfterStarting = true,
            ReturnLineAfterStarting = true,

            //ReturnLineBeforeEnding = true,
            //ReturnLineAfterEnding = true,
        };

        public static StrategySerializationItem DefaultJsltProperty = new StrategySerializationItem("DefaultJsltProperty")
        {
            //IndentLineBeforeStarting = true,
            //ReturnLineBeforeStarting = true,

            //IndentLineAfterStarting = true,
            //ReturnLineAfterStarting = true,

            //ReturnLineBeforeEnding = true,
            ReturnLineAfterEnding = true,
        };

        public StrategySerializationItem()
        {

        }

        public StrategySerializationItem(string ast1)
        {
            this.AstName = ast1;
        }


        public string AstName { get; set; }

        public bool IndentLineBeforeStarting { get; set; }

        public bool ReturnLineBeforeStarting { get; set; }

        public bool IndentLineAfterStarting { get; set; }

        public bool ReturnLineAfterStarting { get; set; }

        public bool ReturnLineAfterItems { get; set; }

        public bool ReturnLineBeforeEnding { get; set; }

        public bool ReturnLineAfterEnding { get; set; }


        internal void ApplyIndentLineBeforeStarting(Writer writer)
        {
            if (ReturnLineBeforeStarting)
                writer.AddIndent();
        }

        internal void ApplyIndentLineAfterStarting(Writer writer)
        {
            if (IndentLineAfterStarting)
                writer.AddIndent();
        }

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

        internal void ApplyReturnLineBeforeEnding(Writer writer)
        {
            if (ReturnLineBeforeEnding)
                writer.AppendEndLine();
        }

        internal void ApplyIndentLineBeforeEnding(Writer writer)
        {
            if (IndentLineBeforeStarting)
                writer.DelIndent();
        }

        internal void ApplyReturnLineAfterEnding(Writer writer)
        {
            if (ReturnLineAfterEnding)
                writer.AppendEndLine();
        }

        internal void ApplyIndentLineAfterEnding(Writer writer)
        {
            if (IndentLineAfterStarting)
                writer.AppendEndLine();
        }



        public object Clone()
        {
            return new StrategySerializationItem()
            {
                AstName = this.AstName,
                ReturnLineAfterEnding = this.ReturnLineAfterEnding,
                ReturnLineAfterStarting = this.ReturnLineAfterStarting,
                ReturnLineBeforeEnding = this.ReturnLineBeforeEnding,          
                ReturnLineBeforeStarting = this.ReturnLineBeforeStarting,
                IndentLineBeforeStarting = this.IndentLineBeforeStarting,
                IndentLineAfterStarting = this.IndentLineAfterStarting,
            };
        }
    }


}
