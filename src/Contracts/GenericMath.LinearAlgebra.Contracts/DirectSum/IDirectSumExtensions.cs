//  *************************************************************
// <copyright file="IDirectSumExtensions.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra.Contracts
{
    using System;
    using GenericMath.Base.Contracts;
    using GenericMath.LinearAlgebra.Contracts;

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
        public static IDirectSum<T, TStruct> Copy<T, TStruct> (this IDirectSum<T, TStruct> tuple)
            where TStruct : IStructure<T>, new()
        {
            var vec = tuple.ReturnNewInstance(tuple.Dimension);

            for (UInt32 i = 0; i < tuple.Dimension; i++) {
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
        public static IDirectSum<T, TStruct> InsertionSort<T, TStruct> (this IDirectSum<T, TStruct> tuple)
            where T : IComparable
            where TStruct : IStructure<T>, new()
        {
            var vec = tuple.Copy();
            if (tuple.Dimension < 2) {
                return vec;
            }
                
            for (UInt32 j = 1; j < vec.Dimension; j++) {
                var key = vec[j];

                // insert vector[i] into the sorted sequence vector[1..i-1]
                UInt32 i = j - 1;
                while (i >= 0 && vec[i].CompareTo(key) > 0) {
                    vec[i + 1] = vec[i];                   
                    vec[i] = key;

                    // Security because UInt32
                    if (i == 0) {
                        break;
                    }
                        
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
        public static IDirectSum<T, TStruct> BubbleSort<T, TStruct> (this IDirectSum<T, TStruct> tuple) 
            where T : IComparable
            where TStruct : IStructure<T>, new()
        {
            var vec = tuple.Copy();

            if (vec.Dimension <= 1) {
                return vec;
            }

            for (var i = 0; i < vec.Dimension - 1; i++) {
                for (var j = vec.Dimension - 1; j > i; j--) {
                    if (vec[j].CompareTo(vec[j - 1]) < 0) {
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