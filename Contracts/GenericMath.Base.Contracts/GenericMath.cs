// *************************************************************
// <copyright file="GenericMath.cs" company="None">
//      Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>AndreasAugustin</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base.Contracts
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Generic.
    /// </summary>
    public static class GenericMath
    {
        #region private fields

        private static Dictionary<Type,IFactoryMarker> _factoryDict = new Dictionary<Type, IFactoryMarker>();

        #endregion

        #region methods

        /// <summary>
        /// Registers the factory instance.
        /// </summary>
        /// <param name="instance">Instance.</param>
        /// <typeparam name="TFactory">The 1st type parameter.</typeparam>
        public static void RegisterFactoryInstance<TFactory> (TFactory instance) 
            where TFactory : IFactoryMarker
        {
            if (_factoryDict.ContainsKey(typeof(TFactory))) {
                _factoryDict[typeof(TFactory)] = instance;
                return;
            }
            _factoryDict.Add(typeof(TFactory), instance);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>The instance.</returns>
        /// <typeparam name="TFactory">The 1st type parameter.</typeparam>
        /// <exception cref="UnregisteredException">Thrown when the factory is not registered yet.</exception>
        public static TFactory GetInstance<TFactory> () 
            where TFactory : IFactoryMarker
        {
            if (!_factoryDict.ContainsKey(typeof(TFactory))) {
                throw new UnregisteredException(string.Format("The factory {0} is not registered yet", typeof(TFactory).Name));
            }
            return (TFactory)_factoryDict[typeof(TFactory)];
        }

        /// <summary>
        /// Cleans the factory dictionary.
        /// </summary>
        public static void CleanFactoryDictionary ()
        {
            _factoryDict = new Dictionary<Type, IFactoryMarker>();
        }

        #endregion
    }
}

