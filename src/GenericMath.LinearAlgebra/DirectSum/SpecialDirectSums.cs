//  *************************************************************
// <copyright file="SpecialDirectSums.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  17 / 7 / 2014 Created the Class
// *************************************************************

namespace GenericMath.LinearAlgebra
{
    using System;

    using GenericMath.Base;

    /// <summary>
    /// Special vectors.
    /// </summary>
    public class SpecialDirectSums
    {
        #region methods

        /// <summary>
        /// Returns a vector with default(T) as values.
        /// </summary>
        /// <returns>The vector.</returns>
        /// <param name="dimension">The dimension.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>The zerovector with dimension.</returns>
        public DirectSum<T, TStruct> ZeroTuple<T, TStruct>(UInt32 dimension)
            where TStruct : IMonoid<T>, new()
        {
            var tuple = new DirectSum<T, TStruct>(dimension);
            var baseStructure = new TStruct();

            for (UInt32 i = 0; i < tuple.Dimension; i++)
            {
                tuple[i] = baseStructure.Zero;
            }

            return tuple;
        }

        /// <summary>
        /// Returns a vector with ones as values.
        /// </summary>
        /// <returns>The vector.</returns>
        /// <param name="dimension">The dimension.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        /// <returns>The zerovector with dimension.</returns>
        public DirectSum<T, TStruct> OneTuple<T, TStruct>(UInt32 dimension)
            where TStruct : IRing<T>, new()
        {
            var tuple = new DirectSum<T, TStruct>(dimension);
            var baseStructure = new TStruct();

            for (UInt32 i = 0; i < tuple.Dimension; i++)
            {
                tuple[i] = baseStructure.One;
            }

            return tuple;
        }

        #endregion
    }
}