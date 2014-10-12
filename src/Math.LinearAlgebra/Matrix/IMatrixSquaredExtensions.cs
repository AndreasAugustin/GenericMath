//  *************************************************************
// <copyright file="IMatrixSquaredExtensions.cs" company="${Company}">
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
    using System.Collections.Generic;

    using Math.Base;

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
        public static T Trace<T, TMonoid>(this IMatrix<T, TMonoid> matrix)
            where TMonoid : IMonoid<T>, new()
        {
            CheckSquared(matrix);

            var baseStructure = new TMonoid();
            var result = baseStructure.Zero;

            for (UInt32 i = 0; i < matrix.RowDimension; i++)
            {
                result = baseStructure.Addition(result, matrix[i, i]);
            }

            return result;
        }

        /// <summary>
        /// Calculates the gauss jordan algorithm.
        /// </summary>
        /// <returns>The jordan algorithm.</returns>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TField">The underlying structure (field).</typeparam>
        public static IMatrix<T, TField> GaussJordanAlgorithm<T, TField>(this IMatrix<T, TField> matrix)
            where T : IComparable
            where TField : IField<T>, new()
        {
            var list = GaussJordanAlgorithmWithSteps(matrix);

            return list[list.Count - 1];
        }

        /// <summary>
        /// Calculates the Inverse of the matrix A with the Gauss-Jordan algorithm.
        /// </summary>
        /// <returns>The steps for calculating the inverse matrix. (The inverse matrix is the last one in the list)</returns>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TField">The underlying structure (field).</typeparam>
        public static List<IMatrix<T, TField>> GaussJordanAlgorithmWithSteps<T, TField>(this IMatrix<T, TField> matrix)
            where T : IComparable
            where TField : IField<T>, new()
        {
            CheckSquared(matrix);

            // stores informations about the row permutations
            var permutationVector = new List<UInt32>(new UInt32[matrix.RowDimension]); 
            for (UInt32 j = 0; j < matrix.RowDimension; j++)
            {
                permutationVector[(Int32)j] = j;
            }
                
            var list = new List<IMatrix<T, TField>>();
            list.Add(matrix);

            // We like to work with a copy of the matrix, not with the original one to keep the original information.
            var matrixCopy = matrix.Copy();
            for (UInt32 j = 0; j < matrixCopy.RowDimension; j++)
            {
                var mat = GaussJordanAlgorithmStep(
                              matrixCopy,
                              j,
                              permutationVector);
                matrixCopy = mat;					
                list.Add(mat);
            }

            return list;
        }

        #endregion

        #region HELPER METHODS

        private static IMatrix<T, TField> GaussJordanAlgorithmStep<T, TField>(
            IMatrix<T, TField> matrix, 
            UInt32 column, 
            IList<UInt32> permutationVector)
            where T : IComparable
            where TField : IField<T>, new()
        { // TODO !!the Gaus jordan algorithm is not correct yet!!!
            throw new ArithmeticException("GaussJordanAlgorithm");

            var matrixCopy = matrix.Copy();
            var field = new TField();
            var n = matrixCopy.RowDimension;

            // search pivot element (row)
            var max = matrixCopy[column, column];
            var r = column;

            for (UInt32 i = column + 1; i < n; i++)
            {
                if (matrixCopy[i, column].CompareTo(max) > 0)
                {
                    r = i;
                    max = matrixCopy[i, column];
                }
            }

            if (field.Zero.Equals(max))
            {
                // matrix is singular
                throw new DivideByZeroException("Matrix is singular");
            }

            // permutate rows
            if (r > column)
            {
                for (UInt32 k = 0; k < n; k++)
                {
                    var temp = matrixCopy[column, k];
                    matrixCopy[column, k] = matrixCopy[r, k];
                    matrixCopy[r, k] = temp;
                }

                var permTemp = permutationVector[(Int32)column];
                permutationVector[(Int32)column] = permutationVector[(Int32)r];
                permutationVector[(Int32)r] = permTemp;
            }
                
            var inverseDouble = field.MultiplicationInverse(matrixCopy[column, column]);

            for (UInt32 i = 0; i < n; i++)
            {
                matrixCopy[i, column] = field.Multiplication(
                    inverseDouble,
                    matrixCopy[i, column]);
                matrixCopy[column, column] = inverseDouble;
                for (UInt32 k = 0; k < n; k++)
                {
                    if (k == column)
                        continue;

                    var temp = field.Inverse(field.Multiplication(
                                       matrixCopy[i, column],
                                       matrixCopy[column, k]));
                    matrixCopy[i, k] = field.Addition(matrixCopy[i, k], temp);
                    matrixCopy[column, k] = field.Multiplication(
                        field.Inverse(inverseDouble),
                        matrixCopy[column, k]);
                }
            }

            // permute columns
            for (UInt32 i = 0; i < n; i++)
            {
                var tempVec = new List<T>(new T[n]);
                for (UInt32 k = 0; k < n; k++)
                {
                    tempVec[(Int32)permutationVector[(Int32)k]] = matrixCopy[i, k];
                }

                for (UInt32 k = 0; k < n; k++)
                {
                    matrixCopy[i, k] = tempVec[(Int32)k];
                }
            }

            return matrixCopy;
        }

        static void CheckSquared<T, TStruct>(this IMatrix<T, TStruct> matrix)
            where TStruct : IStructure<T>, new()
        {
            if (matrix.RowDimension != matrix.ColumnDimension)
                throw new NotSupportedException("The row and column dimension do not agree");
        }

        #endregion
    }
}
