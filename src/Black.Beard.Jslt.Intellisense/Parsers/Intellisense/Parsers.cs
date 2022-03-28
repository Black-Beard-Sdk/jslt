using Bb.Intellisense;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Parsers.Intellisense
{
    public class Parsers
    {


        public Parsers(TextWriter output = null, TextWriter outputError = null)
        {
            this.Errors = new List<ErrorModel>();
            this._output = output;
            this._outputError = outputError;
        }


        public List<IntellisenseKey> GetIntellisense(int position,StringBuilder source, string sourceFile)
        {

            using (var l = Lock(sourceFile))
            {

                var a = this.Errors.Where(c => c.Filename == sourceFile).ToList();
                foreach (var item in a)
                    this.Errors.Remove(item);

                var result = ConfigParser.ParseString(source, sourceFile, this._output, this._outputError);
                var visitor = new IntellisenseVisitor(result.Parser);
                var keys = visitor.ResolveIntellisense(result.Tree, position);

                return keys;                         
            }

        }



        public ResultParsing ParseString(StringBuilder source, string sourceFile)
        {

            ResultParsing resultParsing = null;

            using (var l = Lock(sourceFile))
            {

                var a = this.Errors.Where(c => c.Filename == sourceFile).ToList();
                foreach (var item in a)
                    this.Errors.Remove(item);

                var result = ConfigParser.ParseString(source, sourceFile, this._output, this._outputError);
                //var visitor = (Visitor)new Visitor(result.Parser)
                //{
                //}.Visit(result.Tree)
                //    ;

                resultParsing = new ResultParsing()
                {

                };

            }

            return resultParsing;

        }


        public void ParsePath(string source)
        {
            var payload = new StringBuilder(source.LoadFromFile());
            ParseString(payload, source);
        }


        public List<ErrorModel> Errors { get; private set; }


        private Disposable Lock(string sourceFile)
        {

            if (!_dic.TryGetValue(sourceFile, out BoxParser box))
                lock (_lock)
                    if (!_dic.TryGetValue(sourceFile, out box))
                        _dic.Add(sourceFile, box = new BoxParser() { SourceFile = sourceFile });

            var d = new Disposable(box);

            return d;

        }

        private class Disposable : IDisposable
        {

            public BoxParser Box { get; }

            private string sourceFile;

            public Disposable(BoxParser box)
            {
                this.Box = box;
                this.sourceFile = box.SourceFile;
                this.Box.Lock();
            }

            public void Dispose()
            {
                this.Box.Unlock();
            }


        }


        private readonly Dictionary<string, BoxParser> _dic = new Dictionary<string, BoxParser>();
        private volatile object _lock = new object();
        private readonly TextWriter _output;
        private readonly TextWriter _outputError;


    }

}
