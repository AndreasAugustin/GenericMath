//  *************************************************************
// <copyright file="VectorFromGroupExtensions.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  18 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

    /// <summary>
    /// Extension methods for the <see cref="Vector{T, TStruct}"/> class.
    /// </summary>
    public static class IVectorFromGroupExtensions
    {
        #region methods

        /// <summary>
        /// Returns a vector with inverse values of the given vector.
        /// </summary>
        /// <returns>The inverse vector.</returns>
        /// <param name="vector">The vector.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IVector<T, TStruct> InverseVector<T, TStruct>(this IVector<T, TStruct> vector)
            where TStruct : IGroup<T>, new()
        {
            var vec = vector.ReturnNewInstanceWithSameDimension();
            var baseStruct = new TStruct();

            for (UInt32 i = 0; i < vec.Dimension; i++)
            {
                vec[i] = baseStruct.Inverse(vector[i]);
            }

            return vec;
        }

        #endregion
    }
}