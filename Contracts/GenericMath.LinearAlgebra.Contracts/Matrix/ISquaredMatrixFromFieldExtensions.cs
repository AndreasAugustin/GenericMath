// *************************************************************
// <copyright file="ISquaredMatrixFromFieldExtensions.cs" company="None">
//      Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>AndreasAugustin</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra.Contracts
{
    using System;
    using GenericMath.Base.Contracts;

    /// <summary>
    /// Extension methods for <see cref="ISquaredMatrix{T, TStruct}"/> instances,
    /// where TStruct is a field.
    /// </summary>
    public static class ISquaredMatrixFromFieldExtensions
    {
        /// <summary>
        /// Gausses the jordan algorithm.
        /// </summary>
        /// <returns>The jordan algorithm.</returns>
        /// <param name="squaredMatrix">Squared matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying field.</typeparam>
        public static TMatrix GaussJordanAlgorithm<T, TStruct, TMatrix> (this TMatrix squaredMatrix)
            where TStruct : IField<T>, new()
            where TMatrix : ISquaredMatrix<T, TStruct>
        {
            // TODO copy the matrix!!
            var matrix = squaredMatrix;
            var field = new TStruct();

            uint row = 0;
            uint column = 0;

            // Get first element of active row (related to active column)
            var firstElement = matrix[0, 0];
            if (firstElement.Equals(field.Zero)) {
                // TODO swap rows till a11 is not zero. (remaining matrix)
                // if not possible -> matrix is singular
            }

            for (uint c = column; c < squaredMatrix.Dimension; c++) {
                // Divide firstElement from active row
                matrix[0, c] = field.Multiplication(field.MultiplicationInverse(firstElement), matrix[0, c]);
            }

            // Turn all remaining first elements (of other rows) to zero
            for (uint r = row + 1; r < squaredMatrix.Dimension; r++) {
                if (matrix[r, column].Equals(field.Zero)) {
                    // element is already zero
                    continue; 
                }

                // element is not zero -> row - firstelement * active row
                for (var col = column; col < matrix.Dimension; col++) {

                }
            }
            throw new NotImplementedException();
        }
    }
}
