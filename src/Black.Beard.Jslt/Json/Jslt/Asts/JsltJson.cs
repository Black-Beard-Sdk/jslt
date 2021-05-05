using System;

namespace Bb.Json.Jslt.Asts
{

    public abstract class JsltJson
    {

        public JsltKind Kind { get; internal set; }

        public abstract object Accept(IJsltJsonVisitor visitor);


        public JsltJson Source { get; internal set; }

        public JsltJson Where { get; internal set; }


    }

}
