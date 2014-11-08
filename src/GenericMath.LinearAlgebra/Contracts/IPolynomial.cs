//  *************************************************************
// <copyright file="IPolynomial.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra
{
    using System;

    using GenericMath.Base;

    /// <summary>
    /// Interface for the polynomial.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    public interface IPolynomial<T, TStruct> 
        where TStruct : IStructure<T>, new()
    {
        #region properties

        /// <summary>
        /// Gets the degree of the polynomial.
        /// </summary>
        /// <value>The degree.</value>
        UInt32 Degree { get; }

        #endregion

        #region methods

        /// <summary>
        /// Gets or sets the coefficients of <see cref="Polynomial{T, TStruct}"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the coefficient.</param>
        /// <returns>The coefficient at the specified index.</returns>
        T this[UInt32 index] { get; set; }

        /// <summary>
        /// Returns a new the instance with degree set as parameter.
        /// </summary>
        /// <returns>The instance with same dimension.</returns>
        /// <param name="degree">The degree of the new instance.</param>
        IPolynomial<T, TStruct> ReturnNewInstance(UInt32 degree);

        #endregion
    }
}