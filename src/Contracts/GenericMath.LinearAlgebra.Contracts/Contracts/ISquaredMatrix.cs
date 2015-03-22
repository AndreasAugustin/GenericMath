// //  *************************************************************
// // <copyright file="ISquaredMatrix.cs" company="None">
// //     Copyright (c) 2014  AndreasAugustin. All rights reserved.
// // </copyright>
// // <license>MIT Licence</license>
// // <author>AndreasAugustin </author>
// // <email>andy.augustin@t-online.de</email>
// // *************************************************************
//


namespace GenericMath.LinearAlgebra.Contracts
{
    using System;
    using GenericMath.Base.Contracts;

    /// <summary>
    /// Interface for squared matrizes.
    /// </summary>
    public interface ISquaredMatrix<T, TStruct> 
		where TStruct : IStructure<T>, new()
    {
        #region properties

        /// <summary>
        /// Gets the dimension.
        /// </summary>
        /// <value>The dimension.</value>
        UInt32 Dimension { get; }

        /// <summary>
        /// Gets or sets the <see cref="IMatrix{T, TStruct}"/> with the specified row column.
        /// </summary>
        /// <param name="row">The Row.</param>
        /// <param name="column">The Column.</param>
        /// <returns>The value at row and column.</returns>
        T this [UInt32 row, UInt32 column]
        {
            get;
            set;
        }

        #endregion

        #region methods

        /// <summary>
        /// Returns the new instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        /// <param name="dimension">Row dimension.</param>
        ISquaredMatrix<T, TStruct> ReturnNewInstance (
            UInt32 dimension);

        #endregion
    }
}