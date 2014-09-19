//  *************************************************************
// <copyright file="DirectSumMonoid.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

    /// <summary>
    /// Monoid structure for direct sums.
    /// </summary>
    /// <typeparam name="T">The underlying base set.</typeparam>
    /// <typeparam name="TMonoid">The underlying structure for the base set.</typeparam>
    public class DirectSumMonoid<T, TMonoid> : IMonoid<IDirectSum<T, TMonoid>>
        where TMonoid : IMonoid<T>, new()
    {
        #region fields

        /// <summary>
        /// The dimension.
        /// </summary>
        protected UInt32 Dimension;

        #endregion

        #region ctors

        /// <summary>
        /// Initialises a new instance of the <see cref="DirectSumMonoid{T, TStruct}"/> class.
        /// </summary>
        /// <param name="dimension">Dimension.</param>
        public DirectSumMonoid(UInt32 dimension)
        {
            Dimension = dimension;
        }

        #endregion

        #region IMonoid implementation

        /// <summary>
        /// Addition of the specified leftElement and rightElement.
        /// </summary>
        /// <param name="leftElement">Left element.</param>
        /// <param name="rightElement">Right element.</param>
        /// <returns>The addition of the leftElement and rightElement (leftElement + rightElement)</returns>
        public IDirectSum<T, TMonoid> Addition(IDirectSum<T, TMonoid> leftElement, IDirectSum<T, TMonoid> rightElement)
        {
            return leftElement.Add(rightElement);
        }

        /// <summary>
        /// Gets the zero element of the group.
        /// </summary>
        /// <value>The zero.</value>
        public IDirectSum<T, TMonoid> Zero
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}