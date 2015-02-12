//  *************************************************************
// <copyright file="IMatrixSquaredExtensions.cs" company="None">
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
	using System.Collections.Generic;

	using GenericMath.Base;

	/// <summary>
	/// Matrix squared extensions.
	/// </summary>
	public static class IMatrixSquaredExtensions
	{
		#region METHODS

		/// <summary>
		/// Calculates the trace of the matrix.
		/// </summary>
		/// <param name="matrix">The matrix.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		/// <typeparam name="TMonoid">The underlying structure.</typeparam>
		/// <returns>The trace of the matrix.</returns>
		public static T Trace<T, TMonoid> (this IMatrix<T, TMonoid> matrix)
            where TMonoid : IMonoid<T>, new()
		{
			CheckSquared (matrix);

			var baseStructure = new TMonoid ();
			var result = baseStructure.Zero;

			for (UInt32 i = 0; i < matrix.RowDimension; i++) {
				result = baseStructure.Addition (result, matrix [i, i]);
			}

			return result;
		}

		#endregion

		#region helper methods

		private static void CheckSquared<T, TStruct> (this IMatrix<T, TStruct> matrix)
            where TStruct : IStructure<T>, new()
		{
			if (matrix.RowDimension != matrix.ColumnDimension) {
				throw new LinearAlgebraException (
					LinearAlgebraExceptionType.MatrixIsNotSquared,
					"The row and column dimension do not agree");
			}
		}

		#endregion
	}
}