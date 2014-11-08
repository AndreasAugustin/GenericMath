//  *************************************************************
// <copyright file="IPolynomialExtensions.cs" company="None">
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
    /// Extension methods for the <see cref="Polynomial{T, TStruct}"/> class.
    /// </summary>
    public static class IPolynomialExtensions
    {
        #region methods

        /// <summary>
        /// Copy the specified polynomial.
        /// </summary>
        /// <returns>A copy of the polynomial.</returns>
        /// <param name="polynomial">The polynomial.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IPolynomial<T, TStruct> Copy<T, TStruct>(this IPolynomial<T, TStruct> polynomial)
            where TStruct : IStructure<T>, new()
        {
            var poly = polynomial.ReturnNewInstance(polynomial.Degree);

            for (UInt32 i = 0; i < polynomial.Degree + 1; i++)
            {
                poly[i] = polynomial[i];
            }

            return poly;
        }

        #endregion
    }
}