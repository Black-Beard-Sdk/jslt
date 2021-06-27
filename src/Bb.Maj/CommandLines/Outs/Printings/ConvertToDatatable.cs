using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.CommandLines.Outs.Printings
{

    internal static class ConvertToDatatable
    {

        public static DataTable Convert<T>(T result, string label, params Expression<Func<T, object>>[] items)
        {
            return ConvertList<T>(new T[] { result }, label, items);
        }

        public static DataTable ConvertList<T>(IEnumerable<T> rows, string label, params Expression<Func<T, object>>[] columns)
        {

            Type _type = rows.FirstOrDefault().GetType();

            var properties = GetMember(columns).Select(c => c.Name).ToArray();

            var r = rows.Cast<object>().ToList();

            return ConvertList(r, label, properties);
        }

        public static DataTable ConvertList(IEnumerable<object> rows, string label, string[] columns)
        {

            Type _type = rows.FirstOrDefault().GetType();

            var props = _type.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            List<PropertyInfo> members = (columns.Length == 0)
                ? props
                : props.Where(c => columns.Contains(c.Name)).ToList();

            DataTable table = new DataTable
            {
                TableName = label ?? _type.Name,
            };

            foreach (var item in members)
            {
                Type type = item.PropertyType;
                var column = table.Columns.Add(" " + item.Name.Replace("_", " ") + " ", type);
            }

            foreach (var rowSource in rows)
            {

                List<object> rowTarget = new List<object>();

                foreach (var item in members)
                    rowTarget.Add(item.GetValue(rowSource));

                table.Rows.Add(rowTarget.ToArray());

            }

            return table;

        }

        public static IEnumerable<PropertyInfo> GetMember(params Expression[] items)
        {

            foreach (var item in items)
                yield return Visitor.Get(item);

        }

        private class Visitor : System.Linq.Expressions.ExpressionVisitor
        {

            public static PropertyInfo Get(Expression e)
            {
                var v = new Visitor();
                v.Visit(e);
                return v._member;
            }

            protected override Expression VisitMember(MemberExpression node)
            {

                _member = node.Member as PropertyInfo;

                return base.VisitMember(node);
            }

            private PropertyInfo _member;

        }

    }

}
