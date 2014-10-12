//  *************************************************************
// <copyright file="EuclidianRingExtensionsTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  15 / 7 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base.Tests
{
    // TODO rewrite the tests.
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Integer extension tests.
    /// </summary>
    [TestFixture]
    public class EuclidianRingExtensionsTest
    {
        #region METHODS

        /// <summary>
        /// Tests the euclidian algorithm.
        /// </summary>
        [Test]
        public void TestEuclidianAlgorithm()
        {
            const Int32 A = 4;
            const Int32 B = 3;

            var gcd = A.EuclidianAlgorithm(B);
            Assert.AreEqual(1, gcd);

            const Int32 C = 8;
            Assert.AreEqual(4, A.EuclidianAlgorithm(C));
        }

        /// <summary>
        /// Tests the extended euclidian algorithm.
        /// </summary>
        [Test]
        public void TestExtendedEuclidianAlgorithm()
        {
            const Int32 A = 100;
            const Int32 B = 35;

            Int32 x;
            Int32 y;

            var gcd = A.ExtendedEuclidianAlgorithm(B, out x, out y);

            Assert.AreEqual(-1, x);
            Assert.AreEqual(3, y);
        }

        /// <summary>
        /// Tests the chinese rest term helper.
        /// </summary>
        [Test]
        public void TestChineseRestTermHelper()
        {
            var x = new Int32[3]; 
            x[0] = 2;
            x[1] = 1;
            x[2] = 0;

            var moduli = new Int32[3];
            moduli[0] = 4;
            moduli[1] = 3;
            moduli[2] = 5;

            var res = moduli.ChineseRestTerm(x);

            Assert.AreEqual(-2, res % 4);
            Assert.AreEqual(-2, res % 3);
            Assert.AreEqual(0, res % 5);
        }

        #endregion
    }
}