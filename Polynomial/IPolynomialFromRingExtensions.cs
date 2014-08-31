//  *************************************************************
// <copyright file="IPolynomialFromRingExtensions.cs" company="${Company}">
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
    /// Polynomial from ring extensions.
    /// </summary>
    public static class IPolynomialFromRingExtensions
    {
        #region methods

        /// <summary>
        /// Multiply the polynomial power times.
        /// </summary>
        /// <returns>The power of the polynomial.</returns>
        /// <param name="polynomial">The polynomial.</param>
        /// <param name="power">The power.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IPolynomial<T, TStruct> Pow<T, TStruct>(this IPolynomial<T, TStruct> polynomial, UInt32 power)
            where TStruct : IRing<T>, new()
        {
            var result = polynomial.Copy();
            var baseStructure = new TStruct();

            for (UInt32 i = 0; i < power - 1; i++)
            {
                result = result.Multiply(polynomial);
            }

            return result;
        }

        /// <summary>
        /// Multiply the specified polynomial1 and polynomial2.
        /// </summary>
        /// <param name="polynomial1">The left polynomial.</param>
        /// <param name="polynomial2">The right polynomial.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>The product of polynomial1 and polynomial2.</returns>
        public static IPolynomial<T, TStruct> Multiply<T, TStruct>(this IPolynomial<T, TStruct> polynomial1, IPolynomial<T, TStruct> polynomial2)
            where TStruct : IRing<T>, new()
        {
            var degree = polynomial1.Degree + polynomial2.Degree;

            var poly = polynomial1.ReturnNewInstanceWithSameDegree();
            var max = Math.Max(polynomial1.Degree, polynomial2.Degree);
            var baseStructure = new TStruct();

            T x;
            for (UInt32 i = 0; i <= degree; i++)
            {
                x = baseStructure.Zero;
                var start = i <= max ? 0 : i - max;
                var end = i < max ? Math.Min(i, max) + 1 : Math.Min(i, max);

                for (UInt32 j = start; j < end; j++)
                {
                    var k = i - j;
                    var factor1 = polynomial1.Degree >= j ? polynomial1[j] : baseStructure.One;
                    var factor2 = polynomial2.Degree >= k ? polynomial2[k] : baseStructure.One;
                    x = baseStructure.Addition(x, baseStructure.Multiplication(factor1, factor2));
                }

                poly[i] = x;
            }

            return poly;
        }

        /// <summary>
        /// Calculate the specified polynomial with the value x.
        /// </summary>
        /// <param name="polynomial">The polynomial.</param>
        /// <param name="x">The x coordinate.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>The point calculation for the polynomial.</returns>
        public static T Calculate<T, TStruct>(this IPolynomial<T, TStruct> polynomial, T x)
            where TStruct : IRing<T>, new()
        {
            var ring = new TStruct();
            T result = ring.Zero;

            for (UInt32 i = 0; i <= polynomial.Degree; i++)
            {
                var calculatedCoefficient = ring.Multiplication(ring.Pow(x, i), polynomial[i]);
                result = ring.Addition(result, calculatedCoefficient);
            }

            return result;
        }

        /// <summary>
        /// Multiplies the polynomial with a scalar.
        /// </summary>
        /// <returns>The multiplication scalar * polynomial.</returns>
        /// <param name="polynomial">The polynomial.</param>
        /// <param name="scalar">The scalar.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IPolynomial<T, TStruct> ScalarMultiply<T, TStruct>(this IPolynomial<T, TStruct> polynomial, T scalar)
            where TStruct : IRing<T>, new()
        {
            return polynomial.ReturnNewInstanceWithOtherCoefficients(polynomial.Coefficients.ScalarMultiply(scalar));
        }

        #endregion
    }
}