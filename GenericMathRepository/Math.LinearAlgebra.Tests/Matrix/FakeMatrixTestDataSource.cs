//  *************************************************************
// <copyright file="FakeMatrixTestDataSource.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  18 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;

    /// <summary>
    /// Data source for the matrix test classes.
    /// </summary>
    public class FakeMatrixTestDataSource
    {
        #region fields

        List<List<Int32>> _int32List;
        List<List<Double>> _doubleList;
        List<List<Complex>> _complexList;

        #endregion

        #region properties

        /// <summary>
        /// Gets the double list.
        /// </summary>
        /// <value>The double list.</value>
        public List<List<Double>> DoubleList
        {
            get
            {
                return _doubleList ?? (_doubleList = new List<List<Double>>{ new List<Double>{ 3.678 } });
            }
        }

        /// <summary>
        /// Gets the complex list.
        /// </summary>
        /// <value>The complex list.</value>
        public List<List<Complex>> ComplexList
        {
            get
            {
                return _complexList ?? (_complexList = 
                    new List<List<Complex>>{ new List<Complex>{ new Complex(1, 2), new Complex(4, 56) } });
            }
        }

        /// <summary>
        /// Gets the int32 list.
        /// </summary>
        /// <value>The int32 list.</value>
        public List<List<Int32>> Int32List
        {
            get
            {
                return _int32List ?? (_int32List = new List<List<Int32>>{ new List<Int32>{ 2, -2 } });
            }

        }

        /// <summary>
        /// Gets the group int32 source.
        /// </summary>
        /// <value>The group int32 source.</value>
        public IMatrix<Int32, Int32Group> GroupInt32Source
        {
            get
            {               
                return new Matrix<Int32, Int32Group>(Int32List);
            }
        }

        /// <summary>
        /// Gets the ring int32 source.
        /// </summary>
        /// <value>The ring int32 source.</value>
        public IMatrix<Int32, Int32Ring> RingInt32Source
        {
            get
            {               
                return new Matrix<Int32, Int32Ring>(Int32List);
            }
        }

        /// <summary>
        /// Gets the ring complex source.
        /// </summary>
        /// <value>The ring complex source.</value>
        public IMatrix<Complex, ComplexRing> RingComplexSource
        {
            get
            {
                return new Matrix<Complex, ComplexRing>(ComplexList);
            }
        }

        /// <summary>
        /// Gets the field double source.
        /// </summary>
        /// <value>The field double source.</value>
        public IMatrix<Double, DoubleField> FieldDoubleSource
        {
            get
            {
                return new Matrix<Double, DoubleField>(DoubleList);
            }
        }

        #endregion
    }
}