//  *************************************************************
// <copyright file="IDirectSumExtensions.cs" company="${Company}">
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
    /// Extension methods for the <see cref="IDirectSum{T, TStruct}"/> class.
    /// </summary>
    public static class IDirectSumExtensions
    {
        #region methods

        /// <summary>
        /// Copy the specified tuple.
        /// </summary>
        /// <returns>A copy of the tuple.</returns>
        /// <param name="tuple">The tuple.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IDirectSum<T, TStruct> Copy<T, TStruct>(this IDirectSum<T, TStruct> tuple)
            where TStruct : IStructure<T>, new()
        {
            var vec = tuple.ReturnNewInstanceWithSameDimension();

            for (UInt32 i = 0; i < tuple.Dimension; i++)
            {
                vec[i] = tuple[i];
            }

            return vec;
        }

        /// <summary>
        /// Sorts the vector with insertion sort method.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="tuple">The sorted vector is a new vector, not a reference to the argument.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IDirectSum<T, TStruct> InsertionSort<T, TStruct>(this IDirectSum<T, TStruct> tuple)
            where T : IComparable
            where TStruct : IStructure<T>, new()
        {
            var vec = tuple.Copy();
            if (tuple.Dimension < 2)
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

                    if (i == 0) // Security because UInt32
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
        /// <param name="tuple">The tuple.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public static IDirectSum<T, TStruct> BubbleSort<T, TStruct>(this DirectSum<T, TStruct> tuple) 
            where T : IComparable where TStruct : IStructure<T>, new()
        {
            var vec = tuple.Copy();

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