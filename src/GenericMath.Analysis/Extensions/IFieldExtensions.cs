//  *************************************************************
// <copyright file="IFieldExtensions.cs" company="None">
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
    /// Extension methods for <see cref="IField{T}"/> classes
    /// </summary>
    public static class IFieldExtensions
    {
        /// <summary>
        /// Multiplications the inverse function.
        /// </summary>
        /// <returns>The inverse function.</returns>
        /// <param name="field">The field.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <exception cref="DivideByZeroException">Thrown when the argument for calculating 
        /// the function is the zero element of the field.</exception>
        public static Func<T, T> MultiplicationInverseFunction<T>(this IField<T> field)
        {
            return (x) =>
            {
                if (x.Equals(field.Zero))
                {
                    throw new DivideByZeroException();
                }

                return field.MultiplicationInverse(x);
            };
        }

        /// <summary>
        /// Multiplications the inverse function.
        /// </summary>
        /// <returns>The inverse function.</returns>
        /// <param name="field">The field.</param>
        /// <param name="func">The function (delegate).</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static Func<T, T> MultiplicationInverseFunction<T>(
            this IField<T> field,
            Func<T, T> func)
        {
            return (x) =>
            {
                if (func(x).Equals(field.Zero))
                {
                    throw new DivideByZeroException();
                }

                return field.MultiplicationInverse(func(x));
            };
        }
    }
}