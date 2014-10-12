//  *************************************************************
// <copyright file="IMatrixFromGroupExtensions.cs" company="${Company}">
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
    public static class IMatrixFromGroupExtensions
    {
        #region methods

        /// <summary>
        /// Inverse the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TGroup">The second type parameter.</typeparam>
        /// <returns>The inverse matrix.</returns>
        public static IMatrix<T, TGroup> Inverse<T, TGroup>(this IMatrix<T, TGroup> matrix)
            where TGroup : IGroup<T>, new()
        {
            var mat = matrix.ReturnNewInstance(matrix.RowDimension, matrix.ColumnDimension);

            var baseStructure = new TGroup();

            for (UInt32 i = 0; i < matrix.RowDimension; i++)
            {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
                {
                    mat[i, j] = baseStructure.Inverse(matrix[i, j]);
                }
            }

            return mat;
        }

        #endregion
    }
}