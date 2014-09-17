//  *************************************************************
// <copyright file="IPolynomialFromGroupExtensionsTest.cs" company="${Company}">
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
    /// Test methods for the extension mehods of IPolynomial with group sructure.
    /// </summary>
    [TestFixture]
    public class IPolynomialFromGroupExtensionsTest
    {
        #region fields

        FakePolynomialTestDataSource _mockTestDataSource;

        #endregion

        #region properties

        FakePolynomialTestDataSource MockTestDataSource
        {
            get
            {
                return _mockTestDataSource ?? (_mockTestDataSource = new FakePolynomialTestDataSource());
            }
        }

        IEnumerable<TestCaseData> PolynomialInverseElementTestDataSource
        {
            get
            {
                yield return new TestCaseData(0, new Int32Group(), MockTestDataSource.GroupInt32IPolynomialSource);
                yield return new TestCaseData(3.678, new DoubleField(), MockTestDataSource.FieldDoubleIPolynomialSource);
                yield return new TestCaseData(new Complex(5, 58), new ComplexRing(), MockTestDataSource.RingComplexIPolynomialSource);
            }
        }

        #endregion

        #region methods

        [Test]
        [Category("PolynomialTest")]
        [TestCaseSource("PolynomialInverseElementTestDataSource")]
        public void InverseElement<T, TGroup>(T hackForGenericParameter, TGroup underlyingGroup, 
                                              IPolynomial<T, TGroup> poly)
            where TGroup : IGroup<T>, new()
        {
            var inverseElement = poly.InversePolynomial();

            Assert.IsNotNull(inverseElement);

            Assert.AreEqual(poly.Degree, inverseElement.Degree);

            for (UInt32 i = 0; i < poly.Degree; i++)
            {
                var expectedInverse = underlyingGroup.Inverse(poly[i]);
                Assert.AreEqual(expectedInverse, inverseElement[i]);
            }
        }

        #endregion
    }
}