//  *************************************************************
// <copyright file="IMatrixFromMonoidExtensions.cs" company="${Company}">
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
    /// Extensions methods for the <see cref="Matrix{T, TStruct}"/> class.
    /// TStruct needs to be of type <see cref="IMonoid{T}"/>
    /// </summary>
    public static class IMatrixFromMonoidExtensions
    {
        #region methods

        /// <summary>
        /// Add the specified leftMatrix and rightMatrix.
        /// </summary>
        /// <param name="leftMatrix">The left matrix.</param>
        /// <param name="rightMatrix">The right matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>The addition of left and right matrices.</returns>
        public static IMatrix<T, TStruct> Add<T, TStruct>(this IMatrix<T, TStruct> leftMatrix, IMatrix<T, TStruct> rightMatrix)
            where TStruct : IGroup<T>, new()
        {
            if (leftMatrix.ColumnDimension != rightMatrix.ColumnDimension)
                throw new NotSupportedException("The column dimension of the matrizes need to agree");

            if (leftMatrix.RowDimension != rightMatrix.RowDimension)
                throw new NotSupportedException("The row dimension of the matrizes need to agree");
                
            var result = leftMatrix.ReturnNewInstanceWithSameDimensions();

            for (UInt32 j = 0; j < leftMatrix.ColumnDimension; j++)
            {
                result[j] = leftMatrix[j].Add(rightMatrix[j]);
            }

            return result;
        }

        /// <summary>
        /// Summarizes all elements in the matrix.
        /// </summary>
        /// <returns>The sum over all elements in the matrix.</returns>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static T SumElements<T, TStruct>(this IMatrix<T, TStruct> matrix)
            where TStruct : IGroup<T>, new()
        {   
            var baseStructure = new TStruct();
            var result = baseStructure.Zero;

            for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
            {
                result = baseStructure.Addition(result, matrix[j].SumElements());
            }

            return result;
        }

        #endregion
    }
}