//  *************************************************************
// <copyright file="DoubleRing.cs" company="SuperDevelop">
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

    /// <summary>
    /// Double ring. Mathematical ring for Double values.
    /// </summary>
    public class DoubleRing : DoubleGroup, IRing<Double>
    {
        #region properties

        #region implementation of IRing

        /// <summary>
        /// Gets the one element of the ring.
        /// </summary>
        /// <value>The one.</value>
        public Double One
        {
            get
            {
                return 1.0;
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
        public Double Multiplication(Double leftElement, Double rightElement)
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
                "[{0}: Zero={1}, One={2} Generic argument type: {3}]",
                this.GetType().Name,
                this.Zero,
                this.One,
                typeof(Double));
        }

        #endregion
    }
}