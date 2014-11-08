//  *************************************************************
// <copyright file="FakePolynomialTestDataSource.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using GenericMath.Base;

    /// <summary>
    /// Fake polynomial test data source.
    /// </summary>
    public class FakePolynomialTestDataSource
    {
        #region fields

        private List<int> _int32List;
        private List<double> _doubleList;
        private List<Complex> _complexList;

        #endregion

        #region properties

        /// <summary>
        /// Gets the double list.
        /// </summary>
        /// <value>The double list.</value>
        public List<double> DoubleList
        {
            get
            {
                return this._doubleList ?? (this._doubleList = new List<Double> { 3.678 });
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
                return this._complexList ?? (this._complexList = new List<Complex>
                { 
                    new Complex(1, 2), 
                    new Complex(4, 56)
                });
            }
        }

        /// <summary>
        /// Gets the integer list.
        /// </summary>
        /// <value>The integer list.</value>
        public List<int> Int32List
        {
            get
            {
                return this._int32List ?? (this._int32List = new List<Int32> { 2, -2 });
            }
        }

        /// <summary>
        /// Gets the group integer I polynomial source.
        /// </summary>
        /// <value>The group integer polynomial source.</value>
        public IPolynomial<Int32, Int32Group> GroupInt32IPolynomialSource
        {
            get
            {               
                var degree = (UInt32)this.Int32List.Count - 1;
                var poly = new Polynomial<int, Int32Group>(degree);

                for (uint i = 0; i < degree + 1; i++)
                {
                    poly[i] = this.Int32List[(Int32)i];
                }

                return poly;
            }
        }

        /// <summary>
        /// Gets the ring integer polynomial source.
        /// </summary>
        /// <value>The ring integer polynomial source.</value>
        public IPolynomial<int, Int32Ring> RingInt32IPolynomialSource
        {
            get
            {               
                var degree = (uint)this.Int32List.Count - 1;
                var poly = new Polynomial<int, Int32Ring>(degree);

                for (uint i = 0; i < degree + 1; i++)
                {
                    poly[i] = this.Int32List[(int)i];
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
                var degree = (uint)this.ComplexList.Count - 1;
                var poly = new Polynomial<Complex, ComplexRing>(degree);

                for (uint i = 0; i < degree + 1; i++)
                {
                    poly[i] = this.ComplexList[(int)i];
                }

                return poly;
            }
        }

        /// <summary>
        /// Gets the field double polynomial source.
        /// </summary>
        /// <value>The field double polynomial source.</value>
        public IPolynomial<double, DoubleField> FieldDoubleIPolynomialSource
        {
            get
            {
                var degree = (uint)this.DoubleList.Count - 1;
                var poly = new Polynomial<double, DoubleField>(degree);

                for (uint i = 0; i < degree + 1; i++)
                {
                    poly[i] = this.DoubleList[(int)i];
                }

                return poly;
            }
        }

        #endregion
    }
}