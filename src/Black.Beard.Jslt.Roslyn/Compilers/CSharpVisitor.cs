using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace Bb.Compilers
{

    internal class CSharpVisitor : CSharpSyntaxWalker
    {


        public CSharpVisitor()
        {
            this._usings = new HashSet<string>();
        }

        public override void VisitCompilationUnit(CompilationUnitSyntax node)
        {
            base.VisitCompilationUnit(node);
        }

        public override void VisitUsingStatement(UsingStatementSyntax node)
        {
            base.VisitUsingStatement(node);
        }

        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {

            this._usings.Add(node.Name.ToString());

            base.VisitUsingDirective(node);
        }

        public HashSet<string> GetUsings()
        {
            return this._usings;
        }


        private readonly HashSet<string> _usings;

    }

}
