//  *************************************************************
// <copyright file="DirectSumRing.cs" company="${Company}">
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
    /// Direct sum ring.
    /// </summary>
    public class DirectSumRing<T, TRing> : DirectSumGroup<T, TRing>, IRing<IDirectSum<T, TRing>>
        where TRing : IRing<T>, new()
    {
        #region ctors

        /// <summary>
        /// Initialises a new instance of the <see cref="DirectSumRing{T, TRing}"/> class.
        /// </summary>
        /// <param name="dimension">Dimension.</param>
        public DirectSumRing(UInt32 dimension)
            : base(dimension)
        {

        }

        #endregion

        #region IRING implementation

        /// <summary>
        /// Multiplication of the specified leftElement and rightElement.
        /// </summary>
        /// <param name="leftElement">Left element.</param>
        /// <param name="rightElement">Right element.</param>
        /// <returns>The multiplication of the leftElement and rightElement (leftElement * rightElement)</returns>
        public IDirectSum<T, TRing> Multiplication(IDirectSum<T, TRing> leftElement, IDirectSum<T, TRing> rightElement)
        {
            return leftElement.Multiply(rightElement);
        }

        /// <summary>
        /// Gets the one element of the ring.
        /// </summary>
        /// <value>The one.</value>
        public IDirectSum<T, TRing> One
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}