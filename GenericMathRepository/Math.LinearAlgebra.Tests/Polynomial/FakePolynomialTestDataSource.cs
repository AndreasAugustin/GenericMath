//  *************************************************************
// <copyright file="FakePolynomialTestDataSource.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  16 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;

    /// <summary>
    /// Fake polynomial test data source.
    /// </summary>
    public class FakePolynomialTestDataSource
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
        /// Gets the group int32 I polynomial source.
        /// </summary>
        /// <value>The group int32 polynomial source.</value>
        public IPolynomial<Int32, Int32Group> GroupInt32IPolynomialSource
        {
            get
            {               
                var degree = (UInt32)Int32List.Count;
                var poly = new Polynomial<Int32, Int32Group>(degree - 1);

                for (UInt32 i = 0; i < degree; i++)
                {
                    poly[i] = Int32List[(Int32)i];
                }

                return poly;
            }
        }

        /// <summary>
        /// Gets the ring int32 polynomial source.
        /// </summary>
        /// <value>The ring int32 polynomial source.</value>
        public IPolynomial<Int32, Int32Ring> RingInt32IPolynomialSource
        {
            get
            {               
                var degree = (UInt32)Int32List.Count;
                var poly = new Polynomial<Int32, Int32Ring>(degree - 1);

                for (UInt32 i = 0; i < degree; i++)
                {
                    poly[i] = Int32List[(Int32)i];
                }

                return poly;
            }
        }

        /// <summary>
        /// Gets the ring complex polynomial source.
        /// </summary>
        /// <value>The ring complex polynomial source.</value>
        public IPolynomial<Complex, ComplexRing> RingComplexIPolynomialSource
        {
            get
            {
                var degree = (UInt32)ComplexList.Count;
                var poly = new Polynomial<Complex, ComplexRing>(degree - 1);

                for (UInt32 i = 0; i < degree; i++)
                {
                    poly[i] = ComplexList[(Int32)i];
                }

                return poly;
            }
        }

        /// <summary>
        /// Gets the field double polynomial source.
        /// </summary>
        /// <value>The field double polynomial source.</value>
        public IPolynomial<Double, DoubleField> FieldDoubleIPolynomialSource
        {
            get
            {
                var degree = (UInt32)DoubleList.Count;
                var poly = new Polynomial<Double, DoubleField>(degree - 1);

                for (UInt32 i = 0; i < degree; i++)
                {
                    poly[i] = DoubleList[(Int32)i];
                }

                return poly;
            }
        }

        #endregion
    }
}