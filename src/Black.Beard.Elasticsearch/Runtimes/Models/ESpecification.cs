﻿using Oldtonsoft.Json.Linq;
using System.Text;

namespace Bb.Elastic.Runtimes.Models
{

    public class StringSpecification : ESerialize
    {

        public StringSpecification(StringBuilder sb)
        {
            this._sb = sb;
        }

        public override JToken Serialize()
        {
            return _sb.ToString();
        }

        private readonly StringBuilder _sb;

    }

    public class ESpecification : ESerialize
    {
        public int From { get; set; }

        public int Size { get; set; }

        public EQuery Query { get; set; }

        public override JToken Serialize()
        {
            var r = new JObject()
            {
                new JProperty("from", this.From),
            };

            if (Query != null)
                r.Add(new JProperty("query", Query.Serialize()));

            if (Size != 0)
                r.Add(new JProperty("size", this.Size));

            return r;

        }



        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        private static void Stop()
        {

            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();

        }


    }

}