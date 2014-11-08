//  *************************************************************
// <copyright file="ComplexEuclidianRingTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using NUnit.Framework;

    /// <summary>
    /// Test for the <see cref="ComplexEuclidianRing"/> class.
    /// </summary>
    [TestFixture]
    public class ComplexEuclidianRingTest : TemplateEuclidianRingTest<Complex>
    {
        #region fields

        private IEuclidianRing<Complex> _euclidianRing;

        #endregion

        #region properties

        #region implemented abstract members of TemplateEuclidianRingTest

        /// <summary>
        /// Gets the ring.
        /// </summary>
        /// <value>The ring.</value>
        protected override IEuclidianRing<Complex> EuclidianRing
        {
            get
            {
                return this._euclidianRing ?? (this._euclidianRing = new ComplexEuclidianRing());
            }
        }

        private static IEnumerable<TestCaseData> EuclidianNormTestDataSource
        {
            get
            {
                yield return new TestCaseData(new Complex(2, 0), 2.0);
                yield return new TestCaseData(new Complex(0, -2), 2.0);
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
        [Category("EuclidianRingTest")]
        [TestCaseSource("EuclidianNormTestDataSource")]
        public override void TestEuclidianNorm(Complex input, Double expected)
        {
            this.TemplateTestEuclidianNorm(input, expected);
        }

        #endregion
    }
}