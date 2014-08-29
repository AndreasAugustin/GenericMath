//  *************************************************************
// <copyright file="IMatrix.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  23 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

    /// <summary>
    /// Interface for the matrix class.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    public interface IMatrix<T, TStruct>
        where TStruct : IStructure<T>, new()
    {
        #region properties

        /// <summary>
        /// Gets the row dimension.
        /// </summary>
        /// <value>The row dimension.</value>
        UInt32 RowDimension { get; }

        /// <summary>
        /// Gets the column dimension.
        /// </summary>
        /// <value>The column dimension.</value>
        UInt32 ColumnDimension { get; }

        /// <summary>
        /// Gets or sets the <see cref="IMatrix{T, TStruct}"/> with the specified row column.
        /// </summary>
        /// <param name="row">The Row.</param>
        /// <param name="column">The Column.</param>
        /// <returns>The value at row and column.</returns>
        T this[UInt32 row, UInt32 column] { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IMatrix{T, TStruct}"/> with the specified column.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns>The vector <see cref="IVector{T, TStruct}"/> at column.</returns>
        IVector<T, TStruct> this[UInt32 column] { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Returns the new instance with twisted dimensions.
        /// </summary>
        /// <returns>The new instance with twisted dimensions.</returns>
        IMatrix<T, TStruct> ReturnNewInstanceWithTwistedDimensions();

        /// <summary>
        /// Returns the new instance with same dimensions.
        /// </summary>
        /// <returns>The new instance with same dimensions.</returns>
        IMatrix<T, TStruct> ReturnNewInstanceWithSameDimensions();

        /// <summary>
        /// Returns the new instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        /// <param name="rowDimension">Row dimension.</param>
        /// <param name="columnDimension">Column dimension.</param>
        IMatrix<T, TStruct> ReturnNewInstance(UInt32 rowDimension, UInt32 columnDimension);

        #endregion
    }
}