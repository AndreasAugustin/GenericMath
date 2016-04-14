//  *************************************************************
// <copyright file="IMatrixFromRingExtensions.cs" company="None">
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
    /// Extension methods for the <see cref="Matrix{T, TStruct}"/> class.
    /// </summary>
    public static class IMatrixFromRingExtensions
    {
        #region methods

        /// <summary>
        /// Multiply a scalar lambda with the matrix A.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="scalar">The scalar.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TRing">The underlying structure.</typeparam>
        /// <returns>Lambda * A.</returns>
        public static IMatrix<T, TRing> ScalarMultiply<T, TRing> (
            this IMatrix<T, TRing> matrix,
            T scalar)
            where TRing : IRing<T>, new()
        {
            var result = matrix.ReturnNewInstance(
                    matrix.RowDimension,
                    matrix.ColumnDimension);
            var ring = new TRing();

            for (UInt32 j = 0; j < matrix.ColumnDimension; j++) {
                for (UInt32 i = 0; i < matrix.RowDimension; i++) {
                    result[i, j] = ring.Multiplication(scalar, matrix[i, j]);
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies the matrix A with matrix B 
        /// A * B.
        /// </summary>
        /// <returns>The resulted matrix.</returns>
        /// <param name="matrix1">The left Matrix.</param>
        /// <param name="matrix2">The right Matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TRing">The underlying structure.</typeparam>
        public static IMatrix<T, TRing> MultiplyMatrix<T, TRing> (
            this IMatrix<T, TRing> matrix1,
            IMatrix<T, TRing> matrix2)
            where TRing : IRing<T>, new()
        {
            if (matrix1.ColumnDimension != matrix2.RowDimension) {
                throw new IndexOutOfRangeException("The ColumnDimension of matrix1 needs to be the same like the RowDimension of matrix2");
            }

            var result = matrix1.ReturnNewInstance(
                    matrix1.RowDimension,
                    matrix2.ColumnDimension);

            var baseStructure = new TRing();

            for (UInt32 i = 0; i < result.RowDimension; i++) {
                for (UInt32 j = 0; j < result.ColumnDimension; j++) {
                    for (UInt32 k = 0; k < matrix1.ColumnDimension; k++) {
                        result[i, j] = baseStructure.Addition(
                            result[i, j],
                            baseStructure.Multiplication(matrix1[i, k], matrix2[k, j]));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Multiply the matrix power times.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="power">The power.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TRing">The underlying structure.</typeparam>
        /// <returns>The power of the matrix with power.</returns>
        public static IMatrix<T, TRing> Pow<T, TRing> (
            this IMatrix<T, TRing> matrix,
            UInt32 power)
            where TRing : IRing<T>, new()
        {
            var result = matrix.Copy();

            for (UInt32 i = 0; i < power - 1; i++) {
                result = result.MultiplyMatrix(matrix);
            }

            return result;
        }

        /// <summary>
        /// Multiplies the Matrix A with a vector v.
        /// A * v.
        /// </summary>
        /// <returns>The new vector.</returns>
        /// <param name="matrix">The matrix.</param>
        /// <param name="vector">The vector.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TRing">The underlying structure.</typeparam>
        public static IDirectSum<T, TRing> MultiplyVector<T, TRing> (
            this IMatrix<T, TRing> matrix,
            IDirectSum<T, TRing> vector)
            where TRing : IRing<T>, new()
        {
            if (matrix.ColumnDimension != vector.Dimension) {
                throw new IndexOutOfRangeException("The ColumnDimension of the matrix needs to equal the row dimension of the vector");
            }

            var baseStructure = new TRing();
            var vect = vector.ReturnNewInstance(matrix.RowDimension);

            for (UInt32 i = 0; i < matrix.RowDimension; i++) {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++) {
                    vect[i] = baseStructure.Addition(
                        vect[i],
                        baseStructure.Multiplication(matrix[i, j], vector[j]));
                }
            }

            return vect;
        }

        #endregion
    }
}