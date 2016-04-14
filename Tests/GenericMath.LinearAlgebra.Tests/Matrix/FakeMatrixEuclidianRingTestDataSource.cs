//  *************************************************************
// <copyright file="FakeMatrixEuclidianRingTestDataSource.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.LinearAlgebra.Contracts;

namespace GenericMath.LinearAlgebra.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Numerics;

	using GenericMath.Base;

	/// <summary>
	/// Test data source for the <see cref="IMatrixFromEuclidianRingExtensionsTest"/>
	/// </summary>
	public class FakeMatrixEuclidianRingTestDataSource
	{
		#region fields

		private List<List<Int32>> _int32List;
		private List<List<Double>> _doubleList;
		private List<List<Complex>> _complexList;

		#endregion

		#region properties

		/// <summary>
		/// Gets the integer source.
		/// </summary>
		/// <value>The integer source.</value>
		public IMatrix<Int32, Int32EuclidianRing> Int32Source
		{
			get
			{
				var rowDimension = (UInt32)this.Int32List.Count; 
				var columnDimension = (UInt32)this.Int32List [0].Count;

				var matrix = new Matrix<Int32, Int32EuclidianRing> (
					                         rowDimension,
					                         columnDimension);

				for (UInt32 i = 0; i < rowDimension; i++) {
					for (UInt32 j = 0; j < columnDimension; j++) {
						matrix [i, j] = this.Int32List [(Int32)i] [(Int32)j];
					}
				}

				return matrix;
			}
		}

		/// <summary>
		/// Gets the complex source.
		/// </summary>
		/// <value>The complex source.</value>
		public IMatrix<Complex, ComplexEuclidianRing> ComplexSource
		{
			get
			{
				var rowDimension = (UInt32)this.ComplexList.Count; 
				var columnDimension = (UInt32)this.ComplexList [0].Count;

				var matrix = new Matrix<Complex, ComplexEuclidianRing> (
					                         rowDimension,
					                         columnDimension);

				for (UInt32 i = 0; i < rowDimension; i++) {
					for (UInt32 j = 0; j < columnDimension; j++) {
						matrix [i, j] = this.ComplexList [(Int32)i] [(Int32)j];
					}
				}

				return matrix;
			}
		}

		/// <summary>
		/// Gets the double source.
		/// </summary>
		/// <value>The double source.</value>
		public IMatrix<Double, DoubleEuclidianRing> DoubleSource
		{
			get
			{
				var rowDimension = (UInt32)this.DoubleList.Count; 
				var columnDimension = (UInt32)this.DoubleList [0].Count;

				var matrix = new Matrix<Double, DoubleEuclidianRing> (
					                         rowDimension,
					                         columnDimension);

				for (UInt32 i = 0; i < rowDimension; i++) {
					for (UInt32 j = 0; j < columnDimension; j++) {
						matrix [i, j] = this.DoubleList [(Int32)i] [(Int32)j];
					}
				}

				return matrix;
			}
		}

		/// <summary>
		/// Gets the integer list.
		/// </summary>
		/// <value>The integer list.</value>
		private List<List<Int32>> Int32List
		{
			get
			{
				return this._int32List ?? (
				    this._int32List = new List<List<Int32>> { 
					new List<Int32> { 2, -2 }, new List<Int32> { -1, 2 }
				});
			}
		}

		/// <summary>
		/// Gets the double list.
		/// </summary>
		/// <value>The double list.</value>
		private List<List<Double>> DoubleList
		{
			get
			{
				return this._doubleList ?? (
				    this._doubleList = new List<List<Double>> {
					new List<Double> { 3.678, 4.78 },
					new List<Double> {
						2.3,
						2.6
					}
				});
			}
		}

		/// <summary>
		/// Gets the complex list.
		/// </summary>
		/// <value>The complex list.</value>
		private List<List<Complex>> ComplexList
		{
			get
			{
				return this._complexList ?? (this._complexList = 
                    new List<List<Complex>> { 
					new List<Complex> { 
						new Complex (1, 2), new Complex (4, 56), new Complex (
							4,
							-3)
					},
					new List<Complex> { 
						new Complex (3, -5), new Complex (-3, -1), new Complex (
							4,
							-3)
					},
					new List<Complex> { 
						new Complex (-3, -5), new Complex (3, 1), new Complex (
							4,
							-3)
					}
				});
			}
		}

		#endregion
	}
}