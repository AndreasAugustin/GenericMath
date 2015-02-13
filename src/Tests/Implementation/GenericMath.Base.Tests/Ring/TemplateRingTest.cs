//  *************************************************************
// <copyright file="TemplateRingTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;

namespace GenericMath.Base.Tests
{
	using NUnit.Framework;

	/// <summary>
	/// Template ring test.
	/// </summary>
	/// <typeparam name="T">The type parameter</typeparam>
	[TestFixture]
	public abstract class TemplateRingTest<T>
	{
		#region properties

		/// <summary>
		/// Gets the ring.
		/// </summary>
		/// <value>The ring.</value>
		protected abstract IRing<T> Ring {
			get;
		}

		#endregion

		#region methods

		/// <summary>
		/// Tests the multiplication.
		/// </summary>
		/// <param name="leftInput">Left input.</param>
		/// <param name="rightInput">Right input.</param>
		/// <param name="expected">Expected solution.</param>
		[Test]
		[Category ("RingTest")]
		public abstract void TestMultiplication (
			T leftInput,
			T rightInput,
			T expected);

		/// <summary>
		/// Templates for the test multiplication.
		/// </summary>
		/// <param name="leftInput">Left input.</param>
		/// <param name="rightInput">Right input.</param>
		/// <param name="expected">The expected value.</param>
		protected void TemplateTestMultiplication (
			T leftInput,
			T rightInput,
			T expected)
		{
			var result = this.Ring.Multiplication (
				                      leftInput,
				                      rightInput);

			Assert.AreEqual (
				expected, result);
		}

		#endregion
	}
}