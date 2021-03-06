﻿//  *************************************************************
// <copyright file="IRingExtensions.cs" company="None">
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