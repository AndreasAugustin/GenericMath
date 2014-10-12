//  *************************************************************
// <copyright file="IField.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base
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