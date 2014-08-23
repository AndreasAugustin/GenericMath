//  *************************************************************
// <copyright file="SpecialMatrices.cs" company="${Company}">
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
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public Matrix<T, TStruct> ZeroMatrix<T, TStruct>(UInt32 dimension)
            where TStruct : IGroup<T>, new()
        {
            return ZeroMatrix<T, TStruct>(dimension, dimension);
        }

        /// <summary>
        /// Creates a matrix with Zero as elements.
        /// </summary>
        /// <returns>The matrix.</returns>
        /// <param name="rowDimension">Row dimension.</param>
        /// <param name="columnDimension">Column dimension.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public Matrix<T, TStruct> ZeroMatrix<T, TStruct>(UInt32 rowDimension, UInt32 columnDimension)
            where TStruct : IGroup<T>, new()
        {
            var matrix = new Matrix<T, TStruct>(rowDimension, columnDimension);

            for (UInt32 i = 0; i < rowDimension; i++)
            {
                for (UInt32 j = 0; j < columnDimension; j++)
                {
                    matrix[i, j] = matrix.BaseStructure.Zero;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Creates the one matrix.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>The one matrix with dimension n.</returns>
        public Matrix<T, TStruct> OneMatrix<T, TStruct>(UInt32 dimension)
            where TStruct : IRing<T>, new()
        {
            var mat = new Matrix<T, TStruct>(dimension);

            var ring = mat.BaseStructure;

            for (UInt32 i = 0; i < mat.RowDimension; i++)
            {
                for (UInt32 j = 0; j < mat.ColumnDimension; j++)
                {
                    if (i == j)
                    {
                        mat[i, i] = ring.One;
                        continue;
                    }

                    mat[i, j] = ring.Zero;
                }
            }

            return mat;
        }

        #endregion
    }
}