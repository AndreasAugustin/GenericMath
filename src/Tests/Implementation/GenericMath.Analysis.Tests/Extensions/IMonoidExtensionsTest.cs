//  *************************************************************
// <copyright file="IMonoidExtensionsTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;
using GenericMath.Analysis.Contracts;

namespace GenericMath.Analysis.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Numerics;

	using GenericMath.Base;
	using NSubstitute;
	using NUnit.Framework;

	/// <summary>
	/// Tests for the IGroupExtensions
	/// </summary>
	[TestFixture]
	public class IMonoidExtensionsTest
	{
		#region properties

		private static IEnumerable<TestCaseData> AdditionOfTwoAdditonFunctionsSource
		{
			get
			{
				yield return new TestCaseData (2, 3, 10, new Int32Group ());
				yield return new TestCaseData (
					2.0,
					3.5,
					11.0,
					new DoubleGroup ());
				yield return new TestCaseData (
					new Complex (2, 4),
					new Complex (
						4,
						2),
					new Complex (
						12,
						12),
					new ComplexGroup ());
			}
		}

		private static IEnumerable<TestCaseData> AdditionLeftMultiplicationFunctionRightAdditionFunctionFunctionSource
		{
			get
			{
				yield return new TestCaseData (2, 3, 11, new Int32Ring ());
				yield return new TestCaseData (1.0, 3.5, 8.0, new DoubleRing ());
				yield return new TestCaseData (
					new Complex (1, 0),
					new Complex (
						0,
						1),
					new Complex (
						1,
						2),
					new ComplexRing ());
			}
		}

		private static IEnumerable<TestCaseData> GroupsWithElements
		{
			get
			{
				yield return new TestCaseData (5, new Int32Group ());
				yield return new TestCaseData (4.5, new DoubleGroup ());
				yield return new TestCaseData (
					new Complex (123, 34),
					new ComplexGroup ());
			}
		}

		#endregion

		#region methods

		/// <summary>
		/// Test the addition of two functions.
		/// </summary>
		/// <param name="value1">the second value.</param>
		/// <param name="value2">The first value.</param>
		/// <param name="expectedResult">The expected result.</param>
		/// <param name="monoid">The group.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		[Test]
		[TestCaseSource("AdditionOfTwoAdditonFunctionsSource")]
		public void Addition_OfTwoAdditionFunctions_PointsAreEqual<T> (
			T value1,
			T value2,
			T expectedResult,
			IMonoid<T> monoid)
		{
			Func<T, T, T> func1 = monoid.Addition;
			Func<T, T, T> func2 = monoid.Addition;

			var calc = monoid.Addition(func1, func2);

			Assert.NotNull(calc);
			Assert.AreEqual(expectedResult, calc(value1, value2));
		}

		/// <summary>
		/// Additions the left argument multiplication function.
		/// </summary>
		/// <param name="value1">The first value.</param>
		/// <param name="value2">The second value2.</param>
		/// <param name="expectedResult">Expected result.</param>
		/// <param name="ring">The ring.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		[Test]
		[TestCaseSource("AdditionLeftMultiplicationFunctionRightAdditionFunctionFunctionSource")]
		public void Addition_LeftMultiplicationFunctionRightAdditionFunction_PointsAreEqual<T> (
			T value1,
			T value2, 
			T expectedResult,
			IRing<T> ring)
		{
			Func<T, T, T> func1 = ring.Addition; 
			Func<T, T, T> func2 = ring.Multiplication;

			var calc = ring.Addition(func1, func2);

			Assert.NotNull(calc);
			Assert.AreEqual(expectedResult, calc(value1, value2));
		}

		/// <summary>
		/// Zeros the function equals mock.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="monoid">The group.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		[Test]
		[TestCaseSource("GroupsWithElements")]
		public void ZeroFunction_PointsEqualsMock<T> (
			T value,
			IMonoid<T> monoid)
		{
			Func<T, T> functionMock = Substitute.For<Func<T, T>>();
			functionMock(value).Returns(value);

			var testFunction = monoid.Addition(
				                   monoid.ZeroFunction(),
				                   functionMock);

			Assert.AreEqual(functionMock(value), testFunction(value));
		}

		#endregion
	}
}