//  *************************************************************
// <copyright file="ComplexGroupTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  17 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base.Tests
{
    using System.Collections.Generic;
    using System.Numerics;

    using NUnit.Framework;

    /// <summary>
    /// Complex group test.
    /// </summary>
    [TestFixture]
    public class ComplexGroupTest : TemplateGroupTest<Complex>
    {
        #region fields

        private ComplexGroup _group;

        #endregion

        #region properties

        /// <summary>
        /// Gets the group.
        /// </summary>
        /// <value>The group.</value>
        protected override IGroup<Complex> Group
        {
            get
            {
                return this._group ?? (this._group = new ComplexGroup());
            }
        }

        private static IEnumerable<TestCaseData> InverseTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    new Complex(2, 3),
                    new Complex(
                        -2,
                        -3));
                yield return new TestCaseData(
                    new Complex(4, -2),
                    new Complex(
                        -4,
                        2));
            }
        }

        private static IEnumerable<TestCaseData> AdditionTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    new Complex(2, 3),
                    new Complex(
                        -2,
                        -3),
                    Complex.Zero);
                yield return new TestCaseData(
                    new Complex(3, -3),
                    new Complex(
                        4,
                        -2),
                    new Complex(
                        7,
                        -5));
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the inverse method.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="expected">The expected inverse.</param>
        [Category("GroupTest")]
        [TestCaseSource("InverseTestDataSource")]
        [Test]
        public override void TestInverse(Complex input, Complex expected)
        {
            this.TemplateTestInverse(input, expected);
        }

        /// <summary>
        /// Tests the inverse method.
        /// </summary>
        /// <param name="leftInput">The left input.</param>
        /// <param name="rightInput">The right input.</param>
        /// <param name="expectedSum">The expected sum from left and right input.</param>
        [Category("GroupTest")]
        [TestCaseSource("AdditionTestDataSource")]
        [Test]
        public override void TestAddition(
            Complex leftInput,
            Complex rightInput,
            Complex expectedSum)
        {
            this.TemplateTestAddition(leftInput, rightInput, expectedSum);
        }

        #endregion
    }
}