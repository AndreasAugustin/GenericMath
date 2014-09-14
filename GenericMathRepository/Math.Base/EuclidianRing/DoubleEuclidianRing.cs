//  *************************************************************
// <copyright file="DoubleEuclidianRing.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0 15/7/ 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    using System;

    /// <summary>
    /// Double calculator.
    /// </summary>
    public class DoubleEuclidianRing : DoubleRing, IEuclidianRing<Double>
    {
        #region methods

        #region IEuclidianRing implementation

        /// <summary>
        /// Calculates the norm of element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The norm of element.</returns>
        public Double Norm(Double element)
        {
            return Math.Abs(element);
        }

        #endregion

        #endregion

        #region OVERRIDES OF OBJECT

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return String.Format("[{0}: Zero={1}, Generic argument type: {2}]", this.GetType().Name, this.Zero, typeof(Double));
        }

        #endregion
    }
}