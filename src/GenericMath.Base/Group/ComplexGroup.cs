//  *************************************************************
// <copyright file="ComplexGroup.cs" company="SuperDevelop">
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
    /// Group with complex numbers.
    /// </summary>
    public class ComplexGroup : ComplexMonoid, IGroup<Complex>
    {
        #region methods

        #region IGroup implementation

        /// <summary>
        /// Returns the inverse of the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The inverse of element (-element)</returns>
        public Complex Inverse(Complex element)
        {
            return -element;
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