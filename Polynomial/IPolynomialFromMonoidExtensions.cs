//  *************************************************************
// <copyright file="PolynomialFromMonoidExtensions.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

    /// <summary>
    /// Extensions methods for the <see cref="Polynomial{T, TStruct}"/> class.
    /// TStruct needs to be of type <see cref="IMonoid{T}"/>
    /// </summary>
    public static class IPolynomialFromMonoidExtensions
    {
        #region methods

        /// <summary>
        /// Add the specified polynomial1 and polynomial2.
        /// </summary>
        /// <param name="polynomial1">The left polynomial.</param>
        /// <param name="polynomial2">The right polynomial.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>A new polynomial as a sum of polynomial1 and polynomial2.</returns>
        public static IPolynomial<T, TStruct> Add<T, TStruct>(this IPolynomial<T, TStruct> polynomial1, IPolynomial<T, TStruct> polynomial2)
            where TStruct : IMonoid<T>, new()
        {
            var degree = Math.Max(polynomial1.Degree, polynomial2.Degree);

            if (polynomial1.Degree < degree)
            {
                return polynomial1.ReturnNewInstanceWithOtherCoefficients(polynomial1.Coefficients
                    .Injection(degree - polynomial1.Degree).Add(polynomial2.Coefficients));
            }

            return polynomial1.ReturnNewInstanceWithOtherCoefficients(polynomial2.Coefficients
                .Injection(degree - polynomial2.Degree).Add(polynomial1.Coefficients));         
        }

        #endregion
    }
}