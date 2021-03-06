﻿//  *************************************************************
// <copyright file="IEuclidianRing.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base.Contracts
{
    using System;

    /// <summary>
    /// Interface for the calculators.
    /// </summary>
    /// <typeparam name="T">Refers to the object for the calculations.</typeparam>
    public interface IEuclidianRing<T> : IRing<T>
    {
        #region methods

        /// <summary>
        /// Calculates the norm of element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The norm of element.</returns>
        double Norm (T element);

        #endregion
    }
}