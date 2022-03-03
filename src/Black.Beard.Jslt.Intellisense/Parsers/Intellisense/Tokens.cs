using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Parsers.Intellisense
{


    public static class Tokens
    {

        static Tokens()
        {

            Tokens._dic = new Dictionary<int, Token>();

            var lines = System.Text.Encoding.UTF8.GetString(TokenResources.JsltLexer)
                .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                ;

            Tokens.Keywords = new HashSet<string>();
            foreach (var line in lines)
            {

                var splitIndex = line.LastIndexOf('=');
                var text = line[..splitIndex];
                var value = line.Substring(splitIndex + 1, line.Length - splitIndex - 1);
                if (int.TryParse(value, out int index))
                {

                    if (!_dic.TryGetValue(index, out Token? token))
                        _dic.Add(index, token = new Token() { Type = index });

                    if (char.IsLetter(text[0]))
                    {
                        Keywords.Add(text);
                        token.Name = text;
                    }
                    else
                        token.Text = text.Trim('\'');
                }
                else
                {

                }

            }


            _byKeys = Tokens._dic.ToLookup(c => c.Value.Name);

        }

        public static Token? Get(int index)
        {
            _dic.TryGetValue(index, out Token? token);
            return token;
        }


        public static Token Get(string key)
        {
            return _byKeys[key].First().Value;
        }


        public static HashSet<string> Keywords { get; }

        private static readonly Dictionary<int, Token> _dic;
        private static readonly ILookup<string, KeyValuePair<int, Token>> _byKeys;

    }

}
