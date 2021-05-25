using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Folding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace AppJsonEvaluator
{
    /// <summary>
    /// Allows producing foldings from a document based on braces.
    /// </summary>
    public class BraceFoldingStrategy
    {

        private readonly char _openingBrace;
        private readonly char _closingBrace;
        private readonly char _openingBraket;
        private readonly char _closingBraket;

        /// <summary>
        /// Creates a new BraceFoldingStrategy.
        /// </summary>
        public BraceFoldingStrategy()
        {
            this._openingBrace = '{';
            this._openingBraket = '[';

            this._closingBrace = '}';
            this._closingBraket = ']';

        }


        /// <summary>
        /// Create <see cref="T:ICSharpCode.AvalonEdit.Folding.NewFolding" />s for the specified document and updates the folding manager with them.
        /// </summary>
        public void UpdateFoldings(FoldingManager manager, TextDocument document)
        {
            int firstErrorOffset;
            IEnumerable<NewFolding> newFoldings = CreateNewFoldings(document, out firstErrorOffset);
            manager.UpdateFoldings(newFoldings, firstErrorOffset);
        }

        /// <summary>
        /// Create <see cref="NewFolding"/>s for the specified document.
        /// </summary>
        public IEnumerable<NewFolding> CreateNewFoldings(TextDocument document, out int firstErrorOffset)
        {
            firstErrorOffset = -1;
            return CreateNewFoldings(document);
        }

        /// <summary>
        /// Create <see cref="NewFolding"/>s for the specified document.
        /// </summary>
        public IEnumerable<NewFolding> CreateNewFoldings(ITextSource document)
        {
            List<NewFolding> newFoldings = new List<NewFolding>();
            Stack<int> startOffsets = new Stack<int>();
            int lastNewLineOffset = 0;

            for (int i = 0; i < document.TextLength; i++)
            {

                char c = document.GetCharAt(i);
                
                if (c == _openingBrace || c == _openingBraket)
                    startOffsets.Push(i);
                
                else if ((c == _closingBrace || c == _closingBraket) && startOffsets.Count > 0)
                {
                    int startOffset = startOffsets.Pop();
                    // don't fold if opening and closing brace are on the same line
                    if (startOffset < lastNewLineOffset)
                        newFoldings.Add(new NewFolding(startOffset, i + 1));

                }
                else if (c == '\n' || c == '\r')
                    lastNewLineOffset = i + 1;
            
            }

            newFoldings.Sort((a, b) => a.StartOffset.CompareTo(b.StartOffset));
            return newFoldings;
        }

    }


}
