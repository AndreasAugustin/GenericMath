//  *************************************************************
// <copyright file="MatrixFromGroupExtensions.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

    /// <summary>
    /// Extension methods for the <see cref="Matrix{T, TStruct}"/> class.
    /// </summary>
    public static class MatrixFromGroupExtensions
    {
        #region methods

        /// <summary>
        /// Inverse the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The second type parameter.</typeparam>
        /// <returns>The inverse matrix.</returns>
        public static Matrix<T, TStruct> Inverse<T, TStruct>(this Matrix<T, TStruct> matrix)
            where TStruct : IGroup<T>, new()
        {
            var mat = new Matrix<T, TStruct>(matrix.RowDimension, matrix.ColumnDimension);

            for (UInt32 i = 0; i < matrix.RowDimension; i++)
            {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
                {
                    mat[i, j] = matrix.BaseStructure.Inverse(matrix[i, j]);
                }
            }

            return mat;
        }

        #endregion
    }
}