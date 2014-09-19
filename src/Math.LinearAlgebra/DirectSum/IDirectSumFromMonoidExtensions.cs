//  *************************************************************
// <copyright file="IDirectSumFromMonoidExtensions.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

    /// <summary>
    /// Extensions methods for the <see cref="DirectSum{T, TStruct}"/> class.
    /// TStruct needs to be of type <see cref="IMonoid{T}"/>
    /// </summary>
    public static class IDirectSumFromMonoidExtensions
    {
        #region methods

        /// <summary>
        /// Adds all the elements in the vector.
        /// </summary>
        /// <returns>The sum over all elements in the vector.</returns>
        /// <param name="vector">The vector.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static T SumElements<T, TStruct>(this IDirectSum<T, TStruct> vector)
            where TStruct : IMonoid<T>, new()
        {
            var group = new TStruct();

            var result = group.Zero;

            for (UInt32 i = 0; i < vector.Dimension; i++)
            { // sum over all entries
                result = group.Addition(result, vector[i]);
            }

            return result;
        }

        /// <summary>
        /// Add the specified vector1 and vector2.
        /// </summary>
        /// <param name="tuple1">The left vector.</param>
        /// <param name="tuple2">The right vector.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TMonoid">The underlying structure.</typeparam>
        /// <returns>vector1 + vector2.</returns>
        public static IDirectSum<T, TMonoid> Add<T, TMonoid>(this IDirectSum<T, TMonoid> tuple1, IDirectSum<T, TMonoid> tuple2)
            where TMonoid : IMonoid<T>, new()
        {
            var group = new TMonoid();
            // Todo trhow right exception
            if (tuple1.Dimension != tuple2.Dimension)
                throw new IndexOutOfRangeException("The dimension of the two vectors do not agree");

            var result = tuple1.ReturnNewInstance(tuple1.Dimension);

            for (UInt32 i = 0; i < tuple1.Dimension; i++)
            {
                result[i] = group.Addition(tuple1[i], tuple2[i]); 
            }

            return result;
        }

        /// <summary>
        /// Increases the vector Dimension by additionalDimensions.
        /// The values of the parameters are default(T).
        /// </summary>
        /// <param name="vector">The Vector.</param>
        /// <param name="additionalDimensions">Additional dimensions.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>A new vector with dimension dimension(original vector) + additionalDimension.
        /// The first values are the values of the original vector. The other values are the zero elements of the group
        /// associated with T.
        /// </returns>
        public static IDirectSum<T, TStruct> Injection<T, TStruct>(this IDirectSum<T, TStruct> vector, UInt32 additionalDimensions)
            where TStruct : IMonoid<T>, new()
        {
            var newDimension = vector.Dimension + additionalDimensions;
            var group = new TStruct();

            var vec = new SpecialDirectSums().ZeroVector<T, TStruct>(vector.Dimension + additionalDimensions);

            for (UInt32 i = 0; i < newDimension; i++)
            {
                if (i < vector.Dimension)
                {
                    vec[i] = vector[i];
                    continue;
                }

                vec[i] = group.Zero;
            }

            return vec;
        }

        #endregion
    }
}