//  *************************************************************
// <copyright file="PolynomialFromGroupExtensions.cs" company="${Company}">
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
    public static class PolynomialFromGroupExtensions
    {
        #region methods

        /// <summary>
        /// Inverses the polynomial.
        /// </summary>
        /// <returns>The polynomial.</returns>
        /// <param name="polynomial">The given polynomial.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The second type parameter.</typeparam>
        public static Polynomial<T, TStruct> InversPolynomial<T, TStruct>(this Polynomial<T, TStruct> polynomial)
            where TStruct : IGroup<T>, new()
        {
            var poly = new Polynomial<T, TStruct>(polynomial.Degree);

            for (UInt32 i = 0; i <= polynomial.Degree; i++)
            {
                poly[i] = polynomial.BaseStructure.Inverse(polynomial[i]);
            }

            return poly;
        }

        #endregion
    }
}