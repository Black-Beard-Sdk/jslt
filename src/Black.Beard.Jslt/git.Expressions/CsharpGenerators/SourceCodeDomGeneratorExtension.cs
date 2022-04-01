using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.CsharpGenerators
{

    public static class SourceCodeDomGeneratorExtension
    {


        public static void AddItem(this CodeStatementCollection self, CodeObject item)
        {
            if (item is CodeExpression c)
                self.Add(new CodeExpressionStatement(c));

            else if (item is CodeStatement s)
                self.Add(s);

            else
            {
                LocalDebug.Stop();

            }
        }

        public static int NestedArrayDepth(this CodeTypeReference self) => self.ArrayElementType == null ? 0 : 1 + self.ArrayElementType.NestedArrayDepth();

        public static CodePrimitiveExpression ToPrimitive(this ConstantExpression self)
        {
            return new CodePrimitiveExpression(self.Value);
        }

        public static CodePrimitiveExpression ToPrimitive(this string self)
        {
            return new CodePrimitiveExpression(self);
        }

        public static CodePrimitiveExpression ToPrimitive(this int self)
        {
            return new CodePrimitiveExpression(self);
        }

        public static CodePrimitiveExpression ToPrimitive(this decimal self)
        {
            return new CodePrimitiveExpression(self);
        }

        public static CodePrimitiveExpression ToPrimitive(this Int64 self)
        {
            return new CodePrimitiveExpression(self);
        }

        public static CodeAssignStatement AssignFrom(this CodeExpression left, CodeExpression right)
        {
            return new CodeAssignStatement(left, right);
        }

        public static CodeTypeReference ToRefType(this Type returnType, HashSet<string> usings)
        {

            if (typeof(Type).IsAssignableFrom(returnType))
                return new CodeTypeReference("Type");

            var result = new CodeTypeReference(returnType);

            if (usings != null && usings.Contains(returnType.Namespace))
                result.BaseType = result.BaseType.Substring(returnType.Namespace.Length).TrimStart('.');

            return result;

        }

        public static CodeThisReferenceExpression This()
        {
            return new CodeThisReferenceExpression();
        }

        public static CodeTypeReferenceExpression ToRefExpression(this Type returnType, HashSet<string> usings)
        {
            return new CodeTypeReferenceExpression(returnType.ToRefType(usings));
        }

        public static CodeVariableDeclarationStatement DeclareVariable(this ParameterExpression self, HashSet<string> usings)
        {
            return new CodeVariableDeclarationStatement(self.Type.ToRefType(usings), self.Name);
        }

        public static CodeParameterDeclarationExpression ToParameter(this ParameterExpression self, HashSet<string> usings)
        {
            return new CodeParameterDeclarationExpression() { Name = self.Name, Type = self.Type.ToRefType(usings), Direction = FieldDirection.In };
        }

        public static CodeFieldReferenceExpression GetReference(this CodeTypeMember self)
        {
            return new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), self.Name);
        }


        public static void Add(this CodeStatementCollection self, IEnumerable<CodeStatement> list)
        {
            foreach (var item in list)
                self.Add(item);
        }

        public static void Add(this CodeMemberMethod self, IEnumerable<CodeStatement> list)
        {
            self.Statements.Add(list);
        }

        public static void Add(this CodeMemberMethod self, CodeStatement item)
        {
            self.Statements.Add(item);
        }

    }

}
