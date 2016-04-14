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

        public static ISquaredMatrix<T, TStruct> Copy<T, TStruct> (this ISquaredMatrix<T, TStruct> matrix)
            where TStruct : IStructure, new()
        {
            var newMatrix = matrix.ReturnNewInstance(matrix.Dimension);

            for (UInt32 j = 0; j < matrix.Dimension; j++) {
                for (UInt32 i = 0; i < matrix.Dimension; i++) {
                    newMatrix[i, j] = matrix[i, j];
                }
            }

            return newMatrix;
        }

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
            var baseStructure = new TMonoid();
            var result = baseStructure.Zero;

            for (UInt32 i = 0; i < matrix.Dimension; i++) {
                result = baseStructure.Addition(result, matrix[i, i]);
            }

            return result;
        }

        /// <summary>
        /// Gauss jordan algorithm for squared matrix with underlying field.
        /// </summary>
        /// <returns>The jordan algorithm.</returns>
        /// <param name="matrix">Matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The 2nd type parameter.</typeparam>
        public static ISquaredMatrix<T, TField> GaussJordanAlgorithmNew<T, TField> (this ISquaredMatrix<T, TField> matrix)
            where TField : IField<T>, new()
        {
            var matrixCopy = matrix.Copy();

            var field = new TField();
            for (uint row = 0; row < matrix.Dimension; row++) {
                uint column = row;

                if (matrixCopy[row, column].Equals(field.Zero)) {
                    // TODO swap rows to find element not equal to zero, else -> matrix is singular
                }

                // divide first row through a11
                matrixCopy.MultiplyReferenceRowWithSkalar(field.MultiplicationInverse(matrixCopy[row, column]), row);

                // substract from all remaining rows first row multiplied with first element of row
                for (uint i = row + 1; i < matrixCopy.Dimension; i++) {
                    var firstRowMultipliedWithFirstElement = matrixCopy.MultiplyRowWithSkalarReturnResultAsArray(field.Inverse(matrixCopy[i, column]), row);
                    matrixCopy.AddRowToMatrixRowReference(firstRowMultipliedWithFirstElement, i);
                }
            }

            return matrixCopy;
        }

        #endregion

        private static void AddRowToMatrixRowReference<T, TGroup> (this ISquaredMatrix<T, TGroup> matrix, T[] rowToAdd, uint row)
            where TGroup : IGroup<T>, new()
        {
            var group = new TGroup();
            if (matrix.Dimension != rowToAdd.Length) {
                throw new NotSupportedException();
            }

            for (uint j = 0; j < matrix.Dimension; j++) {
                matrix[row, j] = group.Addition(matrix[row, j], rowToAdd[j]);
            }
        }

        private static void MultiplyReferenceRowWithSkalar<T, TRing> (this ISquaredMatrix<T, TRing> matrix, T scalar, uint rowNumber)
            where TRing : IRing<T>, new()
        {
            var ring = new TRing();

            if (rowNumber >= matrix.Dimension) {
                throw new IndexOutOfRangeException();
            }

            for (uint j = 0; j < matrix.Dimension; j++) {
                matrix[rowNumber, j] = ring.Multiplication(scalar, matrix[rowNumber, j]);
            }
        }

        private static T[] MultiplyRowWithSkalarReturnResultAsArray<T, TRing> (this ISquaredMatrix<T, TRing> matrix, T scalar, uint rowNumber)
            where TRing : IRing<T>, new()
        {
            var ring = new TRing();

            var result = new T[matrix.Dimension];

            if (rowNumber >= matrix.Dimension) {
                throw new IndexOutOfRangeException();
            }

            for (uint j = 0; j < matrix.Dimension; j++) {
                result[j] = ring.Multiplication(scalar, matrix[rowNumber, j]);
            }

            return result;
        }
    }
}