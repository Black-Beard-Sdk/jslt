using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;

namespace Bb.Expressions.CsharpGenerators
{

    public class LocalCodeGenerator
    {



        public static StringBuilder GenerateCsharpCode(CodeExpression expression)
        {
            return GenerateCode(new LocalCSharpCodeProvider(), expression);
        }

        public static void GenerateCsharpCode(CodeCompileUnit compileunit, string outputfile)
        {
            GenerateCode(new LocalCSharpCodeProvider(), compileunit, outputfile);
        }

        public static void GenerateCode(CodeDomProvider provider, CodeCompileUnit compileunit, string outputfile)
        {

            if (File.Exists(outputfile))
                File.Delete(outputfile);

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(outputfile, false), "    "))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromCompileUnit(compileunit, tw, new CodeGeneratorOptions()
                {
                    
                });
                // Close the output file.
                tw.Close();
            }
        }

        public static StringBuilder GenerateCode(CodeDomProvider provider, CodeExpression expression)
        {

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (var txt = new System.IO.StringWriter())
            using (IndentedTextWriter tw = new IndentedTextWriter(txt))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromExpression(expression, tw, new CodeGeneratorOptions());
                // Close the output file.
                tw.Close();

                return txt.GetStringBuilder();

            }
        }

        public static StringBuilder GenerateCode(CodeDomProvider provider, CodeTypeDeclaration expression)
        {

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            using (var txt = new System.IO.StringWriter())
            using (IndentedTextWriter tw = new IndentedTextWriter(txt))
            {
                // Generate source code using the code generator.
                provider.GenerateCodeFromType(expression, tw, new CodeGeneratorOptions());
                // Close the output file.
                tw.Close();

                return txt.GetStringBuilder();

            }
        }

    }

}
