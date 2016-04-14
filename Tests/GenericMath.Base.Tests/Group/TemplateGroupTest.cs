//  *************************************************************
// <copyright file="TemplateGroupTest.cs" company="None">
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
	/// Template for the group tests.
	/// </summary>
	/// <typeparam name="T">The type parameter for the <see cref="IGroup{T}"/> class.</typeparam>
	[TestFixture]
	public abstract class TemplateGroupTest<T>
	{
		#region properties

		/// <summary>
		/// Gets the group.
		/// </summary>
		/// <value>The group.</value>
		protected abstract IGroup<T> Group { get; }

		#endregion

		#region methods

		/// <summary>
		/// Tests the addition.
		/// </summary>
		/// <param name="leftInput">The left input.</param>
		/// <param name="rightInput">The right input.</param>
		/// <param name="expectedSum">The expected sum from left and right input.</param>
		[Test]
		[Category ("GroupTest")]
		public abstract void TestAddition (
			T leftInput,
			T rightInput,
			T expectedSum);

		/// <summary>
		/// Tests the inverse.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="expected">The expected inverse.</param>
		[Test]
		[Category ("GroupTest")]
		public abstract void TestInverse (T input, T expected);

		/// <summary>
		/// Tests the inverse method.
		/// Can be used as template for test method TestAddition with more input parameters from attribute.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="expected">The expected inverse.</param>
		protected void TemplateTestInverse (T input, T expected)
		{
			var result = this.Group.Inverse (input);
			Assert.AreEqual (expected, result);
		}

		/// <summary>
		/// Tests the addition method.
		/// Can be used as template for test method TestAddition with more input parameters from attribute.
		/// </summary>
		/// <param name="leftInput">The left input.</param>
		/// <param name="rightInput">The right input.</param>
		/// <param name="expectedSum">The expected sum from left and right input.</param>
		protected void TemplateTestAddition (
			T leftInput,
			T rightInput,
			T expectedSum)
		{
			var result = this.Group.Addition (leftInput, rightInput);
			Assert.AreEqual (expectedSum, result);
		}

		#endregion
	}
}