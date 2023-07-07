using Bb.Asts;
using Bb.Json.Jslt.Builds;
using Bb.Json.Jslt.CustomServices;
using Bb.Json.Jslt.Parser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Bb.Json.Jslt.Asts
{

    public class JsltDirectives : JsltProperty
    {

        public JsltDirectives()
        {
            this.Kind = JsltKind.Property;
            this.Name = "$directives";
        }

        /*
            "$directives":
            {
               "output": 
               {
                   "filter": $.datas,     // It is json path for filter just one part of the output document
                   "mode": to_block(),    // Behavior the output serialization
               }
            }   
        */

        public class OutputDirectives
        {

            public OutputDirectives(JsltProperty output)
            {
                this._output = output;
            }

            public OutputDirectives SetFilter(string path)
            {
                SetValue(_output.Value as JsltObject, "filter", new JsltPath() { Value = path });
                return this;
            }

            public OutputDirectives SetMode(string nethodName, params JsltArgument[] arguments)
            {
                SetValue(_output.Value as JsltObject, "mode", new JsltFunctionCall(nethodName, arguments));
                return this;
            }

            #region private

            private void SetValue(JsltObject dir, string name, JsltBase v)
            {
                var prop = GetProperty(dir, name);
                prop.Value = v;
            }

            private JsltProperty GetProperty(JsltObject root, string name)
            {
                var prop = root.Properties.FirstOrDefault(c => c.Name == name);
                if (prop == null)
                {
                    prop = new JsltProperty() { Name = name };
                    root.Append(prop);
                }
                return prop;
            }

            private JsltProperty _output;

            #endregion private

        }

        public JsltDirectives Output(Action<OutputDirectives> action)
        {

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var output = GetProperty(GetRoot(), "output");
            if (output.Value == null)
                output.Value = new JsltObject();

            action(new OutputDirectives(output));

            return this;

        }

        public JsltDirectives SetCulture(CultureInfo culture)
        {
            SetConstant("culture", culture.IetfLanguageTag);
            return this;
        }

        public JsltDirectives SetAssemblies(params string[] assemblies)
        {
            SetArray("assemblies", assemblies);
            return this;
        }

        public JsltDirectives SetFunctions(params string[] functions)
        {
            SetArray("functions", functions);
            return this;
        }

        public JsltDirectives SetPackages(params string[] packages)
        {
            SetArray("packages", packages);
            return this;
        }

        public JsltDirectives SetImports(params string[] imports)
        {
            SetArray("imports", imports);
            return this;
        }


        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitDirective(this);
        }


        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            writer.Append($"{Quote}{Name}{Quote} : ");

            if (Value != null)
            {

                if (Value is JsltObject)
                    writer.AppendEndLine();

                else if (Value is JsltArray)
                    writer.AppendEndLine();

                writer.ToString(Value);

            }
            else
                writer.Append("null");

            return true;

        }


        #region private

        private void SetConstant(string name, string value)
        {
            var dir = GetRoot();
            var v = new JsltConstant(value, JsltConstant.Resolve(value));
            SetValue(dir, name, v);
        }

        private void SetArray(string name, params object[] values)
        {

            var dir = GetRoot();
            List<JsltBase> list = new List<JsltBase>(values.Length);
            foreach (var value in values)
                list.Add(new JsltConstant(value, JsltConstant.Resolve(value)));

            SetValue(dir, name, new JsltArray(list));
        }

        private void SetValue(JsltObject dir, string name, JsltBase v)
        {
            var prop = GetProperty(dir, name);
            prop.Value = v;
        }

        private JsltObject GetRoot()
        {
            var dir = this.Value as JsltObject;

            if (dir == null)
                this.Value = dir = new JsltObject();

            return dir;

        }

        private JsltProperty GetProperty(JsltObject root, string name)
        {
            var prop = root.Properties.FirstOrDefault(c => c.Name == name);
            if (prop == null)
            {
                prop = new JsltProperty() { Name = name };
                root.Append(prop);
            }
            return prop;
        }

        #endregion private


    }

}
