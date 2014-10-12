//  *************************************************************
// <copyright file="ComplexRingTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  18 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base.Tests
{
    using System.Collections.Generic;
    using System.Numerics;

    using NUnit.Framework;

    /// <summary>
    /// Complex ring test.
    /// </summary>
    [TestFixture]
    public class ComplexRingTest : TemplateRingTest<Complex>
    {
        #region fields

        private IRing<Complex> _ring;

        #endregion

        #region properties

        #region implemented abstract members of TemplateRingTest

        /// <summary>
        /// Gets the ring.
        /// </summary>
        /// <value>The ring.</value>
        protected override IRing<Complex> Ring
        {
            get
            {
                return this._ring ?? (this._ring = new ComplexRing());
            }
        }

        #endregion

        private static IEnumerable<TestCaseData> MultiplicationTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    new Complex(2, 0),
                    new Complex(
                        -2,
                        -3),
                    new Complex(
                        -4,
                        -6));
                yield return new TestCaseData(
                    new Complex(4, -2),
                    Complex.One,
                    new Complex(
                        4,
                        -2));
            }
        }

        #endregion

        #region implemented abstract members of TemplateRingTest

        /// <summary>
        /// Tests the multiplication.
        /// </summary>
        /// <param name="leftInput">Left input.</param>
        /// <param name="rightInput">Right input.</param>
        /// <param name="expected">Expected solution.</param>
        [Category("RingTest")]
        [TestCaseSource("MultiplicationTestDataSource")]
        public override void TestMultiplication(
            Complex leftInput,
            Complex rightInput,
            Complex expected)
        {
            this.TemplateTestMultiplication(leftInput, rightInput, expected);
        }

        #endregion
    }
}