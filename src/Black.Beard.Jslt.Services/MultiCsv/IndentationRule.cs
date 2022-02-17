using System;
using System.Collections.Generic;

namespace Bb.Jslt.Services.MultiCsv
{
    public class IndentationRule
    {

        public IndentationRule(string rule)
        {
            var items = rule.Trim().Split(':');
            this.Key = items[0].Trim();
            this.Children = new HashSet<string>();
            var i = items[1].Trim().Split('|', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in i)
                this.Children.Add(item.Trim());
        
        }

        public string Key { get; }

        public HashSet<string> Children { get; }

        internal void Merge(IndentationRule rule)
        {
            foreach (var item in rule.Children)
                this.Children.Add(item);
        }

    }

}
