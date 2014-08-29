//  *************************************************************
// <copyright file="PolynomialTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  25 / 7 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Polynomial test.
    /// </summary>
    [TestFixture]
    public class PolynomialTest
    {
        #region methods

        /// <summary>
        /// Tests the polynomial.
        /// </summary>
        [Test]
        public void TestPolynomial()
        {
            var poly1 = Degree1Int32Polynom();
            var poly2 = Degree2Int32Polynom();

            Assert.IsNotNull(poly1);
            Assert.IsNotNull(poly2);

            Assert.AreEqual(1, poly1.Degree);
            Assert.AreEqual(2, poly2.Degree);

            Assert.AreEqual(2, poly1[1]);
            Assert.AreEqual(3, poly2[2]);

            var sum = poly1.Add(poly2);

            Assert.IsNotNull(sum);
            Assert.AreEqual(2, sum.Degree);
            Assert.AreEqual(4, sum[1]);
            Assert.AreEqual(3, sum[2]);
        }

        /// <summary>
        /// Tests the calculation.
        /// </summary>
        [Test]
        public void TestCalculation()
        {
            var poly2 = Degree2Int32Polynom();
            var result = poly2.Calculate(2);

            Assert.AreEqual(17, result);
        }

        /// <summary>
        /// Tests the multiplication.
        /// </summary>
        [Test]
        public void TestMultiplication()
        {
            var poly1 = Degree1Int32Polynom();
            Assert.AreEqual(2, poly1[1]);
            var poly2 = Degree2Int32Polynom();

            var mult = poly1.Multiply(poly2);
            Assert.IsNotNull(mult);

            Assert.AreEqual(6, mult[3]);
            Assert.AreEqual(7, mult[2]);
            Assert.AreEqual(4, mult[1]);
            Assert.AreEqual(1, mult[0]);
        }

        #endregion

        #region helper methods

        Polynomial<Int32> Degree1Int32Polynom()
        {
            var poly1 = new Polynomial<Int32>(1);
            poly1[0] = 1;
            poly1[1] = 2;

            return poly1;
        }

        Polynomial<Int32> Degree2Int32Polynom()
        {
            var poly2 = new Polynomial<Int32>(2);
            poly2[0] = 1;
            poly2[1] = 2;
            poly2[2] = 3;

            return poly2;
        }

        #endregion
    }
}