//  *************************************************************
// <copyright file="IPolynomialFromRingExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  18 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the IPolynomial extensions with underlying ring as structure.
    /// </summary>
    [TestFixture]
    public class IPolynomialFromRingExtensionsTest
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

        IEnumerable<TestCaseData> PolynomialMultiplyTestDataSource
        {
            get
            {
                yield return new TestCaseData(0, new Int32Ring(), MockDataSource.RingInt32IPolynomialSource, MockDataSource.RingInt32IPolynomialSource);
                yield return new TestCaseData(3.678, new DoubleField(), MockDataSource.FieldDoubleIPolynomialSource, MockDataSource.FieldDoubleIPolynomialSource);
                yield return new TestCaseData(new Complex(5, 58), new ComplexRing(), MockDataSource.RingComplexIPolynomialSource, MockDataSource.RingComplexIPolynomialSource);
            }
        }

        #endregion

        #region methods

        [Test]
        [Category("PolynomialFromRingTest")]
        [TestCaseSource("PolynomialMultiplyTestDataSource")]
        public void Multiply_MultiplyTwoPolynomials_DegreeEqualsxpecedDegree<T, TRing>(T hackForGenericParameter1, 
                                                                                       TRing hackForGenericParameter2, 
                                                                                       IPolynomial<T, TRing> tuple1, 
                                                                                       IPolynomial<T, TRing> tuple2)
            where TRing : IRing<T>, new()
        {
            var result = tuple1.Multiply(tuple2);

            var expectedDegree = tuple1.Degree + tuple2.Degree;
            Assert.AreEqual(expectedDegree, result.Degree);
        }

        #endregion
    }
}