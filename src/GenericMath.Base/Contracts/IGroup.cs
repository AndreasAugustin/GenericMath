//  *************************************************************
// <copyright file="IGroup.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
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