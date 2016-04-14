//  *************************************************************
// <copyright file="SpecialMatrices.cs" company="None">
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

	/// <summary>
	/// Special matrices.
	/// </summary>
	public class SpecialMatrices
	{
		#region METHODS

		/// <summary>
		/// Creates a matrix with Zero as elements.
		/// </summary>
		/// <returns>The matrix.</returns>
		/// <param name="dimension">The dimension.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		/// <typeparam name="TGroup">The underlying structure.</typeparam>
		public Matrix<T, TGroup> ZeroMatrix<T, TGroup> (UInt32 dimension)
            where TGroup : IGroup<T>, new()
		{
			return this.ZeroMatrix<T, TGroup>(dimension, dimension);
		}

		/// <summary>
		/// Creates a matrix with Zero as elements.
		/// </summary>
		/// <returns>The matrix.</returns>
		/// <param name="rowDimension">Row dimension.</param>
		/// <param name="columnDimension">Column dimension.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		/// <typeparam name="TGroup">The underlying structure.</typeparam>
		public Matrix<T, TGroup> ZeroMatrix<T, TGroup> (
			UInt32 rowDimension,
			UInt32 columnDimension)
            where TGroup : IGroup<T>, new()
		{
			var matrix = new Matrix<T, TGroup> (rowDimension, columnDimension);
			var group = new TGroup ();

			for (UInt32 i = 0; i < rowDimension; i++) {
				for (UInt32 j = 0; j < columnDimension; j++) {
					matrix [i, j] = group.Zero;
				}
			}

			return matrix;
		}

		/// <summary>
		/// Creates the one matrix.
		/// </summary>
		/// <param name="dimension">The dimension.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		/// <typeparam name="TRing">The underlying structure.</typeparam>
		/// <returns>The one matrix with dimension n.</returns>
		public Matrix<T, TRing> OneMatrix<T, TRing> (UInt32 dimension)
            where TRing : IRing<T>, new()
		{
			var mat = new Matrix<T, TRing> (dimension);

			var ring = new TRing ();

			for (UInt32 i = 0; i < mat.RowDimension; i++) {
				for (UInt32 j = 0; j < mat.ColumnDimension; j++) {
					if (i == j) {
						mat [i, i] = ring.One;
						continue;
					}

					mat [i, j] = ring.Zero;
				}
			}

			return mat;
		}

		#endregion
	}
}