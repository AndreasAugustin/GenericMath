//  *************************************************************
// <copyright file="IPolynomialExtensionsTest.cs" company="${Company}">
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

    [TestFixture]
    public class IPolynomialExtensionsTest
    {
        #region fields

        FakePolynomialTestDataSource _mockPolynomialTestSource;

        #endregion

        #region properties

        FakePolynomialTestDataSource MockPolynomialTestSource
        {
            get
            {
                return _mockPolynomialTestSource ?? (_mockPolynomialTestSource = new FakePolynomialTestDataSource());
            }
        }

        IEnumerable<TestCaseData> PolynomialCopyTestDataSource
        {
            get
            {
                yield return new TestCaseData(default(Int32), new Int32Group(), MockPolynomialTestSource.GroupInt32IPolynomialSource);
                yield return new TestCaseData(default(Double), new DoubleField(), MockPolynomialTestSource.FieldDoubleIPolynomialSource);
                yield return new TestCaseData(default(Complex), new ComplexRing(), MockPolynomialTestSource.RingComplexIPolynomialSource);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Checks if the copy function returns a new instance with euqal entries.
        /// </summary>
        /// <param name="hackForGenericParameter1">Hack for generic parameter1.</param>
        /// <param name="hackForGenericParameter2">Hack for generic parameter2.</param>
        /// <param name="polynomial">The polynomial to copy.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The 2nd type parameter.</typeparam>
        [Category("PolynomialTest")]
        [Test]
        [TestCaseSource("PolynomialCopyTestDataSource")]
        public void Copy_IsNewInstance_PolynomialsAreEqual<T, TStruct>(T hackForGenericParameter1, TStruct hackForGenericParameter2, IPolynomial<T, TStruct> polynomial)
            where TStruct : IStructure<T>, new()
        {
            var polynomialCopy = polynomial.Copy();

            // the references and the type should not be the same.
            Assert.IsFalse(Object.ReferenceEquals(polynomial, polynomialCopy));

            // The values should be the same.
            Assert.AreEqual(polynomial.Degree, polynomialCopy.Degree);         

            Assert.AreEqual(polynomial, polynomialCopy);
        }

        #endregion
    }
}