using System.Diagnostics;

namespace Bb.Parsers.Intellisense
{

    public class CompletionDataProvider
    {


        public CompletionDataProvider()
        {
            this._factories = new Dictionary<string, CompletionDataFactory>();
        }


        public void Add(CompletionDataFactory factory)
        {

            foreach (var item in factory.Names)
            {

                if (!_factories.TryGetValue(item, out var fact))
                    _factories.Add(item, factory);

                else
                {

                    fact = _factories[item];

                    if (fact.GetType() != factory.GetType())
                        throw new InvalidOperationException($"duplicated key {item}");

                    _factories[item] = factory;

                }
            }

        }


        public CompletionResult GetCompletions(List<IntellisenseKey> keys)
        {

            var result = new CompletionResult();

            foreach (var key in keys)
                if (_factories.TryGetValue(key.Name, out var factory))
                    factory.Populate(key, result);
                else
                    Debug.WriteLine($"completion key {key.Name} not matches");

            return result;
        }


        private readonly Dictionary<string, CompletionDataFactory> _factories;

    }


}
