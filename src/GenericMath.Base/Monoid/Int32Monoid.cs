//  *************************************************************
// <copyright file="Int32Monoid.cs" company="SuperDevelop">
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
    /// Monoid structure for Integer.
    /// </summary>
    public class Int32Monoid : IMonoid<int>
    {
        #region implementation of IMonoid

        #region properties

        /// <summary>
        /// Gets the zero element of the group.
        /// </summary>
        /// <value>The zero.</value>
        public Int32 Zero
        {
            get
            {
                return 0;
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
        public Int32 Addition(Int32 leftElement, Int32 rightElement)
        {
            return leftElement + rightElement;
        }

        #endregion

        #endregion

        #region OVERRIDES OF OBJECT

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Int32Monoid"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Int32Monoid"/>.</returns>
        public override String ToString()
        {
            return String.Format(
                "[{0}: Zero={1}, Generic argument type: {2}]",
                this.GetType().Name,
                this.Zero,
                typeof(Int32));
        }

        #endregion
    }
}