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
        public static IMatrix<T, TEuclidianRing> GausJordanAlgorithm<T, TEuclidianRing>(this IMatrix<T, TEuclidianRing> matrix)
            where TEuclidianRing : IEuclidianRing<T>, new()
        {
            var list = GaussJordanAlgorithmWithSteps(matrix);

            return list[list.Count - 1];
        }

        /// <summary>
        /// Calculates the Inverse of the matrix A with the Gauss-Jordan algorithm.
        /// </summary>
        /// <returns>The steps for calculating the inverse matrix. (The inverse matrix is the last one in the list)</returns>
        /// <param name="matrix">The matrix.</param>
        public static List<IMatrix<T, TEuclidianRing>> GaussJordanAlgorithmWithSteps<T, TEuclidianRing>(this IMatrix<T, TEuclidianRing> matrix)
            where TEuclidianRing : IEuclidianRing<T>, new()
        {
            // TODO dieser Algorithmus muss noch abstrahiert werden 
            // auf ganze Zahlen... dies muss nur an den Stellen passieren, an denen geteilt wird)
            // public static Matrix<T> GaussJordanAlgorithm<T>(this Matrix<T> matrix)
            // where T > struct
            CheckSquared(matrix);

            var list = new List<IMatrix<T, TEuclidianRing>>();
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

        static void GaussJordanAlgorithmStep<T, TEuclidianRing>(IMatrix<T, TEuclidianRing> matrix, UInt32 column, 
                                                                List<UInt32> permutationVector)
            where TEuclidianRing : IEuclidianRing<T>, new()
        {
            var euclidianRing = new TEuclidianRing();
            var n = matrix.RowDimension;

            // search pivot element (row)
            var max = euclidianRing.Norm(matrix[column, column]);
            var r = column;
            for (UInt32 i = column + 1; i < n; i++)
            {
                if (euclidianRing.Norm(matrix[i, column]) > max)
                {
                    r = i;
                    max = euclidianRing.Norm(matrix[i, column]);
                }
            }

            if (euclidianRing.Zero.Equals(max))
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

            throw new NotImplementedException("Needs to be extended to rings");
            // transform // Hack to be able to compile, makes no sense
            var inverseDouble = (T)(1 / matrix[column, column]);

            // HACK this needs to be abstracted (for float, Int32,...) should be possible with multiplying with the inverse
            for (UInt32 i = 0; i < n; i++)
            {
                matrix[i, column] = euclidianRing.Multiplication(inverseDouble, matrix[i, column]);
                matrix[column, column] = inverseDouble;
                for (UInt32 k = 0; k < n; k++)
                {
                    if (k == column)
                        continue;

                    var temp = euclidianRing.Inverse(euclidianRing.Multiplication(matrix[i, column], matrix[column, k]));
                    matrix[i, k] = euclidianRing.Addition(matrix[i, k], temp);
                    matrix[column, k] = euclidianRing.Multiplication(euclidianRing.Inverse(inverseDouble), matrix[column, k]);
                }
            }

            // permute columns
            for (UInt32 i = 0; i < n; i++)
            {
                var tempVec = new List<T>(new T[n]);
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

        static void CheckSquared<T, TStruct>(this IMatrix<T, TStruct> matrix)
            where TStruct : IStructure<T>, new()
        {
            if (matrix.RowDimension != matrix.ColumnDimension)
                throw new NotSupportedException("The row and column dimension do not agree");
        }

        #endregion
    }
}
