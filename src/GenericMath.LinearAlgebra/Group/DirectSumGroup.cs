//  *************************************************************
// <copyright file="DirectSumGroup.cs" company="None">
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
    /// Direct sum group.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TGroup">The underlying structure</typeparam>
    public class DirectSumGroup<T, TGroup> : DirectSumMonoid<T, TGroup>, IGroup<DirectSum<T, TGroup>>
        where TGroup : IGroup<T>, new()
    {
        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectSumGroup{T, TGroup}"/> class.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        public DirectSumGroup(UInt32 dimension)
            : base(dimension)
        {
            // Nothing to do here
        }

        #endregion

        #region IGROUP implementation

        /// <summary>
        /// Returns the inverse of the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The inverse of element (-element)</returns>
        /// <exception cref="InvalidCastException">When the cast to DirectSum from interface was not possible</exception>
        public DirectSum<T, TGroup> Inverse(DirectSum<T, TGroup> element)
        {
            var tuple = element.InverseElement() as DirectSum<T, TGroup>;

            if (tuple == null)
            {
                throw new InvalidCastException();
            }
                
            return tuple;
        }

        #endregion
    }
}