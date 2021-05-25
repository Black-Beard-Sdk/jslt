using Bb.ComponentModel.Factories;
using Bb.Expresssions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Bb.Json.Jslt.Services.TranformJsonAstConfiguration;

namespace Bb.Json.Jslt.Services
{

    public class TransformJsonServiceProvider
    {

        static TransformJsonServiceProvider()
        {
        }

        public TransformJsonServiceProvider()
        {
        }

        public void Add(Factory factory)
        {
            _instances.Add(factory);
        }

        public Factory Get(Type[] parameters)
        {

            List<(int[], Factory)> result = new List<(int[], Factory)>(_instances.Count);
            foreach (var factory in _instances)
            {

                if (factory.IsCtor)
                {
                    if (factory.Parameters.Length == parameters.Length)
                        TestConstructor(parameters, result, factory);
                    else
                    {
                        if (factory.Parameters.Length == 0 && parameters.Length == 1)
                        {

                        }
                    }
                }

                else if (factory.Parameters.Length == parameters.Length + 1)
                    TestMethod(parameters, result, factory);

            }

            if (result.Count == 1)
                return result[0].Item2 as Factory;

            foreach (var item in result.OrderBy(c => c.Item1[0]).ThenByDescending(c => c.Item1[1]).OrderByDescending(c => c.Item1[2]))
                return item.Item2 as Factory;

            return null;
        }

        private static void TestConstructor(Type[] parameters, List<(int[], Factory)> result, Factory factory)
        {
            bool test = true;
            int[] scoring = new int[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                var t = ExpressionHelper.CanBeConverted(factory.Parameters[i].ParameterType, parameters[i]);
                if (t == -1)
                {
                    test = false;
                    break;
                }

                scoring[i] = t;

            }

            if (test)
                result.Add((new int[] { scoring.Count(c => c == 0), scoring.Count(c => c == 1), scoring.Count(c => c == 2) }, factory));

        }

        private static void TestMethod(Type[] parameters, List<(int[], Factory)> result, Factory factory)
        {
            bool test = true;
            int[] scoring = new int[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                var t = ExpressionHelper.CanBeConverted(factory.Parameters[i + 1].ParameterType, parameters[i]);
                if (t == -1)
                {
                    test = false;
                    break;
                }

                scoring[i] = t;

            }

            if (test)
                result.Add((new int[] { scoring.Count(c => c == 0), scoring.Count(c => c == 1), scoring.Count(c => c == 2) }, factory));

        }

        private int Evaluate(Type parameterType, Type type)
        {

            if (parameterType == type)
                return 0;



            if (parameterType == typeof(long) && type == typeof(int))
                return 1;

            if (parameterType == typeof(double) && type == typeof(float))
                return 1;

            if (parameterType == typeof(int) && type == typeof(long))
                return 2;

            if (parameterType == typeof(float) && type == typeof(double))
                return 2;

            if (parameterType.IsAssignableFrom(type))
                return 2;

            return -1;


        }

        private List<Factory> _instances = new List<Factory>();

    }

}
