//  *************************************************************
// <copyright file="DoubleRingTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  18 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Double ring test.
    /// </summary>
    [TestFixture]
    public class DoubleRingTest : TemplateRingTest<Double>
    {
        #region fields

        private IRing<Double> _ring;

        #endregion

        #region properties

        #region implemented abstract members of TemplateRingTest

        /// <summary>
        /// Gets the ring.
        /// </summary>
        /// <value>The ring.</value>
        protected override IRing<Double> Ring
        {
            get
            {
                return this._ring ?? (this._ring = new DoubleRing());
            }
        }

        #endregion

        #endregion

        #region implemented abstract members of TemplateRingTest

        /// <summary>
        /// Tests the multiplication.
        /// </summary>
        /// <param name="leftInput">Left input.</param>
        /// <param name="rightInput">Right input.</param>
        /// <param name="expected">Expected solution.</param>
        [Test]
        [Category("RingTest")]
        [TestCase(3.5, 5.5, 19.25)]
        [TestCase(4.0, -10.0, -40.0)]
        public override void TestMultiplication(
            Double leftInput,
            Double rightInput,
            Double expected)
        {
            this.TemplateTestMultiplication(leftInput, rightInput, expected);
        }

        #endregion
    }
}