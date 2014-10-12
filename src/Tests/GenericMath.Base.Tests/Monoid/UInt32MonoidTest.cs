//  *************************************************************
// <copyright file="UInt32MonoidTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Test for the <see cref="UInt32Monoid"/> class.
    /// </summary>
    [TestFixture]
    public class UInt32MonoidTest : TemplateMonoidTest<UInt32>
    {
        #region fields

        private UInt32Monoid _mondoid;

        #endregion

        #region properties

        /// <summary>
        /// Gets the monoid.
        /// </summary>
        /// <value>The monoid.</value>
        protected override IMonoid<UInt32> Monoid
        {
            get
            {
                return this._mondoid ?? (this._mondoid = new UInt32Monoid());
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the inverse method.
        /// </summary>
        /// <param name="leftInput">The left input.</param>
        /// <param name="rightInput">The right input.</param>
        /// <param name="expectedSum">The expected sum from left and right input.</param>
        [Category("MonoidTest")]
        [Test]
        [TestCase((UInt32)2, (UInt32)3, (UInt32)5)]
        [TestCase((UInt32)4, (UInt32)4, (UInt32)8)]
        public override void TestAddition(
            UInt32 leftInput,
            UInt32 rightInput,
            UInt32 expectedSum)
        {
            this.TemplateTestAddition(leftInput, rightInput, expectedSum);
        }

        #endregion
    }
}