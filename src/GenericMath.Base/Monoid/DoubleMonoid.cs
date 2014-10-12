//  *************************************************************
// <copyright file="DoubleMonoid.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base
{
    using System;

    /// <summary>
    /// Monoid for real numbers.
    /// </summary>
    public class DoubleMonoid : IMonoid<double>
    {
        #region implementation of IGroup

        #region properties

        /// <summary>
        /// Gets the zero element of the group.
        /// </summary>
        /// <value>The zero.</value>
        public Double Zero
        {
            get
            {
                return 0.0;
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Addition of the specified leftElement and rightElement.
        /// </summary>
        /// <param name="leftElement">Left element.</param>
        /// <param name="rightElement">Right element.</param>
        /// <returns>The addition of the leftElement and rightElement (leftElement + rightElement)</returns>
        public Double Addition(Double leftElement, Double rightElement)
        {
            return leftElement + rightElement;
        }

        #endregion

        #endregion

        #region overrides of object

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="DoubleGroup"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="DoubleGroup"/>.</returns>
        public override String ToString()
        {
            return String.Format(
                "[{0}: Zero={1}, Generic argument type: {2}]",
                this.GetType().Name,
                this.Zero,
                typeof(double));
        }

        #endregion
    }
}