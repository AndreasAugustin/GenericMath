//  *************************************************************
// <copyright file="Int32EuclidianRingTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  18 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Test for the <see cref="Int32EuclidianRing"/> class. 
    /// </summary>
    [TestFixture]
    public class Int32EuclidianRingTest : TemplateEuclidianRingTest<Int32>
    {
        #region fields

        private IEuclidianRing<Int32> _euclidianRing;

        #endregion

        #region properties

        #region implemented abstract members of TemplateEuclidianRingTest

        /// <summary>
        /// Gets the ring.
        /// </summary>
        /// <value>The ring.</value>
        protected override IEuclidianRing<Int32> EuclidianRing
        {
            get
            {
                return this._euclidianRing ?? (this._euclidianRing = new Int32EuclidianRing());
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
        [TestCase(-2, 2)]
        public override void TestEuclidianNorm(Int32 input, Double expected)
        {
            this.TemplateTestEuclidianNorm(input, expected);
        }

        #endregion
    }
}