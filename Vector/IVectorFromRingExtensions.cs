//  *************************************************************
// <copyright file="VectorFromRingExtensions.cs" company="${Company}">
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
    /// Extension methods for the <see cref="Vector{T, IStructure}"/> class.
    /// </summary>
    public static class IVectorFromRingExtensions
    {
        #region methods

        /// <summary>
        /// Point multiplication of vector1 and vector2.
        /// The dimensions must agree.
        /// </summary>
        /// <param name="vector1">The left vector.</param>
        /// <param name="vector2">The right.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>The multiplication vector1 * vector2.</returns>
        public static IVector<T, TStruct> Multiply<T, TStruct>(this IVector<T, TStruct> vector1, IVector<T, TStruct> vector2)
            where TStruct : IRing<T>, new()
        {
            if (vector1.Dimension != vector2.Dimension)
                throw new IndexOutOfRangeException("The vector dimensions need to agree");

            var ring = new TStruct();

            var result = vector1.ReturnNewInstanceWithSameDimension();

            for (UInt32 i = 0; i < vector1.Dimension; i++)
            {
                result[i] = ring.Multiplication(vector1[i], vector2[i]);
            }

            return result;
        }

        /// <summary>
        /// Multiplies the vector power times.
        /// Multiplies the vector with itself power times.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="power">The power.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>The vector^power.</returns>
        public static IVector<T, TStruct> Pow<T, TStruct>(this IVector<T, TStruct> vector, UInt32 power)
            where TStruct : IRing<T>, new()
        {
            var result = new SpecialVectors().OneVector<T, TStruct>(vector.Dimension);

            for (UInt32 i = 0; i < power; i++)
            {
                result = vector.Multiply(result);
            }

            return result;
        }

        /// <summary>
        /// Calculates the scalar product of two vectors.
        /// </summary>
        /// <returns>The product.</returns>
        /// <param name="vector1">The left vector.</param>
        /// <param name="vector2">The right vector.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static T ScalarProduct<T, TStruct>(this IVector<T, TStruct> vector1, IVector<T, TStruct> vector2)
            where TStruct : IRing<T>, new()
        {
            var ring = new TStruct();

            var result = ring.Zero;

            for (UInt32 i = 0; i < vector1.Dimension; i++)
            {
                result = ring.Addition(result, ring.Multiplication(vector1[i], vector2[i]));           
            }

            return result;
        }

        /// <summary>
        /// Multiplies a scalar lambda with a vector v.
        /// </summary>
        /// <returns>lambda * v.</returns>
        /// <param name="vector">The vector.</param>
        /// <param name="scalar">The scalar.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IVector<T, TStruct> ScalarMultiply<T, TStruct>(this IVector<T, TStruct> vector, T scalar)
            where TStruct : IRing<T>, new()
        {
            var ring = new TStruct();
            var vec = vector.ReturnNewInstanceWithSameDimension();

            for (UInt32 i = 0; i < vector.Dimension; i++)
            {
                vec[i] = ring.Multiplication(scalar, vector[i]);
            }

            return vec;
        }

        #endregion
    }
}