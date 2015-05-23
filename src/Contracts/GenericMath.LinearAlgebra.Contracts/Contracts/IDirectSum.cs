//  *************************************************************
// <copyright file="IDirectSum.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;

namespace GenericMath.LinearAlgebra.Contracts
{
    using System;

    /// <summary>
    /// Interface for the direct sum of structures.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The structure.</typeparam>
    public interface IDirectSum<T, TStruct> 
        where TStruct : IStructure, new()
    {
        #region properties

        /// <summary>
        /// Gets the dimension.
        /// </summary>
        /// <value>The dimension.</value>
        UInt32 Dimension { get; }

        /// <summary>
        /// Gets or sets the <see cref="IDirectSum{T, TStruct}"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The value at index.</returns>
        T this [UInt32 index]
        {
            get;
            set;
        }

        #endregion

        #region methods

        // TODO move into factory
        /// <summary>
        /// Returns the new instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        /// <param name="dimension">Row dimension.</param>
        IDirectSum<T, TStruct> ReturnNewInstance (UInt32 dimension);

        #endregion
    }
}