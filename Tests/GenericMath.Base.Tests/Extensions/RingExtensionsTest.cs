//  *************************************************************
// <copyright file="RingExtensionsTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

using GenericMath.Base.Contracts;

namespace GenericMath.Base.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Numerics;

	using NUnit.Framework;

	/// <summary>
	/// Test class for ring extensions.
	/// </summary>
	[TestFixture]
	public class RingExtensionsTest
	{
		#region properties

		private IEnumerable<TestCaseData> PowTestCaseSource
		{
			get
			{
				yield return new TestCaseData (2, 2, 4, new Int32Ring ());
				yield return new TestCaseData (0.5, 3, 0.125, new DoubleRing ());
				yield return new TestCaseData (
					new Complex (0, 1),
					3,
					new Complex (
						0,
						-1),
					new ComplexRing ());
			}
		}

		#endregion

		#region methods

		/// <summary>
		/// Tests the power method.
		/// </summary>
		/// <typeparam name="T">The type parameter.</typeparam>
		/// <param name="factor">The test factor.</param>
		/// <param name="power">The power.</param>
		/// <param name="expected">The expected result.</param>
		/// <param name="ring">The ring.</param>
		[Test]
		[TestCaseSource("PowTestCaseSource")]
		public void Pow_CheckResult_AreEqual<T> (
			T factor,
			UInt32 power,
			T expected,
			IRing<T> ring)
		{
			Assert.AreEqual(expected, ring.Pow(factor, power));
		}

		#endregion
	}
}