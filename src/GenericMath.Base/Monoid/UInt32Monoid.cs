//  *************************************************************
// <copyright file="UInt32Monoid.cs" company="SuperDevelop">
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
    /// Monoid with unsigned integers.
    /// </summary>
    public class UInt32Monoid : IMonoid<uint>
    {
        #region IMonoid implementation

        /// <summary>
        /// Gets the zero element of the group.
        /// </summary>
        /// <value>The zero.</value>
        public UInt32 Zero
        {
            get
            {
                return UInt32.MinValue;
            }
        }

        /// <summary>
        /// Addition of the specified leftElement and rightElement.
        /// </summary>
        /// <param name="leftElement">Left element.</param>
        /// <param name="rightElement">Right element.</param>
        /// <returns>The addition of the leftElement and rightElement (leftElement + rightElement)</returns>
        public UInt32 Addition(UInt32 leftElement, UInt32 rightElement)
        {
            return leftElement + rightElement;
        }

        #endregion
    }
}