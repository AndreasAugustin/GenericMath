//  *************************************************************
// <copyright file="IMatrixSquaredExtensions.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra.Contracts
{
    using System;

    using GenericMath.Base.Contracts;
    using GenericMath.LinearAlgebra.Contracts;

	/// <summary>
	/// Matrix squared extensions.
	/// </summary>
	public static class ISquaredMatrixExtensions
	{
		#region METHODS

		/// <summary>
		/// Calculates the trace of the matrix.
		/// </summary>
		/// <param name="matrix">The matrix.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		/// <typeparam name="TMonoid">The underlying structure.</typeparam>
		/// <returns>The trace of the matrix.</returns>
		public static T Trace<T, TMonoid> (this ISquaredMatrix<T, TMonoid> matrix)
            where TMonoid : IMonoid<T>, new()
		{
			var baseStructure = new TMonoid ();
			var result = baseStructure.Zero;

			for (UInt32 i = 0; i < matrix.RowDimension; i++) {
				result = baseStructure.Addition(result, matrix [i, i]);
			}

			return result;
		}

		#endregion
	}
}