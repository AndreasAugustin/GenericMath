//  *************************************************************
// <copyright file="Int32Group.cs" company="${Company}">
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
    /// Integer group. Mathematical group for integer values.
    /// </summary>
    public class Int32Group : Int32Monoid, IGroup<Int32>
    {
        #region IGroup implementation

        #region methods

        /// <summary>
        /// Returns the inverse of the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The inverse of element (-element)</returns>
        public Int32 Inverse(Int32 element)
        {
            return -element;
        }

        #endregion

        #endregion

        #region OVERRIDES OF OBJECT

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Int32Group"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Int32Group"/>.</returns>
        public override String ToString()
        {
            return String.Format("[{0}: Zero={1}, Generic argument type: {2}]", this.GetType().Name, this.Zero, typeof(Int32));
        }

        #endregion
    }
}