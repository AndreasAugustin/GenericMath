//  *************************************************************
// <copyright file="RingExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  19 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using NUnit.Framework;

    /// <summary>
    /// Test class for ring extensions.
    /// </summary>
    [TestFixture]
    public class RingExtensionsTest
    {
        #region properties

        IEnumerable<TestCaseData> PowTestCaseSource
        {
            get
            {
                yield return new TestCaseData(2, 2, 4, new Int32Ring());
                yield return new TestCaseData(0.5, 3, 0.125, new DoubleRing());
                yield return new TestCaseData(new Complex(0, 1), 3, new Complex(0, -1), new ComplexRing());
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the power method.
        /// </summary>
        /// <typeparam name="T">The type parameter.</typeparam>
        /// <param name="factor">The test factor.</param>
        /// <param name="power">The power.</param>
        /// <param name="expected">The expected result.</param>
        /// <param name="ring">The ring.</param>
        [Test]
        [TestCaseSource("PowTestCaseSource")]
        public void Pow_CheckResult_AreEqual<T>(T factor, UInt32 power, T expected, IRing<T> ring)
        {
            Assert.AreEqual(expected, ring.Pow(factor, power));
        }

        #endregion
    }
}