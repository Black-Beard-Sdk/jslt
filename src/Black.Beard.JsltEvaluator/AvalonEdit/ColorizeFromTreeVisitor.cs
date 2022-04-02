using AppJsonEvaluator;
using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using Bb.Json.Jslt.Services;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Bb.JsltEvaluator.AvalonEdit
{


    internal class ColorizeFromTreeVisitor : IJsltJsonVisitor
    {

        public ColorizeFromTreeVisitor(TextMarkerService textMarkerService, TextEditor textEditor)
        {
            this._textMarkerService = textMarkerService;
            this._textEditor = textEditor;
            this._document = textEditor.Document;
        }

        internal void Apply(JsltBase tree)
        {
            tree.Accept(this);

            foreach (var item in tree.Comments)
                item.Accept(this);

        }

        public object VisitArgument(JsltArgument node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Value != null)
                node.Value.Accept(this);

            return node;
        }

        public object VisitArray(JsltArray node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            foreach (var item in node.Items)
            {
                item.Accept(this);
            }

            return node;
        }

        public object VisitBinaryOperator(JsltBinaryOperator node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Left != null)
                node.Left.Accept(this);

            if (node.Right != null)
                node.Right.Accept(this);

            return node;
        }

        public object VisitCase(JsltCase node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.RightExpression != null)
            {
                ApplyMarker(node.GetLocation(), TextMarkerTypes.None, Colors.White, Colors.MediumPurple, Colors.White);
                node.RightExpression.Accept(this);
            }

            if (node.Block != null)
                node.Block.Accept(this);

            return node;
        }

        public object VisitConstant(JsltConstant node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            return node;

        }

        public object VisitDirective(JsltDirective node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            foreach (var item in node.Metadatas)
                item.Accept(this);

            if (node.Value != null)
                node.Value.Accept(this);

            return node;
        }

        public object VisitFunction(JsltFunctionCall node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            foreach (var item in node.Arguments)
                item.Accept(this);

            foreach (var item in node.ArgumentsBis)
                item.Accept(this);

            return node;
        }

        public object VisitJPath(JsltPath node)
        {

            ApplyMarker(node.GetLocation(), TextMarkerTypes.None, Colors.White, Colors.Gray, Colors.White);

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            return node;
        }

        public object VisitJVariable(JsltVariable node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            foreach (var item in node.Metadatas)
                item.Accept(this);

            if (node.Value != null)
                node.Value.Accept(this);

            return node;

        }

        public object VisitLinkedCode(JsltLinkedCode node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            foreach (var item in node.Items)
                item.Accept(this);

            return node;
        }

        public object VisitMetadata(JsltMetadata node)
        {
            return node;
        }

        public object VisitObject(JsltObject node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            foreach (var item in node.Properties)
                item.Accept(this);

            foreach (var item in node.Variables)
                item.Accept(this);

            return node;
        }

        public object VisitProperty(JsltProperty node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            ApplyMarker(node.Start.StartIndex, node.Name.Length + 2, TextMarkerTypes.None, Colors.White, Colors.MediumPurple, Colors.White);

            foreach (var item in node.Metadatas)
                item.Accept(this);

            if (node.Value != null)
                node.Value.Accept(this);

            return node;
        }

        public object VisitComment(Comment node)
        {
            var start = node.Start.StartIndex;
            var lenght = node.Stop.StartIndex - start;
            ApplyMarker(start, lenght, TextMarkerTypes.None, Colors.White, Colors.LightGray, Colors.White);
            return node;
        }

        public object VisitSwitch(JsltSwitch node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Expression != null)
                node.Expression.Accept(this);

            foreach (var item in node.Cases)
                item.Accept(this);

            if (node.Default != null)
                node.Default.Accept(this);

            return node;

        }

        public object VisitTranslateVariable(JsltTranslateVariable node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Value != null)
            {
                ApplyMarker(node.Value.GetLocation(), TextMarkerTypes.None, Colors.White, Colors.Blue, Colors.White);
                node.Value.Accept(this);
            }

            return node;

        }

        public object VisitUnaryOperator(JsltOperator node)
        {

            if (node.Source != null)
                node.Source.Accept(this);

            if (node.Where != null)
                node.Where.Accept(this);

            if (node.Left != null)
                node.Left.Accept(this);

            return node;

        }

        private void ApplyMarker(int index, int lenght, TextMarkerTypes style, Color markerColor, Color foregroundColor, Color backgroundColor)
        {

            ITextMarker marker = _textMarkerService.Create(index, lenght);
            marker.MarkerTypes = style;
            marker.MarkerColor = markerColor;
            marker.ForegroundColor = foregroundColor;
            marker.BackgroundColor = backgroundColor;
        }

        private void ApplyMarker(TokenLocation location, TextMarkerTypes style, Color markerColor, Color foregroundColor, Color backgroundColor)
        {
            var index = location.StartIndex;
            int lenght = location.StopIndex - index + 1;
            ApplyMarker(index, lenght, style, markerColor, foregroundColor, backgroundColor);
        }              

        public TranformJsonAstConfiguration Configuration { get; set; }


        private TextMarkerService _textMarkerService;
        private readonly TextEditor _textEditor;
        private readonly TextDocument _document;
    }
}
