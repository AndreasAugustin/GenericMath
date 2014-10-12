//  *************************************************************
// <copyright file="IRingExtensions.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  17 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base
{
    using System;

    /// <summary>
    /// Extension methods for Rings.
    /// </summary>
    public static class IRingExtensions
    {
        /// <summary>
        /// Multiplies the specified element power times.
        /// </summary>
        /// <param name="ring">The ring.</param>
        /// <param name="element">The element.</param>
        /// <param name="power">The power.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns>The result.</returns>
        public static T Pow<T>(this IRing<T> ring, T element, uint power)
        {
            var result = ring.One;
            for (var i = 0; i < power; i++)
            {
                result = ring.Multiplication(element, result);
            }

            return result;
        }
    }
}