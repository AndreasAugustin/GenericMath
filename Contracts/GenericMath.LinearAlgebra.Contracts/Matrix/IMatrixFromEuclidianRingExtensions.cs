//  *************************************************************
// <copyright file="IMatrixFromEuclidianRingExtensions.cs" company="None">
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
    /// Extension methods for the <see cref="IMatrix{T, TStruct}"/> class 
    /// where TStruct is <see cref="IEuclidianRing{T}"/>
    /// </summary>
    public static class IMatrixFromEuclidianRingExtensions
    {
        #region methods

        /// <summary>
        /// Calculates the gauss jordan algorithm.
        /// </summary>
        /// <returns>The jordan algorithm.</returns>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TEuclidianRing">The underlying structure needs to be a <see cref="IEuclidianRing{T}"/>.</typeparam>
        public static IMatrix<T, TEuclidianRing> GaussJordanAlgorithm<T, TEuclidianRing> (this IMatrix<T, TEuclidianRing> matrix)
            where TEuclidianRing : IEuclidianRing<T>, new()
        {
            var matrixCopy = matrix.Copy();
            var min = Math.Min(matrix.RowDimension, matrix.ColumnDimension);
            var ring = new TEuclidianRing();

            UInt32 pivotIndex = 0;

            for (UInt32 k = 0; k < min; k++) {
                pivotIndex = FindRowPivotIndex(matrixCopy, k);

                if (matrixCopy[pivotIndex, k].Equals(ring.Zero)) {
                    throw new IndexOutOfRangeException(
                        "The given matrix is singular.");
                }

                matrixCopy = matrixCopy.SwapRows(k, pivotIndex);

                for (UInt32 i = k + 1; k < matrixCopy.RowDimension; k++) {
                    for (UInt32 j = k + 1; j < matrixCopy.ColumnDimension; j++) {
                        var akk = matrixCopy[k, k];

                        var prod1 = ring.Multiplication(matrixCopy[i, j], akk);
                        var prod2 = ring.Multiplication(matrixCopy[k, j], matrixCopy[i, k]);

                        matrixCopy[i, j] = ring.Addition(prod1, prod2);
                    }

                    matrixCopy[i, k] = ring.Zero;
                }
            }

            return matrixCopy;
        }

        #endregion

        #region helper methods

        private static UInt32 FindRowPivotIndex<T, TEuclidianRing> (
            this IMatrix<T, TEuclidianRing> matrix,
            UInt32 columnNumber)
            where TEuclidianRing : IEuclidianRing<T>, new()
        {
            var ring = new TEuclidianRing();
            var pivotElement = ring.Zero;
            UInt32 pivotIndex = columnNumber;
            var k = columnNumber;

            // i is the row number
            for (UInt32 i = k; i < matrix.RowDimension; i++) {
                var element = matrix[i, k];

                if (ring.Norm(element) > ring.Norm(pivotElement)) {
                    pivotElement = element;
                    pivotIndex = i;
                }
            }

            return pivotIndex;
        }

        #endregion
    }
}