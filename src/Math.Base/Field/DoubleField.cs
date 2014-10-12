//  *************************************************************
// <copyright file="DoubleField.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    using System;

    public class DoubleField : DoubleRing, IField<double>
    {
        #region IFIELD implementaiton

        /// <summary>
        /// Gets the inverse for the ring multiplication.
        /// </summary>
        /// <returns>The inverse.</returns>
        /// <param name="element">The element.</param>
        /// <exception cref="DivideByZeroException">Thrown when the element is the zero element.</exception>
        public double MultiplicationInverse(double element)
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