//  *************************************************************
// <copyright file="IRingExtensions.cs" company="None">
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
    /// Extension methods for IRings.
    /// </summary>
    public static class IRingExtensions
    {
        #region methods

        /// <summary>
        /// Multiplication of leftFunction and rightFunction.
        /// The component multiplication is defined in calculator on T.
        /// </summary>
        /// <param name="ring">The calculator.</param>
        /// <param name="leftFunction">Left function.</param>
        /// <param name="rightFunction">Right function.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns>The multiplication of the left function with the right function.</returns>
        public static Func<T, T, T> Multiplication<T>(
            this IRing<T> ring,
            Func<T, T, T> leftFunction,
            Func<T, T, T> rightFunction)
        {
            return (left, right) => ring.Multiplication(
                leftFunction(left, right),
                rightFunction(left, right));
        }

        /// <summary>
        /// Multiplication of leftFunction and rightFunction.
        /// The component multiplication is defined in calculator on T.
        /// </summary>
        /// <param name="ring">The calculator.</param>
        /// <param name="leftFunction">Left function.</param>
        /// <param name="rightFunction">Right function.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns>The multiplication of the left function with the right function.</returns>
        public static Func<T, T> Multiplication<T>(
            this IRing<T> ring,
            Func<T, T> leftFunction,
            Func<T, T> rightFunction)
        {
            return (x) => ring.Multiplication(
                leftFunction(x),
                rightFunction(x));
        }

        /// <summary>
        /// One function with values in T.
        /// </summary>
        /// <returns>The one function.</returns>
        /// <param name="ring">The ring.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static Func<T, T> OneFunction<T>(this IRing<T> ring)
        {
            return (x) => ring.One;
        }

        /// <summary>
        /// Multiplication of the multiplication function power times.
        /// </summary>
        /// <param name="ring">The ring.</param>
        /// <param name="power">The power.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns>The result.</returns>
        public static Func<T, T> Pow<T>(this IRing<T> ring, UInt32 power)
        {
            return (x) => ring.Pow(x, power);
        }

        #endregion
    }
}