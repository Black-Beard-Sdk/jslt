using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Wizards
{


    public class ObjectResolverVisitor : CSharpSyntaxWalker
    {


        public static List<CodeObject> GetObjects(Microsoft.CodeAnalysis.SyntaxTree tree)
        {
            var v = new ObjectResolverVisitor();
            v.Visit(tree.GetRoot());
            return v._objects;
        }

        private ObjectResolverVisitor()
        {
            this._baseTypes = new HashSet<string>();
            this._objects = new List<CodeObject>();
        }

        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {

            base.VisitNamespaceDeclaration(node);

            var n = GetName(node.Name);

            foreach (var item in this._objects)
            {
                item.Namespace = n;
            }

        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {

            node.BaseList?.Accept(this);

            var name = node.Identifier.ValueText;
            var c = new CodeObject(name, this._baseTypes.ToArray());

            this._objects.Add(c);
            this._baseTypes.Clear();

        }


        public override void VisitSimpleBaseType(SimpleBaseTypeSyntax node)
        {
            TypeSyntax type = node.Type;
            _baseTypes.Add(GetName(type));
        }

        public string GetName(TypeSyntax item)
        {

            string result = string.Empty;

            if (item is IdentifierNameSyntax ins)
                result = ins.Identifier.ValueText;

            else if (item is QualifiedNameSyntax qns)
            {
                var l = GetName(qns.Left);
                var r = GetName(qns.Right);
                result = l + "." + r;
            }
            else if (item is SimpleNameSyntax sns)
            {

            }
            else
            {

            }

            return result;

        }

        private readonly HashSet<string> _baseTypes;
        private readonly List<CodeObject> _objects;

    }

}



