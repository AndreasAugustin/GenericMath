//  *************************************************************
// <copyright file="DoubleEuclidianRingTest.cs" company="None">
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

	using NUnit.Framework;

	/// <summary>
	/// Test for the <see cref="DoubleEuclidianRing"/> class.
	/// </summary>
	[TestFixture]
	public class DoubleEuclidianRingTest : TemplateEuclidianRingTest<Double>
	{
		#region fields

		private IEuclidianRing<Double> _euclidianRing;

		#endregion

		#region properties

		#region implemented abstract members of TemplateEuclidianRingTest

		/// <summary>
		/// Gets the ring.
		/// </summary>
		/// <value>The ring.</value>
		protected override IEuclidianRing<Double> EuclidianRing {
			get {
				return this._euclidianRing ?? (this._euclidianRing = new DoubleEuclidianRing ());
			}
		}

		#endregion

		#endregion

		#region implemented abstract members of TemplateEuclidianRingTest

		/// <summary>
		/// Tests the euclidian norm.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="expected">Expected solution.</param>
		[Test]
		[Category ("EuclidianRingTest")]
		[TestCase (-2.0, 2.0)]
		public override void TestEuclidianNorm (Double input, Double expected)
		{
			this.TemplateTestEuclidianNorm (input, expected);
		}

		#endregion
	}
}