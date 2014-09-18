﻿//  *************************************************************
// <copyright file="IMatrixExtensions.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  17 / 7 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

    /// <summary>
    /// Extension methods for the matrix class. <see cref="Matrix{T, TStruct}"/> class.
    /// </summary>
    public static class IMatrixExtensions
    {
        #region METHODS

        /// <summary>
        /// Gets the column vector at column columnIndex.
        /// </summary>
        /// <returns>The row vector.</returns>
        /// <param name="matrix">The matrix.</param>
        /// <param name ="columnIndex">The column index.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IDirectSum<T, TStruct> GetColumnVector<T, TStruct>(this IMatrix<T, TStruct> matrix, UInt32 columnIndex)
            where TStruct : IStructure<T>, new()
        {
            return matrix[columnIndex];
        }

        /// <summary>
        /// Gets the row vector at row rowIndex.
        /// </summary>
        /// <returns>The column vector.</returns>
        /// <param name="matrix">The matrix.</param>
        /// <param name="rowIndex">Column index.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IDirectSum<T, TStruct> GetRowVector<T, TStruct>(this IMatrix<T, TStruct> matrix, UInt32 rowIndex)
            where TStruct : IStructure<T>, new()
        {
            var underlyingVector = matrix[rowIndex];
            var vec = underlyingVector.ReturnNewInstance(underlyingVector.Dimension);

            for (UInt32 i = 0; i < matrix.RowDimension; i++)
            {
                vec[i] = matrix[i][rowIndex];
            }

            return vec;
        }

        /// <summary>
        /// Transpose the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>The transposed matrix.</returns>
        public static IMatrix<T, TStruct> Transpose<T, TStruct>(this IMatrix<T, TStruct> matrix)
            where TStruct : IStructure<T>, new()
        {
            var result = matrix.ReturnNewInstanceWithTwistedDimensions(); // n x m Matrix -> m x n - Matrix

            for (UInt32 i = 0; i < matrix.RowDimension; i++)
            {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Copy the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>A copy of the matrix.</returns>
        public static IMatrix<T, TStruct> Copy<T, TStruct>(this IMatrix<T, TStruct> matrix)
            where TStruct : IStructure<T>, new()
        {
            var mat = matrix.ReturnNewInstanceWithSameDimensions();

            for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
            {
                mat[j] = matrix[j].Copy();
            }

            return mat;
        }

        #endregion
    }
}
