//  *************************************************************
// <copyright file="IMonoid.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    /// <summary>
    /// Interface for creating monoid structures.
    /// </summary>
    /// <typeparam name="T">The underlying Set.</typeparam>
    public interface IMonoid<T> : IStructure<T>
    {
        #region properties

        /// <summary>
        /// Gets the zero element of the group.
        /// </summary>
        /// <value>The zero.</value>
        T Zero { get; }

        #endregion

        #region methods

        /// <summary>
        /// Addition of the specified leftElement and rightElement.
        /// </summary>
        /// <param name="leftElement">Left element.</param>
        /// <param name="rightElement">Right element.</param>
        /// <returns>The addition of the leftElement and rightElement (leftElement + rightElement)</returns>
        T Addition(T leftElement, T rightElement);

        #endregion
    }
}