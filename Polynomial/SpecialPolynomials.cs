//  *************************************************************
// <copyright file="SpecialPolynomials.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  27 / 7 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;

    using Math.Base;

    /// <summary>
    /// Special polynomials.
    /// </summary>
    public class SpecialPolynomials
    {
        #region fields

        SpecialVectors _specialVectors;

        #endregion

        #region properties

        SpecialVectors SpecialVectors
        {
            get { return _specialVectors ?? (_specialVectors = new SpecialVectors()); }
        }

        #endregion

        #region methods

        /// <summary>
        /// Creates the zeros polynomial for dimension.
        /// </summary>
        /// <returns>The polynomial.</returns>
        /// <param name="dimension">The dimension.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public Polynomial<T, TStruct> ZeroPolynomial<T, TStruct>(UInt32 dimension)
            where TStruct : IGroup<T>, new()
        {
            return new Polynomial<T, TStruct>(SpecialVectors.ZeroVector<T, TStruct>(dimension));        
        }

        /// <summary>
        /// Creates the one polynomial for dimension.
        /// </summary>
        /// <returns>The polynomial.</returns>
        /// <param name="dimension">The dimension.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        public Polynomial<T, TStruct> OnePolynomial<T, TStruct>(UInt32 dimension)
            where TStruct : IRing<T>, new()
        {
            var result = ZeroPolynomial<T, TStruct>(dimension);
            var baseStructure = new TStruct();

            result[0] = baseStructure.One;

            return result;
        }

        #endregion
    }
}