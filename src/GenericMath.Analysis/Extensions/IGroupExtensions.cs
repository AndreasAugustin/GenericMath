//  *************************************************************
// <copyright file="IGroupExtensions.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Analysis
{
    using System;

    using GenericMath.Base;

    /// <summary>
    /// Extension methods for <see cref="IGroup{T}"/> classes.
    /// </summary>
    public static class IGroupExtensions
    {
        #region methods

        /// <summary>
        /// Inverse function with values in T.
        /// </summary>
        /// <returns>The zero function.</returns>
        /// <param name="group">The group.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <param name = "function">The function.</param>
        public static Func<T, T> InverseFunction<T>(
            this IGroup<T> group,
            Func<T, T> function)
        {
            return (x) => group.Inverse(function(x));
        }

        #endregion
    }
}