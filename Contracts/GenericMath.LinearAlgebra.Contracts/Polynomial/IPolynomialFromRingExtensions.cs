//  *************************************************************
// <copyright file="IPolynomialFromRingExtensions.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;
using GenericMath.LinearAlgebra.Contracts;

namespace GenericMath.LinearAlgebra.Contracts
{
	using System;

	using GenericMath.Base;

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
		/// <typeparam name="TRing">The underlying structure.</typeparam>
		public static IPolynomial<T, TRing> Pow<T, TRing> (
			this IPolynomial<T, TRing> polynomial,
			UInt32 power)
            where TRing : IRing<T>, new()
		{
			var result = polynomial.Copy();

			for (UInt32 i = 0; i < power - 1; i++) {
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
		/// <typeparam name="TRing">The underlying structure.</typeparam>
		/// <returns>The product of polynomial1 and polynomial2.</returns>
		public static IPolynomial<T, TRing> Multiply<T, TRing> (
			this IPolynomial<T, TRing> polynomial1,
			IPolynomial<T, TRing> polynomial2)
            where TRing : IRing<T>, new()
		{
			var degree = polynomial1.Degree + polynomial2.Degree;

			var poly = polynomial1.ReturnNewInstance(degree);
			var max = Math.Max(polynomial1.Degree, polynomial2.Degree);
			var baseStructure = new TRing ();

			T x;
			for (UInt32 i = 0; i < degree + 1; i++) {
				x = baseStructure.Zero;
				var start = i <= max ? 0 : i - max;
				var end = i < max ? Math.Min(i, max) + 1 : Math.Min(i, max);

				for (UInt32 j = start; j < end + 1; j++) {
					var k = i - j;
					var factor1 = polynomial1.Degree >= j ? polynomial1 [j] : baseStructure.One;
					var factor2 = polynomial2.Degree >= k ? polynomial2 [k] : baseStructure.One;
					x = baseStructure.Addition(
						x,
						baseStructure.Multiplication(factor1, factor2));
				}

				poly [i] = x;
			}

			return poly;
		}

		/// <summary>
		/// Calculate the specified polynomial with the value x.
		/// </summary>
		/// <param name="polynomial">The polynomial.</param>
		/// <param name="x">The x coordinate.</param>
		/// <typeparam name="T">The type parameter.</typeparam>
		/// <typeparam name="TRing">The underlying structure.</typeparam>
		/// <returns>The point calculation for the polynomial.</returns>
		public static T Calculate<T, TRing> (
			this IPolynomial<T, TRing> polynomial,
			T x)
            where TRing : IRing<T>, new()
		{
			var ring = new TRing ();
			T result = ring.Zero;

			for (UInt32 i = 0; i <= polynomial.Degree; i++) {
				var calculatedCoefficient = ring.Multiplication(
					                            ring.Pow(x, i),
					                            polynomial [i]);
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
		/// <typeparam name="TRing">The underlying structure.</typeparam>
		public static IPolynomial<T, TRing> ScalarMultiply<T, TRing> (
			this IPolynomial<T, TRing> polynomial,
			T scalar)
            where TRing : IRing<T>, new()
		{
			var poly = polynomial.ReturnNewInstance(polynomial.Degree);
			var degree = polynomial.Degree;
			var structure = new TRing ();

			for (UInt32 i = 0; i < degree; i++) {
				poly [i] = structure.Multiplication(scalar, polynomial [i]);
			}

			return poly;
		}

		#endregion
	}
}