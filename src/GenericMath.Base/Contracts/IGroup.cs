//  *************************************************************
// <copyright file="IGroup.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  26 / 7 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base
{
    /// <summary>
    /// Interface for defining group structures.
    /// </summary>
    /// <typeparam name="T">The type parameter is the set of the elements for the group.</typeparam>
    public interface IGroup<T> : IMonoid<T>, IStructure<T>
    {
        #region methods

        /// <summary>
        /// Returns the inverse of the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The inverse of element (-element)</returns>
        T Inverse(T element);

        #endregion
    }
}