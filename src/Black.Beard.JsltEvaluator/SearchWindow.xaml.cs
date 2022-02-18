using AppJsonEvaluator;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bb.JsltEvaluator
{
    /// <summary>
    /// Logique d'interaction pour SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {

        public SearchWindow()
        {
            InitializeComponent();
        }

        public MainWindow Parent { get; set; }

        public Scintilla TextArea { get => SearchManager.TextArea; internal set => SearchManager.TextArea = value; }

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            //SearchManager.SearchBox = this._searchText;
            //SearchManager.Find(true);

            FindNext(this._searchText.Text, SearchFlags.None);

        }

        public int FindNext(string text, SearchFlags flags)
        {

            TextArea.Refresh();

            TextArea.SearchFlags = flags;
            TextArea.TargetStart = Math.Max(TextArea.CurrentPosition, TextArea.AnchorPosition);
            TextArea.TargetEnd = TextArea.TextLength;

            var pos = TextArea.SearchInTarget(text);
            if (pos >= 0)
                TextArea.SetSel(TextArea.TargetStart, TextArea.TargetEnd);

            TextArea.SetSelection(18, 10);
           // TextArea.SetSel(18, 8);

            return pos;

        }

        public string TextSearch { get => this._searchText.Text; set => this._searchText.Text = value; }

        public void TakeFocus()
        {
            this._searchText.Focus();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Parent.CloseSearch();
        }


        internal class SearchManager
        {

            public static ScintillaNET.Scintilla TextArea;
            public static TextBox SearchBox;

            public static string LastSearch = "";

            public static int LastSearchIndex;

            public static void Find(bool incremental)
            {
                bool first = LastSearch != SearchBox.Text;

                LastSearch = SearchBox.Text;
                if (LastSearch.Length > 0)
                {

                    //if (first)
                    //{

                        // SEARCH FOR THE NEXT OCCURANCE

                        // Search the document at the last search index
                        TextArea.TargetStart = LastSearchIndex - 1;
                        TextArea.TargetEnd = TextArea.TextLength;   // LastSearchIndex + (LastSearch.Length + 1);
                        TextArea.SearchFlags = SearchFlags.MatchCase;


                        var r = TextArea.SearchInTarget(LastSearch);


                        // Search, and if not found..
                        //if (!incremental || TextArea.SearchInTarget(LastSearch) == -1)
                        //{

                        //    // Search the document from the caret onwards
                        //    TextArea.TargetStart = TextArea.CurrentPosition;
                        //    TextArea.TargetEnd = TextArea.TextLength;
                        //    TextArea.SearchFlags = SearchFlags.None;

                        //    // Search, and if not found..
                        //    if (TextArea.SearchInTarget(LastSearch) == -1)
                        //    {

                        //        // Search again from top
                        //        TextArea.TargetStart = 0;
                        //        TextArea.TargetEnd = TextArea.TextLength;

                        //        // Search, and if not found..
                        //        if (TextArea.SearchInTarget(LastSearch) == -1)
                        //        {

                        //            // clear selection and exit
                        //            TextArea.ClearSelections();
                        //            return;
                        //        }
                        //    }

                        //}

                    //}
                    //else
                    //{

                    //    // SEARCH FOR THE PREVIOUS OCCURANCE

                    //    // Search the document from the beginning to the caret
                    //    TextArea.TargetStart = 0;
                    //    TextArea.TargetEnd = TextArea.CurrentPosition;
                    //    TextArea.SearchFlags = SearchFlags.MatchCase;

                    //    // Search, and if not found..
                    //    if (TextArea.SearchInTarget(LastSearch) == -1)
                    //    {

                    //        // Search again from the caret onwards
                    //        TextArea.TargetStart = TextArea.CurrentPosition;
                    //        TextArea.TargetEnd = TextArea.TextLength;

                    //        // Search, and if not found..
                    //        if (TextArea.SearchInTarget(LastSearch) == -1)
                    //        {

                    //            // clear selection and exit
                    //            TextArea.ClearSelections();
                    //            return;
                    //        }
                    //    }

                    //}

                    // Select the occurance
                    LastSearchIndex = TextArea.TargetStart;
                    TextArea.SetSelection(TextArea.TargetEnd, TextArea.TargetStart);
                    TextArea.ScrollCaret();

                }

                SearchBox.Focus();
            }


        }


    }
}
