using System;
using System.Collections.Generic;

namespace Bb.Json.Jslt.CustomServices.MultiCsv
{

    internal class IndentationRules
    {

        public IndentationRules(string payload)
        {

            this._rules = new Dictionary<string, IndentationRule>();

            var rules = payload
                .Trim()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var rulePayload in rules)
            {
                var rule = new IndentationRule(rulePayload);
                if (this._rules.TryGetValue(rule.Key, out IndentationRule r))
                    r.Merge(rule);
                else
                    this._rules.Add(rule.Key.Trim(), rule);
            }

        }

        public bool EvaluateIfEmbeddedInParent(Block parent, Block child)
        {

            if (parent == null)
                throw new NullReferenceException(nameof(parent));

            if (this._rules.TryGetValue(parent.Name, out IndentationRule r))
                return r.Children.Contains(child.Name);

            return false;
            //throw new Exception($"Missing rule for parent {parent.Name}");

        }


        private readonly Dictionary<string, IndentationRule> _rules;

    }

}
