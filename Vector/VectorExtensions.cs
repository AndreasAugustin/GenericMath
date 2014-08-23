//  *************************************************************
// <copyright file="VectorExtensions.cs" company="${Company}">
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
    public static class VectorExtensions
    {
        #region methods

        /// <summary>
        /// Copy the specified vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>A copy of the vector.</returns>
        public static Vector<T, TStruct> Copy<T, TStruct>(this Vector<T, TStruct> vector)
            where TStruct : IStructure<T>, new()
        {
            var vec = new Vector<T, TStruct>(vector.Dimension);
            for (UInt32 i = 0; i < vector.Dimension; i++)
            {
                vec[i] = vector[i];
            }

            return vec;
        }

        /// <summary>
        /// Sorts the vector with insertion sort method.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="vector">The sorted vector is a new vector, not a reference to the argument.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static Vector<T, TStruct> InsertionSort<T, TStruct>(this Vector<T, TStruct> vector)
            where T : IComparable where TStruct : IStructure<T>, new()
        {
            var vec = vector.Copy();
            if (vector.Dimension < 2)
                return vec;

            for (UInt32 j = 1; j < vec.Dimension; j++)
            {
                var key = vec[j];

                // insert vector[i] into the sorted sequence vector[1..i-1]
                UInt32 i = j - 1;
                while (i >= 0 && vec[i].CompareTo(key) > 0)
                {
                    vec[i + 1] = vec[i];                   
                    vec[i] = key;

                    if (i == 0) // Security because UI
                        break;

                    i--;
                }
            }

            return vec;
        }

        /// <summary>
        /// Sorts the vector with bubble sort algorithm.
        /// </summary>
        /// <returns>A copy of the vector (sorted).</returns>
        /// <param name="vector">The vector.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static Vector<T, TStruct> BubbleSort<T, TStruct>(this Vector<T, TStruct> vector) 
            where T : IComparable where TStruct : IStructure<T>, new()
        {
            var vec = vector.Copy();

            if (vec.Dimension <= 1)
                return vec;

            for (var i = 0; i < vec.Dimension - 1; i++)
            {
                for (var j = vec.Dimension - 1; j > i; j--)
                {
                    if (vec[j].CompareTo(vec[j - 1]) < 0)
                    {
                        var temp = vec[j];
                        vec[j] = vec[j - 1];
                        vec[j - 1] = temp;
                    }
                }
            }

            return vec;
        }

        #endregion
    }
}