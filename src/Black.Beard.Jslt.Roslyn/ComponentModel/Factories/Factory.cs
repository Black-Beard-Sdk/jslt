using System;

namespace Bb.ComponentModel.Factories
{

    /// <summary>
    /// Factory of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Factory<T> : IFactory<T>
        where T : class
    {

        private readonly ObjectActivator<T> factory;

        /// <summary>
        /// Initializes a new instance of the type <see cref="Factory{T}" /> class. The real type instance is the specified type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="types">The types.</param>
        public Factory(Type type, Type[] types)
        {
            var ctor = type.GetConstructor(types);
            if (ctor != null)
                factory = ObjectCreator.GetActivator<T>(ctor);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory{T}"/> class.
        /// </summary>
        /// <param name="types">The types.</param>
        public Factory(params Type[] types)
        {
            var ctor = typeof(T).GetConstructor(types);
            if (ctor != null)
                factory = ObjectCreator.GetActivator<T>(ctor);

        }

        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public T Create(params dynamic[] args)
        {
            return factory(args);
        }

        public bool IsEmpty => factory == null;

    }

}
