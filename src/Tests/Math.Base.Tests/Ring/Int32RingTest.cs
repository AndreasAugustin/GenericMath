//  *************************************************************
// <copyright file="Int32RingTest.cs" company="SuperDevelop">
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
    /// Integer ring test.
    /// </summary>
    [TestFixture]
    public class Int32RingTest : TemplateRingTest<Int32>
    {
        #region fields

        private IRing<Int32> _ring;

        #endregion

        #region properties

        #region implemented abstract members of TemplateRingTest

        /// <summary>
        /// Gets the ring.
        /// </summary>
        /// <value>The ring.</value>
        protected override IRing<Int32> Ring
        {
            get
            {
                return this._ring ?? (this._ring = new Int32Ring());
            }
        }

        #endregion

        #endregion

        #region methods

        #region implemented abstract members of TemplateRingTest

        /// <summary>
        /// Tests the multiplication.
        /// </summary>
        /// <param name="leftInput">Left input.</param>
        /// <param name="rightInput">Right input.</param>
        /// <param name="expected">Expected solution.</param>
        [Test]
        [Category("RingTest")]
        [TestCase(3, 5, 15)]
        [TestCase(4, -10, -40)]
        public override void TestMultiplication(
            Int32 leftInput,
            Int32 rightInput,
            Int32 expected)
        {
            this.TemplateTestMultiplication(leftInput, rightInput, expected);
        }

        #endregion

        #endregion
    }
}