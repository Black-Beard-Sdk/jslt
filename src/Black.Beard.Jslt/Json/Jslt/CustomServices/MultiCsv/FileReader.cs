using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Json.Jslt.CustomServices.MultiCsv
{

    public class FileReader
    {


        public static FileReader Readfile(string filePath, string rulePayload)
        {

            var reader = new FileReader(filePath, rulePayload)
            {
            };
            reader.Read();
            return reader;

        }

        private FileReader(string filePath, string rulePayload)
        {
            this._filePath = filePath;
            stack = new Stack<Block>();
            this._items = new List<Block>();
            _rule = new IndentationRules(rulePayload);

        }

        private void Read()
        {

            Encoding encoding = Encoding.UTF8;

            using (var lexer = new Lexer(this._filePath, encoding))
            {

                var token = lexer.MoveNext();
                stack.Push(lexer.Current);

                while (While(lexer))
                {

                    var parent = stack.Peek();
                    var current = lexer.Current;

                    if (this._rule.EvaluateIfEmbeddedInParent(parent, current))
                    {
                        parent.Add(current);
                        stack.Push(current);
                    }
                    else
                    {

                        parent = stack.Pop();

                        while (!this._rule.EvaluateIfEmbeddedInParent(parent, current))
                            parent = stack.Pop();

                        parent.Add(current);
                        stack.Push(parent);
                        stack.Push(current);

                    }

                }
                
                while (stack.Count > 0)
                {
                    var current = stack.Pop();
                    if (stack.Count == 0 || !stack.Peek().Subs.Contains(current))
                    {
                        this._items.Add(current);
                    }
                }

                this.FileInformations = lexer.FileInformations;

            }

        }

        private bool While(Lexer lexer)
        {

            if (lexer.Token == Token.EOF)
                return false;

            var token = lexer.MoveNext();

            return token != Token.EOF;

        }

        private readonly string _filePath;
        private Stack<Block> stack;
        private readonly List<Block> _items;
        private readonly IndentationRules _rule;

        public FileInformations FileInformations { get; private set; }

        public IEnumerable<Block> Items { get => _items; }

    }

}
