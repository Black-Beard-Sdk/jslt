using System.Collections.Generic;

namespace Bb.Json.Jslt.Builds
{
    public class SourceCodes
    {

        public SourceCodes()
        {
            _sources = new Dictionary<string, SourceCode>();
        }
             

        public SourceCode Add(string filename)
        {

            if (!_sources.TryGetValue(filename, out SourceCode code))
            {
                code = SourceCode.GetFromFile(filename);
                _sources.Add(filename, code);
            }

            return code;

        }

        public string GetUniqueAssemblyName()
        {
            uint key = 0;
            this.EnsureUptodated();
            foreach (var item in _sources.Values)
            {
                key ^= item.Name.Calculate();
                key ^= item.Datas.Calculate();
            }

            return "assembly_" + key.ToString();

        }

        public IEnumerable<SourceCode> Documents => _sources.Values;

        public void EnsureUptodated()
        {
            foreach (var item in _sources)
            {
                item.Value.HasUpdated();
            }
        }


        private readonly Dictionary<string, SourceCode> _sources;

    }



}
