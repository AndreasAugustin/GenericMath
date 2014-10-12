// *************************************************************
// <copyright file="ComplexMonoid.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base
{
    using System.Numerics;

    /// <summary>
    /// Monoid for complex numbers.
    /// </summary>
    public class ComplexMonoid : IMonoid<Complex>
    {
        #region IGroup implementation

        #region properties

        /// <summary>
        /// Gets the zero element of the group.
        /// </summary>
        /// <value>The zero.</value>
        public Complex Zero
        {
            get
            {
                return Complex.Zero;
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
        public Complex Addition(Complex leftElement, Complex rightElement)
        {
            return leftElement + rightElement;
        }

        #endregion

        #endregion

        #region OVERRIDES OF OBJECT

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="ComplexMonoid"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="ComplexMonoid"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "[{0}: Zero={1}, Generic argument type: {2}]",
                this.GetType().Name,
                this.Zero,
                typeof(Complex));
        }

        #endregion
    }
}