//  *************************************************************
// <copyright file="IMonoidExtensions.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
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
    /// Extension methods for IGroup.
    /// </summary>
    public static class IMonoidExtensions
    {
        #region methods

        /// <summary>
        /// Addition of leftFunction and rightFunction.
        /// The component addition is defined in calculator on T.
        /// </summary>
        /// <param name="monoid">The calculator.</param>
        /// <param name="leftFunction">Left function.</param>
        /// <param name="rightFunction">Right function.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns>The Addition of the left function with the right function.</returns>
        public static Func<T, T, T> Addition<T>(
            this IMonoid<T> monoid,
            Func<T, T, T> leftFunction,
            Func<T, T, T> rightFunction)
        {
            return (left, right) => monoid.Addition(
                leftFunction(left, right),
                rightFunction(left, right));
        }

        /// <summary>
        /// Addition of leftFunction and rightFunction.
        /// The component addition is defined in calculator on T.
        /// </summary>
        /// <param name="monoid">The calculator.</param>
        /// <param name="leftFunction">Left function.</param>
        /// <param name="rightFunction">Right function.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns>The Addition of the left function with the right function.</returns>
        public static Func<T, T> Addition<T>(
            this IMonoid<T> monoid,
            Func<T, T> leftFunction,
            Func<T, T> rightFunction)
        {
            return (x) => monoid.Addition(leftFunction(x), rightFunction(x));
        }

        /// <summary>
        /// Zero function with values in T.
        /// </summary>
        /// <returns>The zero function.</returns>
        /// <param name="monoid">The monoid.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static Func<T, T> ZeroFunction<T>(this IMonoid<T> monoid)
        {
            return (x) => monoid.Zero;
        }

        #endregion
    }
}