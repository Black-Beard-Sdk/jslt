using Bb.Jslt.Asts;
using System.Collections.Generic;
using System.IO;

namespace Bb.Jslt.Visitors
{

    public class ResolveDependentFilesVisitor : JsltBaseVisitor
    {


        public static IEnumerable<FileInfo> Visit(JsltBase self, TranformJsonAstConfiguration configuration)
        {
            var visitor = new ResolveDependentFilesVisitor()
            {
                Configuration = configuration
            };
            self.Accept(visitor);
            return visitor.Files;
        }


        public ResolveDependentFilesVisitor()
        {
            Files = new List<FileInfo>();
        }


        public override object VisitConstant(JsltConstant node)
        {

            if (node.Value != null && node.Value is string str)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    var file = Configuration.ResolveFile(str);
                    if (file.Exists)
                        Files.Add(file);
                }
            }

            return node;

        }


        public List<FileInfo> Files { get; }


    }

}
