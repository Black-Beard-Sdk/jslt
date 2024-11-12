using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Jslt.Services
{

    public class TransformJsonServiceProvider
    {

        public TransformJsonServiceProvider()
        {

        }

        public void Add(Factory factory)
        {
            _instances.Add(factory);
        }

        public Factory Get_Impl(Type[] parameters, RuleMatching[] ruleMatchings)
        {

            List<(int[], Factory)> result = new List<(int[], Factory)>(_instances.Count);
            foreach (var factory in _instances)
                if (factory.IsCtor)
                {
                    if (factory.Parameters.Length + 1 == parameters.Length)
                        TestCtorMethod(parameters, result, factory, ruleMatchings);
                }
                else
                {
                    if (factory.Parameters.Length == parameters.Length)
                        TestMethod(parameters, result, factory, ruleMatchings);
                }


            if (result.Count == 1)
                return result[0].Item2 as Factory;

            foreach (var item in result.OrderBy(c => c.Item1[0]).ThenByDescending(c => c.Item1[1]).OrderByDescending(c => c.Item1[2]))
                return item.Item2 as Factory;

            return null;
        }

        private static void TestCtorMethod(Type[] parameters, List<(int[], Factory)> result, Factory factory, RuleMatching[] ruleMatchings)
        {
            int[] scoring = new int[parameters.Length];
            for (int i = 0; i < parameters.Length - 1; i++)
            {

                Type source = parameters[i + 1];
                Type target = factory.Parameters[i].ParameterType;
                if (!ComputeScoring(ruleMatchings, scoring, i, source, target))
                    return;

            }

            result.Add((new int[] { scoring.Count(c => c == 0), scoring.Count(c => c == 1), scoring.Count(c => c == 2) }, factory));

        }



        /// <summary>
        /// this method evaluate the scoring of the method 
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="result"></param>
        /// <param name="factory"></param>
        private static void TestMethod(Type[] parameters, List<(int[], Factory)> result, Factory factory, RuleMatching[] ruleMatchings)
        {

            int[] scoring = new int[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {

                Type source = parameters[i];
                Type target = factory.Parameters[i].ParameterType;
                if (!ComputeScoring(ruleMatchings, scoring, i, source, target))
                    return;

            }

            result.Add((new int[] { scoring.Count(c => c == 0), scoring.Count(c => c == 1), scoring.Count(c => c == 2) }, factory));

        }

        private static bool ComputeScoring(RuleMatching[] ruleMatchings, int[] scoring, int i, Type source, Type target)
        {
            int o = 100;
            foreach (var rule in ruleMatchings)
                if (rule.Type.IsAssignableFrom(target))
                {
                    var t1 = rule.Filter(source, target);
                    if (t1 != -1)
                        o = Math.Min(o, t1);
                    if (o == 0)
                        break;
                }

            if (o == -1)
                return false;

            scoring[i] = o;
            return true;
        }

        public IEnumerable<Factory> GetItems()
        {
            return _instances;
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            foreach (var item in _instances)
            {
                sb.Append(item.Name);
                sb.Append(", ");
            }
            return sb.ToString().Trim(',', ' ');

        }

        private List<Factory> _instances = new List<Factory>();

    }

    public class RuleMatching
    {

        public RuleMatching(Type targetType, Func<Type, Type, int> filter)
        {
            this.Type = targetType;
            this.Filter = filter;
        }

        public Type Type { get; }

        public Func<Type, Type, int> Filter { get; }

    }


}
