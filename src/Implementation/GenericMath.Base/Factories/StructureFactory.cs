// *************************************************************
// <copyright file="StructureFactory.cs" company="None">
//      Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>AndreasAugustin</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base
{
    using GenericMath.Base.Contracts;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Factory for creating <see cref="IStructure"/> references.
    /// </summary>
    public class StructureFactory : IStructureFactory
    {
        #region fields

        private Dictionary<Type, IStructure> _structureDictionary;

        #endregion

        #region properties

        private Dictionary<Type, IStructure> StructureDictionary
        {
            get
            {
                return this._structureDictionary ?? (this._structureDictionary = new Dictionary<Type, IStructure>());
            }
        }

        #endregion

        #region IStructureFactory implementation

        /// <summary>
        /// Gets the registered instance.
        /// </summary>
        /// <returns>The instance.</returns>
        /// <typeparam name="TStruct">The structure to register.</typeparam>
        public TStruct GetInstance<TStruct> () where TStruct : IStructure
        {
            if (!this.StructureDictionary.ContainsKey(typeof(TStruct))) {
                throw new UnregisteredException(string.Format("The structure {0} has not been registered yet.", typeof(TStruct).Name));
            }

            return (TStruct)this.StructureDictionary[typeof(TStruct)];
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <param name="structure">Structure.</param>
        /// <typeparam name="TStruct">The 1st type parameter.</typeparam>
        public void RegisterInstance<TStruct> (TStruct structure) where TStruct : IStructure, new()
        {
            this.StructureDictionary.Add(typeof(TStruct), structure);
        }

        #endregion
    }
}
