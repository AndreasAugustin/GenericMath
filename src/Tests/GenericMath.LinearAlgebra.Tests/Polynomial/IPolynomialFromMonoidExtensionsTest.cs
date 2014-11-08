//  *************************************************************
// <copyright file="IPolynomialFromMonoidExtensionsTest.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
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
    /// Tests for the extension methods for polynomials with underlying Monoid structure.
    /// </summary>
    [TestFixture]
    public class IPolynomialFromMonoidExtensionsTest
    {
        #region fields

        private FakePolynomialTestDataSource _mockDataSource;

        #endregion

        #region properties

        private FakePolynomialTestDataSource MockDataSource
        {
            get
            {
                return this._mockDataSource ?? (this._mockDataSource = new FakePolynomialTestDataSource());
            }
        }

        private IPolynomial<int, Int32Group> ExpectedInt32IPolynomialSource
        {
            get
            {               
                var degree = (uint)this.MockDataSource.Int32List.Count - 1;
                var poly = new Polynomial<int, Int32Group>(degree);

                for (uint i = 0; i < degree + 1; i++)
                {
                    poly[i] = 2 * this.MockDataSource.Int32List[(int)i];
                }

                return poly;
            }
        }

        private IPolynomial<Complex, ComplexRing> ExpectedComplexIPolynomialSource
        {
            get
            {
                var degree = (uint)this.MockDataSource.ComplexList.Count - 1;
                var poly = new Polynomial<Complex, ComplexRing>(degree);

                for (uint i = 0; i < degree + 1; i++)
                {
                    poly[i] = 2 * this.MockDataSource.ComplexList[(int)i];
                }

                return poly;
            }
        }

        private IPolynomial<double, DoubleField> ExpectedDoubleIPolynomialSource
        {
            get
            {
                var degree = (uint)this.MockDataSource.DoubleList.Count - 1;
                var poly = new Polynomial<double, DoubleField>(degree);

                for (uint i = 0; i < degree + 1; i++)
                {
                    poly[i] = 2 * this.MockDataSource.DoubleList[(int)i];
                }

                return poly;
            }
        }

        private IEnumerable<TestCaseData> PolynomialAddTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    0,
                    new Int32Group(),
                    this.MockDataSource.GroupInt32IPolynomialSource,
                    this.MockDataSource.GroupInt32IPolynomialSource,
                    this.ExpectedInt32IPolynomialSource);
                yield return new TestCaseData(
                    3.678,
                    new DoubleField(),
                    this.MockDataSource.FieldDoubleIPolynomialSource,
                    this.MockDataSource.FieldDoubleIPolynomialSource,
                    this.ExpectedDoubleIPolynomialSource);
                yield return new TestCaseData(
                    new Complex(5, 58),
                    new ComplexRing(),
                    this.MockDataSource.RingComplexIPolynomialSource,
                    this.MockDataSource.RingComplexIPolynomialSource,
                    this.ExpectedComplexIPolynomialSource);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Adds the add two tuples equals expected tuple.
        /// </summary>
        /// <param name="hackForGenericParameter1">Hack for generic parameter1.</param>
        /// <param name="hackForGenericParameter2">Hack for generic parameter2.</param>
        /// <param name="polynomial1">The left polynomial.</param>
        /// <param name="polynomial2">The right polynomial.</param>
        /// <param name="expectedPolynomial">Expected polynomial.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TMonoid">The underlying monoid.</typeparam>
        [Test]
        [Category("PolynomialFromMonoidTest")]
        [TestCaseSource("PolynomialAddTestDataSource")]
        public void Add_AddTwoTuples_EqualsExpectedTuple<T, TMonoid>(
            T hackForGenericParameter1, 
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