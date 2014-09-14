//  *************************************************************
// <copyright file="IField.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    using System;

    /// <summary>
    /// Interface for defining fields.
    /// </summary>
    public interface IField<T> : IRing<T>, IStructure<T>
    {
        #region methods

        /// <summary>
        /// Gets the inverse for the ring multiplication.
        /// </summary>
        /// <returns>The inverse.</returns>
        /// <param name="element">Element.</param>
        /// <exception cref="DivideByZeroException">Thrown when the element is the zero element of the underlying group.</exception>
        T MultiplicationInverse(T element);

        #endregion
    }
}