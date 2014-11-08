//  *************************************************************
// <copyright file="DoubleField.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base
{
    using System;

    /// <summary>
    /// Field structure with double values.
    /// </summary>
    public class DoubleField : DoubleRing, IField<Double>
    {
        #region IFIELD implementaiton

        /// <summary>
        /// Gets the inverse for the ring multiplication.
        /// </summary>
        /// <returns>The inverse.</returns>
        /// <param name="element">The element.</param>
        /// <exception cref="DivideByZeroException">Thrown when the element is the zero element.</exception>
        public Double MultiplicationInverse(Double element)
        {
            if (Math.Abs(element) < double.Epsilon)
            {
                throw new DivideByZeroException("Cannot divide through zero");
            }
                
            return 1 / element;
        }

        #endregion
    }
}