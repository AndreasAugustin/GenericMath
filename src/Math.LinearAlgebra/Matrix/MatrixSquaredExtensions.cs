//  *************************************************************
// <copyright file="MatrixSquaredExtensions.cs" company="${Company}">
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
    public static class MatrixSquaredExtensions
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
        public static IMatrix<T, TField> GausJordanAlgorithm<T, TField>(this IMatrix<T, TField> matrix)
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
        public static List<IMatrix<T, TField>> GaussJordanAlgorithmWithSteps<T, TField>(this IMatrix<T, TField> matrix)
            where T : IComparable
            where TField : IField<T>, new()
        {
            // TODO dieser Algorithmus muss noch abstrahiert werden 
            // auf ganze Zahlen... dies muss nur an den Stellen passieren, an denen geteilt wird)
            // public static Matrix<T> GaussJordanAlgorithm<T>(this Matrix<T> matrix)
            // where T > struct
            CheckSquared(matrix);

            var list = new List<IMatrix<T, TField>>();
            list.Add(matrix.Copy());

            // stores informations about the row permutations
            var permutationVector = new List<UInt32>(new UInt32[matrix.RowDimension]); 
            for (UInt32 j = 0; j < matrix.RowDimension; j++)
            {
                permutationVector[(Int32)j] = j;
            }

            for (UInt32 j = 0; j < matrix.RowDimension; j++)
            {
                GaussJordanAlgorithmStep(matrix, j, permutationVector);
									
                list.Add(matrix.Copy());
            }

            return list;
        }

        #endregion

        #region HELPER METHODS

        static void GaussJordanAlgorithmStep<T, TField>(IMatrix<T, TField> matrix, UInt32 column, 
                                                        List<UInt32> permutationVector)
            where T : IComparable
            where TField : IField<T>, new()
        {
            var field = new TField();
            var n = matrix.RowDimension;

            // search pivot element (row)
            var max = matrix[column, column];
            var r = column;
            for (UInt32 i = column + 1; i < n; i++)
            {
                if (matrix[i, column].CompareTo(max) > 0)
                {
                    r = i;
                    max = matrix[i, column];
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
                    var temp = matrix[column, k];
                    matrix[column, k] = matrix[r, k];
                    matrix[r, k] = temp;
                }

                var permTemp = permutationVector[(Int32)column];
                permutationVector[(Int32)column] = permutationVector[(Int32)r];
                permutationVector[(Int32)r] = permTemp;
            }
                
            var inverseDouble = field.MultiplicationInverse(matrix[column, column]);

            for (UInt32 i = 0; i < n; i++)
            {
                matrix[i, column] = field.Multiplication(inverseDouble, matrix[i, column]);
                matrix[column, column] = inverseDouble;
                for (UInt32 k = 0; k < n; k++)
                {
                    if (k == column)
                        continue;

                    var temp = field.Inverse(field.Multiplication(matrix[i, column], matrix[column, k]));
                    matrix[i, k] = field.Addition(matrix[i, k], temp);
                    matrix[column, k] = field.Multiplication(field.Inverse(inverseDouble), matrix[column, k]);
                }
            }

            // permute columns
            for (UInt32 i = 0; i < n; i++)
            {
                var tempVec = new List<T>(new T[n]);
                for (UInt32 k = 0; k < n; k++)
                {
                    tempVec[(Int32)permutationVector[(Int32)k]] = matrix[i, k];
                }

                for (UInt32 k = 0; k < n; k++)
                {
                    matrix[i, k] = tempVec[(Int32)k];
                }
            }
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
