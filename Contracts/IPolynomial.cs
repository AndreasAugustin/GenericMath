//  *************************************************************
// <copyright file="IPolynomial.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  23 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

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

        /// <summary>
        /// Gets the coefficients.
        /// </summary>
        /// <value>The coefficients.</value>
        IVector<T, TStruct> Coefficients { get; }

        #endregion

        #region methods

        /// <summary>
        /// Gets or sets the coefficients of <see cref="Polynomial{T, TStruct}"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the coefficient.</param>
        /// <returns>The coefficient at the specified index.</returns>
        T this[UInt32 index] { get; set; }

        /// <summary>
        /// Returns a new the instance with same degree like the calling instance.
        /// </summary>
        /// <returns>The instance with same dimension.</returns>
        IPolynomial<T, TStruct> ReturnNewInstanceWithSameDegree();

        /// <summary>
        /// Returns a new the instance with other coefficients like the calling instance.
        /// </summary>
        /// <returns>The instance with other coefficients.</returns>
        /// <param name="coefficients">The other coefficients.</param>
        IPolynomial<T, TStruct> ReturnNewInstanceWithOtherCoefficients(IVector<T, TStruct> coefficients);

        /// <summary>
        /// Returns the new instance with same coefficients.
        /// </summary>
        /// <returns>The new instance with same coefficients.</returns>
        IPolynomial<T, TStruct> ReturnNewInstanceWithSameCoefficients();

        #endregion
    }
}