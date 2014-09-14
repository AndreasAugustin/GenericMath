//  *************************************************************
// <copyright file="IEuclidianRing.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0 15/7/ 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    using System;

    /// <summary>
    /// Interface for the calculators.
    /// </summary>
    /// <typeparam name="T">Refers to the object for the calculations.</typeparam>
    public interface IEuclidianRing<T> : IRing<T>
    {
        #region METHODS

        /// <summary>
        /// Calculates the norm of element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The norm of element.</returns>
        Double Norm(T element);

        #endregion
    }
}