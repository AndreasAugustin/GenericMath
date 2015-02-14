//  *************************************************************
// <copyright file="IMatrixFromGroupExtensions.cs" company="None">
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
        public static IMatrix<T, TGroup> Inverse<T, TGroup> (this IMatrix<T, TGroup> matrix)
            where TGroup : IGroup<T>, new()
        {
            var mat = matrix.ReturnNewInstance(
                          matrix.RowDimension,
                          matrix.ColumnDimension);

            var baseStructure = new TGroup();

            for (UInt32 i = 0; i < matrix.RowDimension; i++) {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++) {
                    mat[i, j] = baseStructure.Inverse(matrix[i, j]);
                }
            }

            return mat;
        }

        #endregion
    }
}