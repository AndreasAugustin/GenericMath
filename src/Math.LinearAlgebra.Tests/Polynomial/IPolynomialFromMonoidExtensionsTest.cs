//  *************************************************************
// <copyright file="IPolynomialFromMonoidExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  16 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
   
    using Math.Base;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the extension methods for polynomials with underlying Monoid structure.
    /// </summary>
    [TestFixture]
    public class IPolynomialFromMonoidExtensionsTest
    {
        #region fields

        FakePolynomialTestDataSource _mockDataSource;

        #endregion

        #region properties

        FakePolynomialTestDataSource MockDataSource
        {
            get
            {
                return _mockDataSource ?? (_mockDataSource = new FakePolynomialTestDataSource());
            }
        }

        IPolynomial<Int32, Int32Group> ExpectedInt32IPolynomialSource
        {
            get
            {               
                var degree = (UInt32)MockDataSource.Int32List.Count - 1;
                var poly = new Polynomial<Int32, Int32Group>(degree);

                for (UInt32 i = 0; i < degree + 1; i++)
                {
                    poly[i] = 2 * MockDataSource.Int32List[(Int32)i];
                }

                return poly;
            }
        }

        IPolynomial<Complex, ComplexRing> ExpectedComplexIPolynomialSource
        {
            get
            {
                var degree = (UInt32)MockDataSource.ComplexList.Count - 1;
                var poly = new Polynomial<Complex, ComplexRing>(degree);

                for (UInt32 i = 0; i < degree + 1; i++)
                {
                    poly[i] = 2 * MockDataSource.ComplexList[(Int32)i];
                }

                return poly;
            }
        }

        IPolynomial<Double, DoubleField> ExpectedDoubleIPolynomialSource
        {
            get
            {
                var degree = (UInt32)MockDataSource.DoubleList.Count - 1;
                var poly = new Polynomial<Double, DoubleField>(degree);

                for (UInt32 i = 0; i < degree + 1; i++)
                {
                    poly[i] = 2 * MockDataSource.DoubleList[(Int32)i];
                }

                return poly;
            }
        }

        IEnumerable<TestCaseData> PolynomialAddTestDataSource
        {
            get
            {
                yield return new TestCaseData(0, new Int32Group(), MockDataSource.GroupInt32IPolynomialSource, MockDataSource.GroupInt32IPolynomialSource, ExpectedInt32IPolynomialSource);
                yield return new TestCaseData(3.678, new DoubleField(), MockDataSource.FieldDoubleIPolynomialSource, MockDataSource.FieldDoubleIPolynomialSource, ExpectedDoubleIPolynomialSource);
                yield return new TestCaseData(new Complex(5, 58), new ComplexRing(), MockDataSource.RingComplexIPolynomialSource, MockDataSource.RingComplexIPolynomialSource, ExpectedComplexIPolynomialSource);
            }
        }

        #endregion

        #region methods

        [Test]
        [Category("PolynomialFromMonoidTest")]
        [TestCaseSource("PolynomialAddTestDataSource")]
        public void Add_AddTwoTuples_EqualsExpectedTuple<T, TMonoid>(T hackForGenericParameter1, 
                                                                     TMonoid hackForGenericParameter2, 
                                                                     IPolynomial<T, TMonoid> polynomial1, 
                                                                     IPolynomial<T, TMonoid> polynomial2, 
                                                                     IPolynomial<T, TMonoid> expectedPolynomial)
            where TMonoid : IMonoid<T>, new()
        {
            var result = polynomial1.Add(polynomial2);

            Assert.AreEqual(expectedPolynomial, result);
        }

        #endregion
    }
}