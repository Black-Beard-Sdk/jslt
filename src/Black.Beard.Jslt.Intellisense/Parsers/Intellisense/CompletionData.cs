namespace Bb.Parsers.Intellisense
{


    [System.Diagnostics.DebuggerDisplay("{Text}")]

    public class CompletionData
    {

        public CompletionData(Token token)
            : this(token.Name.Replace("_", " "), token.Text, string.Empty)
        {

        }

        public CompletionData(string text, object content, object description, object? image = null)
        {
            this.Text = text;
            this.Content = content;
            this.Description = description;
            this.Image = image;
        }

        public string Text { get; }

        public object Content { get; }

        public object Description { get; }

        public object? Image { get; set; }

        public double Priority { get; private set; } = 0;

    }


    public static class CompletionDataExtension
    {

        public static CompletionData GetFromToken(this Token self, Func<Token, string> text, Func<Token, object> content, Func<Token, object> description)
        {

            return new CompletionData(text(self), content(self), description(self));

        }

    }


}

