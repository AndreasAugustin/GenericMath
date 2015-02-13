//  *************************************************************
// <copyright file="SpecialPolynomials.cs" company="None">
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
	/// Special polynomials.
	/// </summary>
	public class SpecialPolynomials
	{
		#region methods

		/// <summary>
		/// Creates the zeros polynomial for dimension.
		/// </summary>
		/// <returns>The polynomial.</returns>
		/// <param name="degree">The dimension.</param>
		/// <typeparam name="T">The type parameter.</typeparam>
		/// <typeparam name="TGroup">The underlying structure.</typeparam>
		public Polynomial<T, TGroup> ZeroPolynomial<T, TGroup> (UInt32 degree)
            where TGroup : IGroup<T>, new()
		{
			var poly = new Polynomial<T, TGroup> (degree);
			var group = new TGroup ();

			for (UInt32 i = 0; i < degree; i++) {
				poly [i] = group.Zero;
			}

			return poly;
		}

		/// <summary>
		/// Creates the one polynomial for dimension.
		/// </summary>
		/// <returns>The polynomial.</returns>
		/// <param name="degree">The dimension.</param>
		/// <typeparam name="T">The type parameter.</typeparam>
		/// <typeparam name="TRing">The underlying structure.</typeparam>
		public Polynomial<T, TRing> OnePolynomial<T, TRing> (UInt32 degree)
            where TRing : IRing<T>, new()
		{
			var poly = new Polynomial<T, TRing> (degree);
			var ring = new TRing ();

			for (UInt32 i = 1; i < degree; i++) {
				poly [i] = ring.Zero;
			}

			poly [0] = ring.One;

			return poly;
		}

		#endregion
	}
}