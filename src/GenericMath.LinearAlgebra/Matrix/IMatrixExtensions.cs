//  *************************************************************
// <copyright file="IMatrixExtensions.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra
{
    using System;

    using GenericMath.Base;

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
        public static DirectSum<T, TStruct> GetColumnVector<T, TStruct>(
            this IMatrix<T, TStruct> matrix,
            UInt32 columnIndex)
            where TStruct : IStructure<T>, new()
        {
            if (columnIndex >= matrix.ColumnDimension)
            {
                throw new LinearAlgebraException(
                    LinearAlgebraExceptionType.IndexEqualOrGreaterDimension,
                    "The indx is not right");
            }
                
            var rowDimension = matrix.RowDimension;
            var tuple = new DirectSum<T, TStruct>(rowDimension);

            for (UInt32 i = 0; i < rowDimension; i++)
            { 
                tuple[i] = matrix[i, columnIndex];
            }

            return tuple;
        }

        /// <summary>
        /// Gets the row vector at row rowIndex.
        /// </summary>
        /// <returns>The column vector.</returns>
        /// <param name="matrix">The matrix.</param>
        /// <param name="rowIndex">Column index.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static DirectSum<T, TStruct> GetRowVector<T, TStruct>(
            this IMatrix<T, TStruct> matrix,
            UInt32 rowIndex)
            where TStruct : IStructure<T>, new()
        {
            if (rowIndex >= matrix.RowDimension)
            {
                throw new LinearAlgebraException(
                    LinearAlgebraExceptionType.IndexEqualOrGreaterDimension,
                    "The indx is not right");
            }

            var columnDimension = matrix.ColumnDimension;
            var tuple = new DirectSum<T, TStruct>(columnDimension);

            for (UInt32 j = 0; j < columnDimension; j++)
            { 
                tuple[j] = matrix[rowIndex, j];
            }

            return tuple;
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
            var result = matrix.ReturnNewInstance(
                             matrix.ColumnDimension,
                             matrix.RowDimension); // n x m Matrix -> m x n - Matrix

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
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure of the set.</typeparam>
        /// <returns>A copy of the matrix.</returns>
        public static IMatrix<T, TStruct> Copy<T, TStruct>(this IMatrix<T, TStruct> matrix)
            where TStruct : IStructure<T>, new()
        {
            var mat = matrix.ReturnNewInstance(
                          matrix.RowDimension,
                          matrix.ColumnDimension);

            for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
            {
                for (UInt32 i = 0; i < matrix.RowDimension; i++)
                {
                    mat[i, j] = matrix[i, j];
                }
            }

            return mat;
        }

        /// <summary>
        /// Swaps the specified rows at index <para>firstRowIndex</para> and <para>secondRowIndex</para> in the matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="firstRowIndex">The first row index.</param>
        /// <param name="secondRowIndex">The second row index.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure of the set.</typeparam>
        /// <returns>A copy of the matrix.</returns>
        public static IMatrix<T, TStruct> SwapRows<T, TStruct>(
            this IMatrix<T, TStruct> matrix,
            UInt32 firstRowIndex,
            UInt32 secondRowIndex)
            where TStruct : IStructure<T>, new()
        {
            var mat = matrix.ReturnNewInstance(
                          matrix.RowDimension,
                          matrix.ColumnDimension);

            for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
            {
                for (UInt32 i = 0; i < matrix.RowDimension; i++)
                {
                    if (i == firstRowIndex)
                    {
                        mat[secondRowIndex, j] = matrix[i, j];
                    }

                    if (i == secondRowIndex)
                    {
                        mat[firstRowIndex, j] = matrix[i, j];
                    }

                    if (i != firstRowIndex && i != secondRowIndex)
                    {
                        mat[i, j] = matrix[i, j];
                    }
                }
            }

            return mat;
        }

        /// <summary>
        /// Swaps the specified columns at index <para>firstColumnIndex</para> and <para>secondColumnIndex</para> in the matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="firstColumnIndex">The first column index.</param>
        /// <param name="secondColumnIndex">The second column index.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure of the set.</typeparam>
        /// <returns>A copy of the matrix.</returns>
        public static IMatrix<T, TStruct> SwapColumns<T, TStruct>(
            this IMatrix<T, TStruct> matrix,
            UInt32 firstColumnIndex,
            UInt32 secondColumnIndex)
            where TStruct : IStructure<T>, new()
        {
            var mat = matrix.ReturnNewInstance(
                          matrix.RowDimension,
                          matrix.ColumnDimension);

            for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
            {
                for (UInt32 i = 0; i < matrix.RowDimension; i++)
                {
                    if (i == firstColumnIndex)
                    {
                        mat[secondColumnIndex, j] = matrix[i, j];
                    }

                    if (i == secondColumnIndex)
                    {
                        mat[firstColumnIndex, j] = matrix[i, j];
                    }

                    if (i != firstColumnIndex && i != secondColumnIndex)
                    {
                        mat[i, j] = matrix[i, j];
                    }
                }
            }

            return mat;
        }

        #endregion
    }
}
