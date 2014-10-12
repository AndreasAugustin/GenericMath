//  *************************************************************
// <copyright file="Int32GroupTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  17 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Test for the integer group.
    /// </summary>
    [TestFixture]
    public class Int32GroupTest : TemplateGroupTest<Int32>
    {
        #region fields

        private Int32Group _group;

        #endregion

        #region properties

        /// <summary>
        /// Gets the group.
        /// </summary>
        /// <value>The group.</value>
        protected override IGroup<Int32> Group
        {
            get
            {
                return this._group ?? (this._group = new Int32Group());
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
        [Test]
        [TestCase(2, -2)]
        [TestCase(4, -4)]
        public override void TestInverse(Int32 input, Int32 expected)
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
        [Test]
        [TestCase(2, -3, -1)]
        [TestCase(4, -4, 0)]
        public override void TestAddition(
            Int32 leftInput,
            Int32 rightInput,
            Int32 expectedSum)
        {
            this.TemplateTestAddition(leftInput, rightInput, expectedSum);
        }

        #endregion
    }
}