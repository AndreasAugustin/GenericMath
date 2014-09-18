//  *************************************************************
// <copyright file="IPolynomialFromGroupExtensions.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  20 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

    /// <summary>
    /// Polynomial from group extensions.
    /// </summary>
    public static class IPolynomialFromGroupExtensions
    {
        #region methods

        /// <summary>
        /// Inverses the polynomial.
        /// </summary>
        /// <returns>The polynomial.</returns>
        /// <param name="polynomial">The given polynomial.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The second type parameter.</typeparam>
        public static IPolynomial<T, TStruct> InversePolynomial<T, TStruct>(this IPolynomial<T, TStruct> polynomial)
            where TStruct : IGroup<T>, new()
        {
            var poly = polynomial.ReturnNewInstance(polynomial.Degree);
            var baseStructure = new TStruct();

            for (UInt32 i = 0; i <= polynomial.Degree; i++)
            {
                poly[i] = baseStructure.Inverse(polynomial[i]);
            }

            return poly;
        }

        #endregion
    }
}