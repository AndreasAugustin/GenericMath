//  *************************************************************
// <copyright file="DoubleGroup.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 7 / 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    using System;

    /// <summary>
    /// Double group. Mathematical group for Double values.
    /// </summary>
    public class DoubleGroup : DoubleMonoid, IGroup<Double>
    {
        #region methods

        #region IGroup implementation

        /// <summary>
        /// Returns the inverse of the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The inverse of element (-element)</returns>
        public Double Inverse(Double element)
        {
            return -element;
        }

        #endregion

        #endregion

        #region OVERRIDES OF OBJECT

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="DoubleGroup"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="DoubleGroup"/>.</returns>
        public override string ToString()
        {
            return String.Format("[{0}: Zero={1}, Generic argument type: {2}]", this.GetType().Name, this.Zero, typeof(Double));
        }

        #endregion
    }
}