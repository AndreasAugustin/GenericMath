//  *************************************************************
// <copyright file="DirectSumGroup.cs" company="${Company}">
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
    /// Direct sum group.
    /// </summary>
    public class DirectSumGroup<T, TGroup> : DirectSumMonoid<T, TGroup>, IGroup<IDirectSum<T, TGroup>>
        where TGroup : IGroup<T>, new()
    {
        #region ctors

        /// <summary>
        /// Initialises a new instance of the <see cref="DirectSumGroup{T, TStruct}"/> class.
        /// </summary>
        /// <param name="dimension">Dimension.</param>
        public DirectSumGroup(UInt32 dimension)
            : base(dimension)
        {
            base.Dimension = dimension;
        }

        #endregion

        #region IGROUP implementation

        /// <summary>
        /// Returns the inverse of the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The inverse of element (-element)</returns>
        public IDirectSum<T, TGroup> Inverse(IDirectSum<T, TGroup> element)
        {
            return element.InverseElement();
        }

        #endregion
    }
}