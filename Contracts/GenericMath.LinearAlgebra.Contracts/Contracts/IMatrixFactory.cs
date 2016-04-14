// *************************************************************
// <copyright file="IMatrixFactory.cs" company="None">
//      Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>AndreasAugustin</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;
using System;

namespace GenericMath.LinearAlgebra.Contracts
{
    /// <summary>
    /// Interface for factory for <see cref="IMatrix{TSet, TStruct}"/> instances.
    /// </summary>
    public interface IMatrixFactory : IFactoryMarker
    {
        #region methods

        /// <summary>
        /// Gets a new instance for the reigstered type..
        /// </summary>
        /// <returns>The instance.</returns>
        /// <typeparam name="TStruct">The structure to register.</typeparam>
        /// <exception cref="UnregisteredException">
        ///  Thrown when the instance
        ///  <typeparamref>TStruct</typeparamref> is not registered yet.
        /// </exception>
        TMatrix GetNewInstance<TSet, TStructure, TMatrix> (uint rowDimension, uint columnDimension) 
            where TStructure : IStructure, new()
            where TMatrix : IMatrix<TSet, TStructure>;

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <param name = "expr">Expression which returns a new instance.
        /// <example>
        /// (rowDimension, columnDimension) => {return new Matrix(rowDimension, columnDimension)}
        /// </example>
        /// </param>
        /// <typeparam name="TStruct">The 1st type parameter.</typeparam>
        void Register<TSet, TStructure, TMatrix> (Func<uint,uint, TMatrix> expr) 
            where TStructure : IStructure, new()
            where TMatrix : IMatrix<TSet, TStructure>;

        #endregion
    }
}
