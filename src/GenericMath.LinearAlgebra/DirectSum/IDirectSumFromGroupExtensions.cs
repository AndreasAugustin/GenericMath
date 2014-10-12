//  *************************************************************
// <copyright file="IDirectSumFromGroupExtensions.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  18 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.LinearAlgebra
{
    using System;

    using GenericMath.Base;

    /// <summary>
    /// Extension methods for the <see cref="DirectSum{T, TStruct}"/> class.
    /// </summary>
    public static class IDirectSumFromGroupExtensions
    {
        #region methods

        /// <summary>
        /// Returns a vector with inverse values of the given vector.
        /// </summary>
        /// <returns>The inverse vector.</returns>
        /// <param name="tuple">The tuple.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TGroup">The underlying structure.</typeparam>
        public static IDirectSum<T, TGroup> InverseElement<T, TGroup>(this IDirectSum<T, TGroup> tuple)
            where TGroup : IGroup<T>, new()
        {
            var vec = tuple.ReturnNewInstance(tuple.Dimension);
            var baseStruct = new TGroup();

            for (UInt32 i = 0; i < vec.Dimension; i++)
            {
                vec[i] = baseStruct.Inverse(tuple[i]);
            }

            return vec;
        }

        #endregion
    }
}