//  *************************************************************
// <copyright file="FakeMatrixSquaredTestDataSource.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  20 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;

    /// <summary>
    /// TestData Source for squared matrizes.
    /// </summary>
    public class FakeMatrixSquaredTestDataSource
    {
        #region fields

        List<List<Int32>> _int32List;
        List<List<Double>> _doubleList;
        List<List<Double>> _doubleList2;
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
                return _doubleList ?? (
                    _doubleList = new List<List<Double>>{ new List<Double>{ 3.678, 4.78 }, new List<Double>{ 2.3, 2.6 } });
            }
        }

        /// <summary>
        /// Gets the int32 list.
        /// </summary>
        /// <value>The int32 list.</value>
        public List<List<Double>> DoubleList2
        {
            get
            {
                return _doubleList2 ?? (
                    _doubleList2 = new List<List<Double>>
                { 
                    new List<Double>{ 2.0, -2.0, 5.0 }, new List<Double>{ -2.0, 2.0, 15.0 }, new List<Double>{ 2.0, 20.0, 5.0 }
                });
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
                    new List<List<Complex>>
                { new List<Complex>{ new Complex(1, 2), new Complex(4, 56), new Complex(4, -3) },
                    new List<Complex>{ new Complex(3, -5), new Complex(-3, -1), new Complex(4, -3) },
                    new List<Complex>{ new Complex(-3, -5), new Complex(3, 1), new Complex(4, -3) }
                });
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
                return _int32List ?? (
                    _int32List = new List<List<Int32>>
                { 
                    new List<Int32>{ 2, -2, 5 }, new List<Int32>{ -2, 2, 15 }, new List<Int32>{ 2, 20, 5 }
                });
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
                var rowDimension = (UInt32)this.Int32List.Count; 
                var columnDimension = (UInt32)this.Int32List[0].Count;

                var matrix = new Matrix<Int32, Int32Group>(rowDimension, columnDimension);

                for (UInt32 i = 0; i < rowDimension; i++)
                {
                    for (UInt32 j = 0; j < columnDimension; j++)
                    {
                        matrix[i, j] = (this.Int32List[(Int32)i])[(Int32)j];
                    }
                }

                return matrix;
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
                var rowDimension = (UInt32)this.Int32List.Count; 
                var columnDimension = (UInt32)this.Int32List[0].Count;

                var matrix = new Matrix<Int32, Int32Ring>(rowDimension, columnDimension);

                for (UInt32 i = 0; i < rowDimension; i++)
                {
                    for (UInt32 j = 0; j < columnDimension; j++)
                    {
                        matrix[i, j] = (this.Int32List[(Int32)i])[(Int32)j];
                    }
                }

                return matrix;
            }
        }

        /// <summary>
        /// Gets the ring complex source.
        /// </summary>
        /// <value>The ring complex source.</value>
        public IMatrix<Complex, ComplexField> FieldComplexSource
        {
            get
            {
                var rowDimension = (UInt32)this.ComplexList.Count; 
                var columnDimension = (UInt32)this.ComplexList[0].Count;

                var matrix = new Matrix<Complex, ComplexField>(rowDimension, columnDimension);

                for (UInt32 i = 0; i < rowDimension; i++)
                {
                    for (UInt32 j = 0; j < columnDimension; j++)
                    {
                        matrix[i, j] = (this.ComplexList[(Int32)i])[(Int32)j];
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

                var matrix = new Matrix<Double, DoubleField>(rowDimension, columnDimension);

                for (UInt32 i = 0; i < rowDimension; i++)
                {
                    for (UInt32 j = 0; j < columnDimension; j++)
                    {
                        matrix[i, j] = (this.DoubleList[(Int32)i])[(Int32)j];
                    }
                }

                return matrix;
            }
        }

        /// <summary>
        /// Gets the field double2 source.
        /// </summary>
        /// <value>The field double2 source.</value>
        public IMatrix<Double, DoubleField> FieldDoubleSource2
        {
            get
            {
                var rowDimension = (UInt32)this.DoubleList2.Count; 
                var columnDimension = (UInt32)this.DoubleList2[0].Count;

                var matrix = new Matrix<Double, DoubleField>(rowDimension, columnDimension);

                for (UInt32 i = 0; i < rowDimension; i++)
                {
                    for (UInt32 j = 0; j < columnDimension; j++)
                    {
                        matrix[i, j] = (this.DoubleList2[(Int32)i])[(Int32)j];
                    }
                }

                return matrix;
            }
        }

        #endregion
    }
}