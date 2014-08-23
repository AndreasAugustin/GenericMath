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
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>The trace of the matrix.</returns>
        public static T Trace<T, TStruct>(this Matrix<T, TStruct> matrix)
            where TStruct : IMonoid<T>, new()
        {
            CheckSquared(matrix);

            var calculator = matrix.BaseStructure;
            var result = calculator.Zero;

            for (UInt32 i = 0; i < matrix.RowDimension; i++)
            {
                result = calculator.Addition(result, matrix[i, i]);
            }

            return result;
        }

        /// <summary>
        /// Calculates the gauss jordan algorithm.
        /// </summary>
        /// <returns>The jordan algorithm.</returns>
        /// <param name="matrix">The matrix.</param>
        public static Matrix<Double, DoubleEuclidianRing> GausJordanAlgorithm(this Matrix<Double, DoubleEuclidianRing> matrix)
        {
            // TODO dieser Algorithmus muss noch abstrahiert werden 
            // (auf ganze Zahlen... dies muss nur an den Stellen passieren, an denen geteilt wird)
            // public static Matrix<T> GaussJordanAlgorithm<T>(this Matrix<T> matrix)
            // where T > struct
            CheckSquared(matrix);

            var list = new List<Matrix<Double, DoubleEuclidianRing>>();
            list.Add(matrix.Copy());

            // stores informations about the row permutations
            var permutationVector = new Vector<UInt32, UInt32Monoid>(matrix.RowDimension); 
            for (UInt32 j = 0; j < matrix.RowDimension; j++)
            {
                permutationVector[j] = j;
            }

            for (UInt32 j = 0; j < matrix.RowDimension; j++)
            {
                GaussJordanAlgorithmStep(matrix, j, permutationVector);
            }

            return matrix;
        }

        /// <summary>
        /// Calculates the Inverse of the matrix A with the Gauss-Jordan algorithm.
        /// </summary>
        /// <returns>The steps for calculating the inverse matrix. (The inverse matrix is the last one in the list)</returns>
        /// <param name="matrix">The matrix.</param>
        public static List<Matrix<Double, DoubleEuclidianRing>> GaussJordanAlgorithmWithSteps(this Matrix<Double, DoubleEuclidianRing> matrix)
        {
            // TODO dieser Algorithmus muss noch abstrahiert werden 
            // auf ganze Zahlen... dies muss nur an den Stellen passieren, an denen geteilt wird)
            // public static Matrix<T> GaussJordanAlgorithm<T>(this Matrix<T> matrix)
            // where T > struct
            CheckSquared(matrix);

            var list = new List<Matrix<Double, DoubleEuclidianRing>>();
            list.Add(matrix.Copy());

            // stores informations about the row permutations
            var permutationVector = new Vector<UInt32, UInt32Monoid>(matrix.RowDimension); 
            for (UInt32 j = 0; j < matrix.RowDimension; j++)
            {
                permutationVector[j] = j;
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

        static void GaussJordanAlgorithmStep(Matrix<Double, DoubleEuclidianRing> matrix, UInt32 column, Vector<UInt32, UInt32Monoid> permutationVector)
        {
            var calculator = matrix.BaseStructure;
            var n = matrix.RowDimension;

            // search pivot element (row)
            var max = calculator.Norm(matrix[column, column]);
            var r = column;
            for (UInt32 i = column + 1; i < n; i++)
            {
                if (calculator.Norm(matrix[i, column]) > max)
                {
                    r = i;
                    max = calculator.Norm(matrix[i, column]);
                }
            }

            if (calculator.Zero.Equals(max))
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

                var permTemp = permutationVector[column];
                permutationVector[column] = permutationVector[r];
                permutationVector[r] = permTemp;
            }

            // transform
            var inverseDouble = 1 / matrix[column, column];

            // HACK this needs to be abstracted (for float, Int32,...) should be possible with multiplzing with the inverse
            for (UInt32 i = 0; i < n; i++)
            {
                matrix[i, column] = calculator.Multiplication(inverseDouble, matrix[i, column]);
                matrix[column, column] = inverseDouble;
                for (UInt32 k = 0; k < n; k++)
                {
                    if (k == column)
                        continue;
                    matrix[i, k] = matrix[i, k] - (matrix[i, column] * matrix[column, k]);
                    matrix[column, k] = -inverseDouble * matrix[column, k];
                }
            }

            // permute columns
            for (UInt32 i = 0; i < n; i++)
            {
                var tempVec = new Vector<Double, DoubleGroup>(n);
                for (UInt32 k = 0; k < n; k++)
                {
                    tempVec[permutationVector[k]] = matrix[i, k];
                }

                for (UInt32 k = 0; k < n; k++)
                {
                    matrix[i, k] = tempVec[k];
                }
            }
        }

        static void CheckSquared<T, TStruct>(this Matrix<T, TStruct> matrix)
            where TStruct : IStructure<T>, new()
        {
            if (matrix.RowDimension != matrix.ColumnDimension)
                throw new NotSupportedException("The row and column dimension do not agree");
        }

        #endregion
    }
}
