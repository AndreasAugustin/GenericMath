//  *************************************************************
// <copyright file="IMatrixFromGroupExtensionsTest.cs" company="None">
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
	/// Tests for the <see cref="IMatrixFromGroupExtensions"/> class.
	/// </summary>
	[TestFixture]
	public class MatrixFromGroupExtensionsTest
	{
		#region fields

		private FakeMatrixTestDataSource _mockDataSource;

		#endregion

		#region properties

		private FakeMatrixTestDataSource MockDataSource
		{
			get
			{
				return this._mockDataSource ?? (this._mockDataSource = new FakeMatrixTestDataSource ());
			}
		}

		private IEnumerable<TestCaseData> InverseDataSource
		{
			get
			{
				yield return new TestCaseData (
					default(Int32),
					new Int32Group (),
					this.MockDataSource.GroupInt32Source);
				yield return new TestCaseData (
					default(Double),
					new DoubleField (),
					this.MockDataSource.FieldDoubleSource);
				yield return new TestCaseData (
					default(Complex),
					new ComplexRing (),
					this.MockDataSource.RingComplexSource);
			}
		}

		#endregion

		#region methods

		/// <summary>
		/// Tests the inverse method.
		/// </summary>
		/// <param name="hack1">The first Hack1.</param>
		/// <param name="hack2">The second Hack2.</param>
		/// <param name="matrix">The Matrix.</param>
		/// <typeparam name="T">The underlying set.</typeparam>
		/// <typeparam name="TGroup">The underlying group.</typeparam>
		[Category("MatrixFromGroupExtensionTest")]
		[Test]
		[TestCaseSource("InverseDataSource")]
		public void Inverse_CheckResultWithExpected_EqualsElementalInverse<T, TGroup> (
			T hack1,
			TGroup hack2, 
			IMatrix<T, TGroup> matrix)
            where TGroup : IGroup<T>, new()
		{
			var result = matrix.Inverse();

			Assert.IsNotNull(result);
			Assert.IsFalse(Object.ReferenceEquals(matrix, result));

			Assert.AreEqual(matrix.RowDimension, result.RowDimension);
			Assert.AreEqual(matrix.ColumnDimension, matrix.ColumnDimension);

			var group = new TGroup ();

			for (UInt32 i = 0; i < matrix.RowDimension; i++) {
				for (UInt32 j = 0; j < matrix.ColumnDimension; j++) {
					var expected = group.Inverse(matrix [i, j]);
					Assert.AreEqual(expected, result [i, j]);
				}
			}
		}

		#endregion
	}
}