//  *************************************************************
// <copyright file="IMatrixFromEuclidianRingExtensionsTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;
using GenericMath.LinearAlgebra.Contracts;

namespace GenericMath.LinearAlgebra.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Numerics;

	using GenericMath.Base;

	using NUnit.Framework;

	/// <summary>
	/// Test for the <see cref="IMatrixFromEuclidianRingExtensions"/> class.
	/// </summary>
	[TestFixture]
	public class MatrixFromEuclidianRingExtensionsTest
	{
		#region fields

		private FakeMatrixEuclidianRingTestDataSource _mockDataSource;

		#endregion

		#region properties

		private FakeMatrixEuclidianRingTestDataSource MockDataSource
		{
			get
			{
				return this._mockDataSource ?? (this._mockDataSource = new FakeMatrixEuclidianRingTestDataSource ());
			}
		}

		#endregion

		#region properties

		private IEnumerable<TestCaseData> GaussJordanSource
		{
			get
			{
				yield return new TestCaseData (
					new Double (),
					new DoubleEuclidianRing (),
					this.MockDataSource.DoubleSource);
				yield return new TestCaseData (
					new Complex (),
					new ComplexEuclidianRing (),
					this.MockDataSource.ComplexSource);
				yield return new TestCaseData (
					new Int32 (),
					new Int32EuclidianRing (),
					this.MockDataSource.Int32Source);
			}
		}

		#endregion

		#region methods

		/// <summary>
		/// Tests the GaussJordanAlgorithm method.
		/// </summary>
		/// <param name="hack1">Hack to get first generic parameter.</param>
		/// <param name="hack2">Hack to get second generic parameter.</param>
		/// <param name="matrix">The matrix.</param>
		/// <typeparam name="T">The underlying set.</typeparam>
		/// <typeparam name="TEuclidianRing">The underlying structure for the set.</typeparam>
		[Test]
		[Category("MatrixFromEuclidianRingExtensionTest")]
		[TestCaseSource("GaussJordanSource")]
		public void GaussJordanAlgorithm_Run_IsNotNull<T, TEuclidianRing> (
			T hack1,
			TEuclidianRing hack2,
			IMatrix<T, TEuclidianRing> matrix)
            where TEuclidianRing : IEuclidianRing<T>, new()
		{
			var result = matrix.GaussJordanAlgorithm();

			Assert.IsNotNull(result);
			//// Check if the under triangle has zero values
		}

		#endregion
	}
}