//  *************************************************************
// <copyright file="IGroupExtensions.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.Analysis
{
    using System;

    using Math.Base;

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
        public static Func<T, T> InverseFunction<T>(this IGroup<T> group, Func<T, T> function)
        {
            return (x) => group.Inverse(function(x));
        }

        #endregion
    }
}