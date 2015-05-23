// *************************************************************
// <copyright file="MatrixFactory.cs" company="None">
//      Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>AndreasAugustin</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra
{
    using System;
    using System.Collections.Generic;

    using GenericMath.Base.Contracts;
    using GenericMath.LinearAlgebra.Contracts;

    /// <summary>
    /// Factory for creating <see cref="IMatrix{TSect, TStruct}"/>  instances.
    /// </summary>
    public class MatrixFactory : IMatrixFactory
    {

        #region fields

        private Dictionary<Type, object> _mappingDict = new Dictionary<Type, object>();

        #endregion

        #region methods

        /// <summary>
        /// Gets a new instance for the reigstered type..
        /// </summary>
        /// <returns>The instance.</returns>
        /// <param name="rowDimension">Row dimension.</param>
        /// <param name="columnDimension">Column dimension.</param>
        /// <typeparam name="TSet">The 1st type parameter.</typeparam>
        /// <typeparam name="TStructure">The 2nd type parameter.</typeparam>
        /// <typeparam name="TMatrix">The 3rd type parameter.</typeparam>
        public TMatrix GetNewInstance<TSet, TStructure, TMatrix> (uint rowDimension, uint columnDimension) 
            where TStructure : IStructure, new() 
            where TMatrix : IMatrix<TSet, TStructure>
        {
            if (!this._mappingDict.ContainsKey(typeof(TMatrix))) {
                throw new UnregisteredException(string.Format("The type {0}, is not registered yet.", typeof(TMatrix)));
            }

            return ((Func<uint, uint, TMatrix>)this._mappingDict[typeof(TMatrix)])(rowDimension, columnDimension);
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <param name="expr">Expr.</param>
        /// <typeparam name="TSet">The 1st type parameter.</typeparam>
        /// <typeparam name="TStructure">The 2nd type parameter.</typeparam>
        /// <typeparam name="TMatrix">The 3rd type parameter.</typeparam>
        public void Register<TSet, TStructure, TMatrix> (Func<uint, uint, TMatrix> expr) 
            where TStructure : IStructure, new() 
            where TMatrix : IMatrix<TSet, TStructure>
        {
            this._mappingDict.Add(typeof(TMatrix), expr);
        }

        #endregion
        
    }
}
