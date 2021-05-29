using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using System;

namespace AppJsonEvaluator
{
    /// Implements AvalonEdit ICompletionData interface to provide the entries in the
    /// completion drop down.
    public class MyCompletionData : ICompletionData
    {
        public MyCompletionData(string text, string content, string description)
        {
            this.Text = text;
            this.Content = content;
            this.Description = description;
        }

        public System.Windows.Media.ImageSource Image { get { return null; } }

        public string Text { get; private set; }


        public object Content { get; private set; }

        public object Description { get; private set; }

        public double Priority => 0;

        public void Complete(TextArea textArea, ISegment completionSegment, EventArgs insertionRequestEventArgs)
        {
            textArea.Document.Replace(completionSegment, this.Content.ToString());
        }

    }

}
