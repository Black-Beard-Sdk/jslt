using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Jslt.Services.MultiCsv
{
    /// <summary>
    /// Interpreter design pattern:
    /// To parse file we are using a lexing as described in Interpreter design pattern
    /// </summary>
    internal class Lexer : IDisposable
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Lexer" /> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="encoding">The encoding.</param>
        public Lexer(string file, Encoding encoding)
        {
            _Filename = file;
            //Errors = new BlockErrors();
            Open(encoding);
        }


        public FileInformations FileInformations { get => _Informations; }

        /// <summary>
        /// Moves the next.
        /// </summary>
        /// <returns></returns>
        public Token MoveNext()
        {

            _Current = GetLine();
            _Index++;

            if (_Current == null)
                return _token = Token.EOF;

            if (_Current.ErrorOnblock)
                return _token = Token.UNKNOWN;

            return _token = Token.Text;

        }


        /// <summary>
        /// Get next line automatically converted into a block. Header is implicitly processed here
        /// </summary>
        /// <returns>Block</returns>
        private Block GetLine()
        {

            string[] s;
            var rawLineContent = string.Empty;
            //read headers 
            while ((s = ReadLine(out rawLineContent)) != null && s.Length > 0 && s[0][0] == '#')
            {
                if (s[0] == "#DEF")
                    ReadDef(s);

                else if (s[0] == "#END")
                {
                    this.Close();
                    return null;
                }
                else
                {
                    var k = s[0];
                    _Informations.Metadatas.Add(k[1..], string.Join(";", s.Skip(1).ToArray()));
                }
                _Index++;
            }

            if (s != null && s.Length > 0)
            {
                string headerName = s[0];
                var blockForParsing = new Block();
                blockForParsing.RawContent = rawLineContent;
                blockForParsing.Line = _Index;

                HeaderReference header = null;
                if (!_Informations.Headers.Contains(headerName))
                {
                    blockForParsing.ErrorOnblock = true;
                    blockForParsing.ErrorMsg = "No #DEF with this token exists : " + _Current.Name;
                }
                else
                    header = _Informations.Headers[headerName] as HeaderReference;

                blockForParsing.Name = header?.LabelLine ?? headerName;

                if (!blockForParsing.ErrorOnblock)
                    for (int i = 1; i < s.Length - 1; i++)
                    {
                        int _i = i - 1;
                        if (header.Count > _i)
                        {
                            var c = header[_i];
                            //var v = c.Convert(s[i]);
                            blockForParsing[c.Name] = s[i];
                        }
                    }

                return blockForParsing;

            }

            return null;

        }



        /// <summary>
        /// Get next line (Raw data), parse it as a csv file with ';' separator
        /// </summary>
        /// <returns>splitted string into an array resulting of csv parsing</returns>
        private string[] ReadLine(out string rawLineContent)
        {
            rawLineContent = _Ps.TextReader.ReadLine();
            if (!string.IsNullOrEmpty(rawLineContent))
                return rawLineContent.Split(';');
            return new string[0];
        }

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public Block Current { get { return _Current; } }

        public Token Token { get => _token; }

        /// <summary>
        /// open file and get encoding of file with the Ude library
        /// </summary>
        private void Open(Encoding encoding)
        {
            if (!_IsOpen && _Ps.TextReader == null)
            {
                var file = new FileInfo(_Filename);

                if (!file.Exists)
                    throw new FileNotFoundException(_Filename);

                _Informations = new FileInformations { FileInfo = file };

                _Ps = new ParsingState();
                _Ps.Clear();

                //test ude for charset detection
                using (var fs = new FileStream(_Filename, FileMode.Open, FileAccess.Read))
                {
                    using (new StreamReader(fs))
                    {

                        var cdet = new Ude.CharsetDetector();
                        cdet.Feed(fs);
                        cdet.DataEnd();

                        if (cdet.Charset != null)
                        {
                            _Informations.EncodingByUde = Encoding.GetEncoding(cdet.Charset);
                        }
                    }
                }

                _Ps.TextReader = new StreamReader(_Filename, encoding ?? _Informations.EncodingByUde ?? Encoding.Default);

                _IsOpen = true;
            }
            else
                throw new InvalidOperationException("the file can't be Open.");
        }

        private struct ParsingState
        {

            internal TextReader TextReader;

            internal void Clear()
            {
                TextReader = null;
            }

            internal void Close(bool closeInput)
            {
                if (closeInput)
                    if (TextReader != null)
                        TextReader.Close();
            }
        }


        /// <summary>
        /// Parse Def line. It is corresponding to a header definition.
        /// </summary>
        /// <param name="s"></param>
        private void ReadDef(string[] s)
        {

            var e1 = s[1].Split(':');

            var schema = e1[0];
            var name = e1[e1.Length - 1];
            if (schema == name)
                schema = string.Empty;

            var header = _Informations.GetHeader(name, schema);

            for (int i = 2; i < s.Length; i++)
            {
                name = s[i].Trim();
                if (!string.IsNullOrEmpty(name))
                {
                    var cd = new ColumnDefinition(header, name, header.Count + 1);
                    header.Add(cd);
                }
            }
        }

        #region IDisposable

        /// <summary>
        /// Close file
        /// </summary>
        private void Close()
        {
            if (_IsOpen && _Ps.TextReader != null)
                _Ps.Close(true);
        }

        /// <summary>
        /// Exécute les tâches définies par l'application associées à la libération ou à la redéfinition des ressources non managées.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                Close();
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Lexer"/> class.
        /// </summary>
        ~Lexer()
        {
            Dispose(false);
        }

        #endregion Dispose

        private Block _Current;
        private readonly string _Filename;
        private int _Index = 1;
        private Token _token;
        private bool _IsOpen;
        private ParsingState _Ps;
        private FileInformations _Informations;

    }

}
