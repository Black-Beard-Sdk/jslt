using Microsoft.CodeAnalysis.Text;

namespace Bb.Compilers
{
    public class LocationResult
    {

        public LocationResult()
        {

        }

        public string FilePath { get; internal set; }

        public int StartCharacter { get; internal set; }

        public int StartColumn { get; internal set; }

        public int StartLine { get; internal set; }



        public int EndCharacter { get; internal set; }

        public int EndLine { get; internal set; }

        public int EndColumn { get; internal set; }



        public override string ToString()
        {
            var file = this.FilePath ?? string.Empty;
            return $"{file} from (line {this.StartLine}, column {this.StartColumn}) to (line {this.EndLine}, column {this.EndColumn})";
        }

    }

}
