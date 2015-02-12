//  *************************************************************
// <copyright file="IPolynomialFromRingExtensionsTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;

namespace GenericMath.LinearAlgebra.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Numerics;

	using GenericMath.Base;
	using NUnit.Framework;

	/// <summary>
	/// Tests for the IPolynomial extensions with underlying ring as structure.
	/// </summary>
	[TestFixture]
	public class IPolynomialFromRingExtensionsTest
	{
		#region fields

		private FakePolynomialTestDataSource _mockDataSource;

		#endregion

		#region properties

		private FakePolynomialTestDataSource MockDataSource
		{
			get
			{
				return this._mockDataSource ?? (this._mockDataSource = new FakePolynomialTestDataSource ());
			}
		}

		private IEnumerable<TestCaseData> PolynomialMultiplyTestDataSource
		{
			get
			{
				yield return new TestCaseData (
					0,
					new Int32Ring (),
					this.MockDataSource.RingInt32IPolynomialSource,
					this.MockDataSource.RingInt32IPolynomialSource);
				yield return new TestCaseData (
					3.678,
					new DoubleField (),
					this.MockDataSource.FieldDoubleIPolynomialSource,
					this.MockDataSource.FieldDoubleIPolynomialSource);
				yield return new TestCaseData (
					new Complex (5, 58),
					new ComplexRing (),
					this.MockDataSource.RingComplexIPolynomialSource,
					this.MockDataSource.RingComplexIPolynomialSource);
			}
		}

		#endregion

		#region methods

		/// <summary>
		/// Tests the multiply method.
		/// </summary>
		/// <param name="hackForGenericParameter1">Hack for generic parameter1.</param>
		/// <param name="hackForGenericParameter2">Hack for generic parameter2.</param>
		/// <param name="tuple1">The first tuple.</param>
		/// <param name="tuple2">The second tuple.</param>
		/// <typeparam name="T">The underlying set.</typeparam>
		/// <typeparam name="TRing">The underlying ring.</typeparam>
		[Test]
		[Category("PolynomialFromRingTest")]
		[TestCaseSource("PolynomialMultiplyTestDataSource")]
		public void Multiply_MultiplyTwoPolynomials_DegreeEqualsxpecedDegree<T, TRing> (
			T hackForGenericParameter1, 
			TRing hackForGenericParameter2, 
			IPolynomial<T, TRing> tuple1, 
			IPolynomial<T, TRing> tuple2)
            where TRing : IRing<T>, new()
		{
			var result = tuple1.Multiply(tuple2);

			var expectedDegree = tuple1.Degree + tuple2.Degree;
			Assert.AreEqual(expectedDegree, result.Degree);
		}

		#endregion
	}
}