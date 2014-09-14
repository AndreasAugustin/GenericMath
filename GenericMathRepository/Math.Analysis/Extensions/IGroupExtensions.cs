//  *************************************************************
// <copyright file="IGroupExtensions.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  11 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Analysis
{
    using System;

    using Math.Base;

    /// <summary>
    /// Extension methods for IGroup.
    /// </summary>
    public static class IGroupExtensions
    {
        /// <summary>
        /// Addition of leftFunction and rightFunction.
        /// The component addition is defined in calculator on T.
        /// </summary>
        /// <param name="group">The calculator.</param>
        /// <param name="leftFunction">Left function.</param>
        /// <param name="rightFunction">Right function.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns>The Addition of the left function with the right function.</returns>
        public static Func<T, T, T> Addition<T>(this IGroup<T> group, Func<T, T, T> leftFunction, Func<T, T, T> rightFunction)
        {
            return (left, right) => group.Addition(leftFunction(left, right), rightFunction(left, right));
        }

        /// <summary>
        /// Addition of leftFunction and rightFunction.
        /// The component addition is defined in calculator on T.
        /// </summary>
        /// <param name="group">The calculator.</param>
        /// <param name="leftFunction">Left function.</param>
        /// <param name="rightFunction">Right function.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns>The Addition of the left function with the right function.</returns>
        public static Func<T, T> Addition<T>(this IGroup<T> group, Func<T, T> leftFunction, Func<T, T> rightFunction)
        {
            return (x) => group.Addition(leftFunction(x), rightFunction(x));
        }

        /// <summary>
        /// Zero function with values in T.
        /// </summary>
        /// <returns>The zero function.</returns>
        /// <param name="group">The group.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static Func<T, T> ZeroFunction<T>(this IGroup<T> group)
        {
            return (x) => group.Zero;
        }

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
    }
}