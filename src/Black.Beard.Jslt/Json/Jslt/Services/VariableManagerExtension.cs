using System.Text.RegularExpressions;

namespace Bb.Json.Jslt.Services
{
    public class VariableManagerExtension
    {

        static VariableManagerExtension()
        {

            _reg = new Regex(@"[@[a-zA-Z0-9_]+]");

        }

        public static bool ContainVariable(string key) => _reg.IsMatch(key);

        private static readonly Regex _reg;

        internal static Match Match(string key)
        {
            return _reg.Match(key);
        }
    }


}
