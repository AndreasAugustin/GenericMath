//  *************************************************************
// <copyright file="IMatrixFromMonoidExtensions.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;
using GenericMath.LinearAlgebra.Contracts;

namespace GenericMath.LinearAlgebra
{
	using System;

	using GenericMath.Base;

	/// <summary>
	/// Extensions methods for the <see cref="Matrix{T, TStruct}"/> class.
	/// TStruct needs to be of type <see cref="IMonoid{T}"/>
	/// </summary>
	public static class IMatrixFromMonoidExtensions
	{
		#region methods

		/// <summary>
		/// Add the specified leftMatrix and rightMatrix.
		/// </summary>
		/// <param name="leftMatrix">The left matrix.</param>
		/// <param name="rightMatrix">The right matrix.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		/// <typeparam name="TGroup">The underlying structure.</typeparam>
		/// <returns>The addition of left and right matrices.</returns>
		public static IMatrix<T, TGroup> Add<T, TGroup> (
			this IMatrix<T, TGroup> leftMatrix,
			IMatrix<T, TGroup> rightMatrix)
            where TGroup : IGroup<T>, new()
		{
			if (leftMatrix.ColumnDimension != rightMatrix.ColumnDimension) {
				throw new NotSupportedException ("The column dimension of the matrizes need to agree");
			}
                
			if (leftMatrix.RowDimension != rightMatrix.RowDimension) {
				throw new NotSupportedException ("The row dimension of the matrizes need to agree");
			}
                
			var result = leftMatrix.ReturnNewInstance(
				             leftMatrix.RowDimension,
				             leftMatrix.ColumnDimension);
			var group = new TGroup ();

			for (UInt32 j = 0; j < leftMatrix.ColumnDimension; j++) {
				for (UInt32 i = 0; i < leftMatrix.RowDimension; i++) {
					result [i, j] = group.Addition(
						leftMatrix [i, j],
						rightMatrix [i, j]);
				}
			}

			return result;
		}

		/// <summary>
		/// Summarizes all elements in the matrix.
		/// </summary>
		/// <returns>The sum over all elements in the matrix.</returns>
		/// <param name="matrix">The matrix.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		/// <typeparam name="TGroup">The underlying structure.</typeparam>
		public static T SumElements<T, TGroup> (this IMatrix<T, TGroup> matrix)
            where TGroup : IGroup<T>, new()
		{   
			var group = new TGroup ();
			var result = group.Zero;

			for (UInt32 j = 0; j < matrix.ColumnDimension; j++) {
				for (UInt32 i = 0; i < matrix.RowDimension; i++) {
					result = group.Addition(result, matrix [i, j]);
				}
			}

			return result;
		}

		#endregion
	}
}