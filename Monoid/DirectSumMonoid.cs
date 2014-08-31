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
    /// <typeparam name="TStruct">The underlying structure for the base set.</typeparam>
    public class DirectSumMonoid<T, TStruct> : IMonoid<IDirectSum<T, TStruct>>
        where TStruct : IMonoid<T>
    {
        #region fields

        UInt32 _dimension;

        #endregion

        #region ctors

        /// <summary>
        /// Initialises a new instance of the <see cref="DirectSumMonoid{T, TStruct}"/> class.
        /// </summary>
        /// <param name="dimension">Dimension.</param>
        public DirectSumMonoid(UInt32 dimension)
        {
            _dimension = dimension;
        }

        #endregion

        #region IMonoid implementation

        /// <summary>
        /// Addition of the specified leftElement and rightElement.
        /// </summary>
        /// <param name="leftElement">Left element.</param>
        /// <param name="rightElement">Right element.</param>
        /// <returns>The addition of the leftElement and rightElement (leftElement + rightElement)</returns>
        public IDirectSum<T, TStruct> Addition(IDirectSum<T, TStruct> leftElement, IDirectSum<T, TStruct> rightElement)
        {
            return leftElement.Add(rightElement);
        }

        /// <summary>
        /// Gets the zero element of the group.
        /// </summary>
        /// <value>The zero.</value>
        public IDirectSum<T, TStruct> Zero
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}