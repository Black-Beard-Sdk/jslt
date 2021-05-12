using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Permet de retourner la liste des methodes d'evaluation disponibles dans les types fournis.
    /// </summary>
    public interface IMethodDiscovery
    {

        /// <summary>
        /// Return list of method for the specified arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="returnType"></param>
        /// <param name="methodSign">if null no check will do on arguments</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">returnType</exception>
        /// <exception cref="ArgumentNullException">methodSign</exception>
        IEnumerable<BusinessAction<T>> GetActions<T>(BindingFlags bindings, Type returnType, List<Type> methodSign); //where T : Context;

    }

}