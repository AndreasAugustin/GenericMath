//  *************************************************************
// <copyright file="IPolynomialFromGroupExtensionsTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using GenericMath.Base;
    using NUnit.Framework;

    /// <summary>
    /// Test methods for the extension methods of IPolynomial with group structure.
    /// </summary>
    [TestFixture]
    public class IPolynomialFromGroupExtensionsTest
    {
        #region fields

        private FakePolynomialTestDataSource _mockTestDataSource;

        #endregion

        #region properties

        private FakePolynomialTestDataSource MockTestDataSource
        {
            get
            {
                return this._mockTestDataSource ?? (this._mockTestDataSource = new FakePolynomialTestDataSource());
            }
        }

        private IEnumerable<TestCaseData> PolynomialInverseElementTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    0,
                    new Int32Group(),
                    this.MockTestDataSource.GroupInt32IPolynomialSource);
                yield return new TestCaseData(
                    3.678,
                    new DoubleField(),
                    this.MockTestDataSource.FieldDoubleIPolynomialSource);
                yield return new TestCaseData(
                    new Complex(5, 58),
                    new ComplexRing(),
                    this.MockTestDataSource.RingComplexIPolynomialSource);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Test for the inverse element.
        /// </summary>
        /// <param name="hackForGenericParameter">Hack for generic parameter.</param>
        /// <param name="underlyingGroup">Underlying group.</param>
        /// <param name="poly">The polynomial.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TGroup">The underlying group.</typeparam>
        [Test]
        [Category("PolynomialTest")]
        [TestCaseSource("PolynomialInverseElementTestDataSource")]
        public void InverseElement<T, TGroup>(
            T hackForGenericParameter, 
            TGroup underlyingGroup, 
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