//  *************************************************************
// <copyright file="IInterval.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base
{
    using System;

    /// <summary>
    /// Interface for defining intervals for a set T.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure for the elements.</typeparam>
    public interface IInterval<T, TStruct>
        where T : IComparable
        where TStruct : IStructure<T>, new()
    {
        /// <summary>
        /// Gets the max element.
        /// </summary>
        /// <value>The max element.</value>
        T MaxElement { get; }

        /// <summary>
        /// Gets the minimum element.
        /// </summary>
        /// <value>The minimum element.</value>
        T MinElement { get; }

        /// <summary>
        /// Determines whether this element is within interval.
        /// </summary>
        /// <returns><c>true</c> if the element lies in the interval; otherwise, <c>false</c>.</returns>
        /// <param name="elementToCheck">Element to check.</param>
        Boolean IsinInterval(T elementToCheck);
    }
}