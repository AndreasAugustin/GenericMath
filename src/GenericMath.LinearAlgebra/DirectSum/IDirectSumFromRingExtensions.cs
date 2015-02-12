//  *************************************************************
// <copyright file="IDirectSumFromRingExtensions.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;

namespace GenericMath.LinearAlgebra
{
	using System;

	using GenericMath.Base;

	/// <summary>
	/// Extension methods for the <see cref="DirectSum{T, IStructure}"/> class.
	/// </summary>
	public static class IDirectSumFromRingExtensions
	{
		#region methods

		/// <summary>
		/// Point multiplication of vector1 and vector2.
		/// The dimensions must agree.
		/// </summary>
		/// <param name="tuple1">The left vector.</param>
		/// <param name="tuple2">The right.</param>
		/// <typeparam name="T">The type parameter.</typeparam>
		/// <typeparam name="TRing">The underlying structure.</typeparam>
		/// <returns>The multiplication vector1 * vector2.</returns>
		public static IDirectSum<T, TRing> Multiply<T, TRing> (
			this IDirectSum<T, TRing> tuple1,
			IDirectSum<T, TRing> tuple2)
            where TRing : IRing<T>, new()
		{
			if (tuple1.Dimension != tuple2.Dimension) {
				// TODO throw right exception
				throw new IndexOutOfRangeException ("The vector dimensions need to agree");
			}
                
			var ring = new TRing ();

			var result = tuple1.ReturnNewInstance (tuple1.Dimension);

			for (UInt32 i = 0; i < tuple1.Dimension; i++) {
				result [i] = ring.Multiplication (tuple1 [i], tuple2 [i]);
			}

			return result;
		}

		/// <summary>
		/// Multiplies the vector power times.
		/// Multiplies the vector with itself power times.
		/// </summary>
		/// <param name="tuple">The vector.</param>
		/// <param name="power">The power.</param>
		/// <typeparam name="T">The type parameter.</typeparam>
		/// <typeparam name="TRing">The underlying structure.</typeparam>
		/// <returns>The vector^power.</returns>
		public static IDirectSum<T, TRing> Pow<T, TRing> (
			this IDirectSum<T, TRing> tuple,
			UInt32 power)
            where TRing : IRing<T>, new()
		{
			var result = tuple.ReturnNewInstance (tuple.Dimension);
			var ring = new TRing ();

			for (UInt32 i = 0; i < result.Dimension; i++) {
				result [i] = ring.One;
			}

			for (UInt32 i = 0; i < power; i++) {
				result = tuple.Multiply (result);
			}

			return result;
		}

		/// <summary>
		/// Calculates the scalar product of two vectors.
		/// </summary>
		/// <returns>The product.</returns>
		/// <param name="vector1">The left vector.</param>
		/// <param name="vector2">The right vector.</param>
		/// <typeparam name="T">The type parameter.</typeparam>
		/// <typeparam name="TStruct">The underlying structure.</typeparam>
		public static T ScalarProduct<T, TStruct> (
			this IDirectSum<T, TStruct> vector1,
			IDirectSum<T, TStruct> vector2)
            where TStruct : IRing<T>, new()
		{
			var ring = new TStruct ();

			var result = ring.Zero;

			for (UInt32 i = 0; i < vector1.Dimension; i++) {
				result = ring.Addition (
					result,
					ring.Multiplication (vector1 [i], vector2 [i]));           
			}

			return result;
		}

		/// <summary>
		/// Multiplies a scalar lambda with a vector v.
		/// </summary>
		/// <returns>lambda * v.</returns>
		/// <param name="tuple">The vector.</param>
		/// <param name="scalar">The scalar.</param>
		/// <typeparam name="T">The type parameter.</typeparam>
		/// <typeparam name="TRing">The underlying structure.</typeparam>
		public static IDirectSum<T, TRing> ScalarMultiply<T, TRing> (
			this IDirectSum<T, TRing> tuple,
			T scalar)
            where TRing : IRing<T>, new()
		{
			var ring = new TRing ();
			var vec = tuple.ReturnNewInstance (tuple.Dimension);

			for (UInt32 i = 0; i < tuple.Dimension; i++) {
				vec [i] = ring.Multiplication (scalar, tuple [i]);
			}

			return vec;
		}

		#endregion
	}
}