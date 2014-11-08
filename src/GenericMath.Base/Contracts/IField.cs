//  *************************************************************
// <copyright file="IField.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base
{
    /// <summary>
    /// Interface for defining fields.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    public interface IField<T> : IRing<T>, IStructure<T>
    {
        #region methods

        /// <summary>
        /// Gets the inverse for the ring multiplication.
        /// </summary>
        /// <returns>The inverse.</returns>
        /// <param name="element">The element.</param>
        T MultiplicationInverse(T element);

        #endregion
    }
}