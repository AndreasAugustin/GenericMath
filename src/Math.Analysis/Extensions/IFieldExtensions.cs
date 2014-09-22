//  *************************************************************
// <copyright file="IFieldExtensions.cs" company="${Company}">
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
    /// Extension methods for <see cref="IField{T}"/> classes
    /// </summary>
    public static class IFieldExtensions
    {
        /// <summary>
        /// Multiplications the inverse function.
        /// </summary>
        /// <returns>The inverse function.</returns>
        /// <param name="field">Field.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <exception cref="DivideByZeroException">Thrown when the argument for calculating 
        /// the function is the zero element of the field.</exception>
        public static Func<T,T> MultiplicationInverseFunction<T>(IField<T> field)
        {
            return (x) =>
            {
                if (x.Equals(field.Zero))
                    throw new DivideByZeroException();

                return field.MultiplicationInverse(x);
            };
        }
    }
}