//  *************************************************************
// <copyright file="FakeMatrixTestDataSource.cs" company="None">
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
    /// Data source for the matrix test classes.
    /// </summary>
    public class FakeMatrixTestDataSource
    {
        #region fields

        private List<List<Int32>> _int32List;
        private List<List<Double>> _doubleList;
        private List<List<Complex>> _complexList;

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
                return this._doubleList ?? (
                    this._doubleList = new List<List<Double>> { new List<Double> { 3.678, 4.78 }, new List<Double> { 2.3, 2.6 } });
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
                return this._complexList ?? (this._complexList = 
                    new List<List<Complex>>
                { 
                    new List<Complex> { new Complex(1, 2), new Complex(4, 56) },
                    new List<Complex> { new Complex(3, -5), new Complex(-3, -1) },
                    new List<Complex> { new Complex(-3, -5), new Complex(3, 1) }
                });
            }
        }

        /// <summary>
        /// Gets the integer list.
        /// </summary>
        /// <value>The integer list.</value>
        public List<List<Int32>> Int32List
        {
            get
            {
                return this._int32List ?? (
                    this._int32List = new List<List<Int32>>
                { 
                    new List<Int32> { 2, -2, 5 }, new List<Int32> { -2, 2, 15 }, new List<Int32> { 2, 20, 5 }
                });
            }
        }

        /// <summary>
        /// Gets the group integer source.
        /// </summary>
        /// <value>The group integer source.</value>
        public IMatrix<Int32, Int32Group> GroupInt32Source
        {
            get
            {
                var rowDimension = (UInt32)this.Int32List.Count; 
                var columnDimension = (UInt32)this.Int32List[0].Count;

                var matrix = new Matrix<Int32, Int32Group>(
                                 rowDimension,
                                 columnDimension);

                for (UInt32 i = 0; i < rowDimension; i++)
                {
                    for (UInt32 j = 0; j < columnDimension; j++)
                    {
                        matrix[i, j] = this.Int32List[(Int32)i][(Int32)j];
                    }
                }

                return matrix;
            }
        }

        /// <summary>
        /// Gets the ring integer source.
        /// </summary>
        /// <value>The ring integer source.</value>
        public IMatrix<Int32, Int32Ring> RingInt32Source
        {
            get
            {               
                var rowDimension = (UInt32)this.Int32List.Count; 
                var columnDimension = (UInt32)this.Int32List[0].Count;

                var matrix = new Matrix<Int32, Int32Ring>(
                                 rowDimension,
                                 columnDimension);

                for (UInt32 i = 0; i < rowDimension; i++)
                {
                    for (UInt32 j = 0; j < columnDimension; j++)
                    {
                        matrix[i, j] = this.Int32List[(Int32)i][(Int32)j];
                    }
                }

                return matrix;
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
                var rowDimension = (UInt32)this.ComplexList.Count; 
                var columnDimension = (UInt32)this.ComplexList[0].Count;

                var matrix = new Matrix<Complex, ComplexRing>(
                                 rowDimension,
                                 columnDimension);

                for (UInt32 i = 0; i < rowDimension; i++)
                {
                    for (UInt32 j = 0; j < columnDimension; j++)
                    {
                        matrix[i, j] = this.ComplexList[(Int32)i][(Int32)j];
                    }
                }

                return matrix;
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
                var rowDimension = (UInt32)this.DoubleList.Count; 
                var columnDimension = (UInt32)this.DoubleList[0].Count;

                var matrix = new Matrix<Double, DoubleField>(
                                 rowDimension,
                                 columnDimension);

                for (UInt32 i = 0; i < rowDimension; i++)
                {
                    for (UInt32 j = 0; j < columnDimension; j++)
                    {
                        matrix[i, j] = this.DoubleList[(Int32)i][(Int32)j];
                    }
                }

                return matrix;
            }
        }

        #endregion
    }
}