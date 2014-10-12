//  *************************************************************
// <copyright file="DoubleGroupTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  15 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Double group test.
    /// </summary>
    [TestFixture]
    public class DoubleGroupTest : TemplateGroupTest<Double>
    {
        #region fields

        private DoubleGroup _group;

        #endregion

        #region properties

        /// <summary>
        /// Gets the group.
        /// </summary>
        /// <value>The group.</value>
        protected override IGroup<Double> Group
        {
            get
            {
                return this._group ?? (this._group = new DoubleGroup());
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
        [TestCase(2.0, -2.0)]
        [TestCase(4.5, -4.5)]
        public override void TestInverse(Double input, Double expected)
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
        [TestCase(2.0, -2.5, -0.5)]
        [TestCase(4.5, -4.5, 0)]
        public override void TestAddition(
            Double leftInput,
            Double rightInput,
            Double expectedSum)
        {
            this.TemplateTestAddition(leftInput, rightInput, expectedSum);
        }

        #endregion
    }
}