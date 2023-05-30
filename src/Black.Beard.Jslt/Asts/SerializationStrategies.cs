using System.Collections.Generic;
using System.Globalization;

namespace Bb.Asts
{

    public class SerializationStrategies
    {

        public SerializationStrategies(CultureInfo culture = null)
        {
            this._culture = culture ?? CultureInfo.CurrentCulture;
        }

        public StrategySerializationItem GetStrategy(string ast1)
        {

            if (!_strategies.TryGetValue(ast1, out var item))
                _strategies.Add(ast1, item = new StrategySerializationItem(ast1));

            return item;

        }

        public StrategySerializationItem AddStrategy(string ast1)
        {
            return AddStrategy(new StrategySerializationItem(ast1));
        }

        public StrategySerializationItem AddStrategy(StrategySerializationItem strategy)
        {
            this._strategies.Add(strategy.AstName, strategy);
            return strategy;
        }


        public CultureInfo Culture { get => _culture; }


        private Dictionary<string, StrategySerializationItem> _strategies = new Dictionary<string, StrategySerializationItem>();
        
        internal readonly StrategySerializationItem DefaultStrategy = new StrategySerializationItem();
        private readonly CultureInfo _culture;

    }
        
}
