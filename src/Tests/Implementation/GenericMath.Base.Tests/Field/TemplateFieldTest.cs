//  *************************************************************
// <copyright file="TemplateFieldTest.cs" company="None">
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
	public abstract class TemplateFieldTest<T>
	{
		#region properties

		/// <summary>
		/// Gets the field.
		/// </summary>
		/// <value>The field.</value>
		protected abstract IField<T> Field { get; }

		#endregion

		#region methods

		/// <summary>
		/// Tests the multiplication inverse.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="expected">Expected solution.</param>
		[Test]
		[Category("FieldTest")]
		public abstract void TestMultiplicationInverse (T input, T expected);

		/// <summary>
		/// Templates for the test multiplication inverse.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="expected">The expected value.</param>
		protected void TemplateTestMultiplicationInverse (T input, T expected)
		{
			var result = this.Field.MultiplicationInverse(input);
			Assert.That(expected, Is.EqualTo(result));
		}

		#endregion
	}
}