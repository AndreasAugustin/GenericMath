//  *************************************************************
// <copyright file="ComplexField.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Complex field.
    /// </summary>
    public class ComplexField : ComplexRing, IField<Complex>
    {
        /// <summary>
        /// Gets the inverse for the ring multiplication.
        /// </summary>
        /// <returns>The inverse.</returns>
        /// <param name="element">The element.</param>
        /// <exception cref="DivideByZeroException">Thrown when the element is the zero element of the underlying group.</exception>
        public Complex MultiplicationInverse(Complex element)
        {
            if (element == Complex.Zero)
            {
                throw new DivideByZeroException();
            }
                
            return Complex.Reciprocal(element);
        }
    }
}