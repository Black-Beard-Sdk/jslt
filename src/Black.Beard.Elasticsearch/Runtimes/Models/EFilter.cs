﻿using Oldtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Bb.Elastic.Runtimes.Models
{
    public class EFilter : ESerialize
    {


        public EFilter()
        {
            Items = new List<ESerialize>();
        }

        public List<ESerialize> Items { get; }

        public override JToken Serialize()
        {

            List<JToken> lst = new List<JToken>(Items.Count);

            foreach (var item in Items)
                lst.Add(item.Serialize());

            var result = new JArray(lst);
            return result;
        }
    }

}