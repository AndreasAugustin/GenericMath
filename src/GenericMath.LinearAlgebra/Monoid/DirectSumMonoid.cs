//  *************************************************************
// <copyright file="DirectSumMonoid.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra
{
    using System;

    using GenericMath.Base;

    /// <summary>
    /// Monoid structure for direct sums.
    /// </summary>
    /// <typeparam name="T">The underlying base set.</typeparam>
    /// <typeparam name="TMonoid">The underlying structure for the base set.</typeparam>
    public class DirectSumMonoid<T, TMonoid> : IMonoid<DirectSum<T, TMonoid>>
        where TMonoid : IMonoid<T>, new()
    {
        #region fields

        private UInt32 _dimension;

        #endregion

        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectSumMonoid{T, TMonoid}"/> class.
        /// </summary>
        /// <param name="dimension">The dimension of the monoid in this class.</param>
        public DirectSumMonoid(UInt32 dimension)
        {
            this._dimension = dimension;
        }

        #endregion

        /// <summary>
        /// Gets the dimension.
        /// </summary>
        /// <value>The dimension.</value>
        public UInt32 Dimension
        {
            get
            {
                return this._dimension;
            }
        }

        #region IMonoid implementation

        /// <summary>
        /// Gets the zero element of the group.
        /// </summary>
        /// <value>The zero.</value>
        public DirectSum<T, TMonoid> Zero
        {
            get
            {
                return new SpecialDirectSums().ZeroTuple<T, TMonoid>(this.Dimension);
            }
        }

        /// <summary>
        /// Addition of the specified leftElement and rightElement.
        /// </summary>
        /// <param name="leftElement">Left element.</param>
        /// <param name="rightElement">Right element.</param>
        /// <returns>The addition of the leftElement and rightElement (leftElement + rightElement)</returns>
        /// <exception cref="InvalidCastException">When the cast was not possible.</exception>
        /// <exception cref="NotSupportedException">When the dimension of the parameters is not equal to the set dimension of the instance.</exception>
        public DirectSum<T, TMonoid> Addition(
            DirectSum<T, TMonoid> leftElement,
            DirectSum<T, TMonoid> rightElement)
        {
            if (leftElement.Dimension != this.Dimension)
            {
                throw new NotSupportedException("The dimension is not set right");
            }
                
            var tuple = leftElement.Add(rightElement) as DirectSum<T, TMonoid>;

            if (tuple == null)
            {
                throw new InvalidCastException();
            }

            return tuple;
        }

        #endregion
    }
}