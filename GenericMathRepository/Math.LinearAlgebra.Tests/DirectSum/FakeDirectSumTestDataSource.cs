//  *************************************************************
// <copyright file="FakeTestDataSource.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  13 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;

    /// <summary>
    /// Contains data source for the direct sum tests.
    /// </summary>
    public class FakeDirectSumTestDataSource
    {
        #region fields

        List<Int32> _int32List;
        List<Double> _doubleList;
        List<Complex> _complexList;

        #endregion

        #region properties

        /// <summary>
        /// Gets the double list.
        /// </summary>
        /// <value>The double list.</value>
        public List<Double> DoubleList
        {
            get
            {
                return _doubleList ?? (_doubleList = new List<Double>{ 3.678 });
            }
        }

        /// <summary>
        /// Gets the complex list.
        /// </summary>
        /// <value>The complex list.</value>
        public List<Complex> ComplexList
        {
            get
            {
                return _complexList ?? (_complexList = new List<Complex>{ new Complex(1, 2), new Complex(4, 56) });
            }
        }

        /// <summary>
        /// Gets the int32 list.
        /// </summary>
        /// <value>The int32 list.</value>
        public List<Int32> Int32List
        {
            get
            {
                return _int32List ?? (_int32List = new List<int>{ 2, -2 });
            }

        }

        /// <summary>
        /// Gets the group int32 I direct sum source.
        /// </summary>
        /// <value>The group int32 I direct sum source.</value>
        public IDirectSum<Int32, Int32Group> GroupInt32IDirectSumSource
        {
            get
            {               
                return new DirectSum<Int32, Int32Group>(Int32List);
            }
        }

        /// <summary>
        /// Gets the ring int32 I direct sum source.
        /// </summary>
        /// <value>The ring int32 I direct sum source.</value>
        public IDirectSum<Int32, Int32Ring> RingInt32IDirectSumSource
        {
            get
            {               
                return new DirectSum<Int32, Int32Ring>(Int32List);
            }
        }

        /// <summary>
        /// Gets the ring complex I direct sum source.
        /// </summary>
        /// <value>The ring complex I direct sum source.</value>
        public IDirectSum<Complex, ComplexRing> RingComplexIDirectSumSource
        {
            get
            {
                return new DirectSum<Complex, ComplexRing>(ComplexList);
            }
        }

        /// <summary>
        /// Gets the field double I direct sum source.
        /// </summary>
        /// <value>The field double I direct sum source.</value>
        public IDirectSum<Double, DoubleField> FieldDoubleIDirectSumSource
        {
            get
            {
                return new DirectSum<Double, DoubleField>(DoubleList);
            }
        }

        #endregion
    }
}