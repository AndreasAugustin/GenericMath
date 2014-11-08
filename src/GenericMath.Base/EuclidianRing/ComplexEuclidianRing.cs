//  *************************************************************
// <copyright file="ComplexEuclidianRing.cs" company="None">
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
    /// Complex calculator.
    /// </summary>
    public class ComplexEuclidianRing : ComplexRing, IEuclidianRing<Complex>
    {
        #region methods

        #region IEuclidianRing implementation

        /// <summary>
        /// Calculates the norm of element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The norm of element.</returns>
        public Double Norm(Complex element)
        {
            return Complex.Abs(element);
        }

        #endregion

        #endregion

        #region OVERRIDES OF OBJECT

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override String ToString()
        {
            return String.Format(
                "[{0}: Zero={1}, Generic argument type: {2}]",
                this.GetType().Name,
                this.Zero,
                typeof(Complex));
        }

        #endregion
    }
}
