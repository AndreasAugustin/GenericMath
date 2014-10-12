// *************************************************************
// <copyright file="ComplexRing.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 7 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Complex ring. Mathematical ring for complex values.
    /// </summary>
    public class ComplexRing : ComplexGroup, IRing<Complex>
    {
        #region properties

        #region IRing implementation

        /// <summary>
        /// Gets the one element of the ring.
        /// </summary>
        /// <value>The one.</value>
        public Complex One
        {
            get
            {
                return Complex.One;
            }
        }

        #endregion

        #endregion

        #region methods

        #region IRing implementation

        /// <summary>
        /// Multiplication of the specified leftElement and rightElement.
        /// </summary>
        /// <param name="leftElement">Left element.</param>
        /// <param name="rightElement">Right element.</param>
        /// <returns>The multiplication of the leftElement and rightElement (leftElement * rightElement)</returns>
        public Complex Multiplication(
            Complex leftElement,
            Complex rightElement)
        {
            return leftElement * rightElement;
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
                "[{0}: Zero={1}, One={2}, Generic argument type: {3}]",
                this.GetType().Name,
                this.Zero,
                this.One,
                typeof(Complex));
        }

        #endregion
    }
}