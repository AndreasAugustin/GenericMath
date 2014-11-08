//  *************************************************************
// <copyright file="IPolynomialExtensionsTest.cs" company="None">
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
    /// Tests for the <see cref="IPolynomialExtensions"/> class. 
    /// </summary>
    [TestFixture]
    public class IPolynomialExtensionsTest
    {
        #region fields

        private FakePolynomialTestDataSource _mockPolynomialTestSource;

        #endregion

        #region properties

        private FakePolynomialTestDataSource MockPolynomialTestSource
        {
            get
            {
                return this._mockPolynomialTestSource ?? (this._mockPolynomialTestSource = new FakePolynomialTestDataSource());
            }
        }

        private IEnumerable<TestCaseData> PolynomialCopyTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    default(int),
                    new Int32Group(),
                    this.MockPolynomialTestSource.GroupInt32IPolynomialSource);
                yield return new TestCaseData(
                    default(double),
                    new DoubleField(),
                    this.MockPolynomialTestSource.FieldDoubleIPolynomialSource);
                yield return new TestCaseData(
                    default(Complex),
                    new ComplexRing(),
                    this.MockPolynomialTestSource.RingComplexIPolynomialSource);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Checks if the copy function returns a new instance with equal entries.
        /// </summary>
        /// <param name="hackForGenericParameter1">Hack for generic parameter1.</param>
        /// <param name="hackForGenericParameter2">Hack for generic parameter2.</param>
        /// <param name="polynomial">The polynomial to copy.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        [Category("PolynomialTest")]
        [Test]
        [TestCaseSource("PolynomialCopyTestDataSource")]
        public void Copy_IsNewInstance_PolynomialsAreEqual<T, TStruct>(
            T hackForGenericParameter1,
            TStruct hackForGenericParameter2,
            IPolynomial<T, TStruct> polynomial)
            where TStruct : IStructure<T>, new()
        {
            var polynomialCopy = polynomial.Copy();

            // the references and the type should not be the same.
            Assert.IsFalse(object.ReferenceEquals(polynomial, polynomialCopy));

            // The values should be the same.
            Assert.AreEqual(polynomial.Degree, polynomialCopy.Degree);         

            Assert.AreEqual(polynomial, polynomialCopy);
        }

        #endregion
    }
}