//  *************************************************************
// <copyright file="IVector.cs" company="${Company}">
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
    /// Interface for the vector classes.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The structure.</typeparam>
    public interface IVector<T, TStruct> : IEquatable<IVector<T, TStruct>>
        where TStruct : IStructure<T>, new()
    {
        #region properties

        /// <summary>
        /// Gets the dimension.
        /// </summary>
        /// <value>The dimension.</value>
        UInt32 Dimension { get; }

        /// <summary>
        /// Gets or sets the <see cref="Vector{T, TStruct}"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The value at index.</returns>
        T this[UInt32 index] { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Returns a new the instance with same dimension like the calling instance.
        /// </summary>
        /// <returns>The instance with same dimension.</returns>
        IVector<T, TStruct> ReturnNewInstanceWithSameDimension();

        /// <summary>
        /// Returns the new instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        /// <param name="rowDimension">Row dimension.</param>
        IVector<T, TStruct> ReturnNewInstance(UInt32 rowDimension);

        #endregion
    }
}