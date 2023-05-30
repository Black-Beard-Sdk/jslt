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

        public bool ReturnLineBefore { get; set; }
        public bool ReturnLineAfter { get; set; }

        public bool ReturnLineAfterItems { get; set; }

    }


}
