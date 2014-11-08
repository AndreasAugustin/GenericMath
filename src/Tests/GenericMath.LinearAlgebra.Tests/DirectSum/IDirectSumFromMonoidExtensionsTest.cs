//  *************************************************************
// <copyright file="IDirectSumFromMonoidExtensionsTest.cs" company="None">
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
    /// Test for the extension methods for direct sums for monoids.
    /// </summary>
    [TestFixture]
    public class IDirectSumFromMonoidExtensionsTest
    {
        #region fields

        private FakeDirectSumTestDataSource _mockDirectSumTestDataSource;

        #endregion

        #region properties

        private FakeDirectSumTestDataSource MockDirectSumTestDataSource
        {
            get
            {
                return this._mockDirectSumTestDataSource ?? (this._mockDirectSumTestDataSource = new FakeDirectSumTestDataSource());
            }
        }

        private IDirectSum<int, Int32Group> ExpectedInt32IVectorSource
        {
            get
            {               
                var dimension = (uint)this.MockDirectSumTestDataSource.Int32List.Count;
                var vector = new DirectSum<int, Int32Group>(dimension);

                for (uint i = 0; i < dimension; i++)
                {
                    vector[i] = 2 * this.MockDirectSumTestDataSource.Int32List[(int)i];
                }

                return vector;
            }
        }

        private IDirectSum<Complex, ComplexRing> ExpectedComplexIVectorSource
        {
            get
            {
                var dimension = (uint)this.MockDirectSumTestDataSource.ComplexList.Count;
                var vector = new DirectSum<Complex, ComplexRing>(dimension);

                for (uint i = 0; i < dimension; i++)
                {
                    vector[i] = 2 * this.MockDirectSumTestDataSource.ComplexList[(int)i];
                }

                return vector;
            }
        }

        private IDirectSum<double, DoubleField> ExpectedDoubleIVectorSource
        {
            get
            {
                var dimension = (uint)this.MockDirectSumTestDataSource.DoubleList.Count;
                var vector = new DirectSum<double, DoubleField>(dimension);

                for (uint i = 0; i < dimension; i++)
                {
                    vector[i] = 2 * this.MockDirectSumTestDataSource.DoubleList[(int)i];
                }

                return vector;
            }
        }

        private IEnumerable<TestCaseData> DirectSumSumElementsTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    0,
                    new Int32Group(),
                    this.MockDirectSumTestDataSource.GroupInt32IDirectSumSource);
                yield return new TestCaseData(
                    3.678,
                    new DoubleField(),
                    this.MockDirectSumTestDataSource.FieldDoubleIDirectSumSource);
                yield return new TestCaseData(
                    new Complex(5, 58),
                    new ComplexRing(),
                    this.MockDirectSumTestDataSource.RingComplexIDirectSumSource);
            }
        }

        private IEnumerable<TestCaseData> DirectSumAddTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    0,
                    new Int32Group(),
                    this.MockDirectSumTestDataSource.GroupInt32IDirectSumSource,
                    this.MockDirectSumTestDataSource.GroupInt32IDirectSumSource,
                    this.ExpectedInt32IVectorSource);
                yield return new TestCaseData(
                    3.678,
                    new DoubleField(),
                    this.MockDirectSumTestDataSource.FieldDoubleIDirectSumSource,
                    this.MockDirectSumTestDataSource.FieldDoubleIDirectSumSource,
                    this.ExpectedDoubleIVectorSource);
                yield return new TestCaseData(
                    new Complex(5, 58),
                    new ComplexRing(),
                    this.MockDirectSumTestDataSource.RingComplexIDirectSumSource,
                    this.MockDirectSumTestDataSource.RingComplexIDirectSumSource,
                    this.ExpectedComplexIVectorSource);
            }
        }

        private IEnumerable<TestCaseData> DirectSumInjectionTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    0,
                    new Int32Group(),
                    this.MockDirectSumTestDataSource.GroupInt32IDirectSumSource,
                    3);
                yield return new TestCaseData(
                    3.678,
                    new DoubleField(),
                    this.MockDirectSumTestDataSource.FieldDoubleIDirectSumSource,
                    2);
                yield return new TestCaseData(
                    new Complex(5, 58),
                    new ComplexRing(),
                    this.MockDirectSumTestDataSource.RingComplexIDirectSumSource,
                    1);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Checks the SumElements method.
        /// </summary>
        /// <param name="expectedValue">Expected value.</param>
        /// <param name="hackForGenericParameter">Hack for generic parameter.</param>
        /// <param name="tuple">The tuple.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TMonoid">The underlying monoid.</typeparam>
        [Category("DirectSumFromMonoidTest")]
        [TestCaseSource("DirectSumSumElementsTestDataSource")]
        [Test]
        public void SumElements_EqualsExpectedValue<T, TMonoid>(
            T expectedValue,
            TMonoid hackForGenericParameter, 
            IDirectSum<T, TMonoid> tuple)
            where TMonoid : IMonoid<T>, new()
        {
            var result = tuple.SumElements();

            Assert.AreEqual(expectedValue, result);
        }

        /// <summary>
        /// Adds the add two tuples equals expected tuple.
        /// </summary>
        /// <param name="hackForGenericParameter1">Hack for generic parameter1.</param>
        /// <param name="hackForGenericParameter2">Hack for generic parameter2.</param>
        /// <param name="tuple1">The first tuple.</param>
        /// <param name="tuple2">The second tuple.</param>
        /// <param name="expectedTuple">Expected tuple.</param>
        /// <typeparam name="T">The first type parameter.</typeparam>
        /// <typeparam name="TMonoid">The second type parameter.</typeparam>
        [Test]
        [Category("DirectSumFromMonoidTest")]
        [TestCaseSource("DirectSumAddTestDataSource")]       
        public void Add_AddTwoTuples_EqualsExpectedTuple<T, TMonoid>(
            T hackForGenericParameter1, 
            TMonoid hackForGenericParameter2, 
            IDirectSum<T, TMonoid> tuple1, 
            IDirectSum<T, TMonoid> tuple2, 
            IDirectSum<T, TMonoid> expectedTuple)
            where TMonoid : IMonoid<T>, new()
        {
            var result = tuple1.Add(tuple2);

            Assert.AreEqual(expectedTuple, result);
        }

        /// <summary>
        /// Injections the inject new dimension dimension equals expected.
        /// </summary>
        /// <param name="hackForGenericParameter1">Hack for generic parameter1.</param>
        /// <param name="monoid">The monoid.</param>
        /// <param name="tuple">The tuple.</param>
        /// <param name="additionalDimensions">Additional dimensions.</param>
        /// <typeparam name="T">The first type parameter.</typeparam>
        /// <typeparam name="TMonoid">The second type parameter.</typeparam>
        [Test]
        [TestCaseSource("DirectSumInjectionTestDataSource")]
        [Category("DirectSumFromMonoidTest")]
        public void Injection_InjectNewDimension_DimensionEqualsExpected<T, TMonoid>(
            T hackForGenericParameter1, 
            TMonoid monoid, 
            IDirectSum<T, TMonoid> tuple, 
            uint additionalDimensions)
            where TMonoid : IMonoid<T>, new()
        {
            var result = tuple.Injection(additionalDimensions);
            var resultDimension = result.Dimension;

            var tupleDimension = tuple.Dimension;

            var expectedResultDimension = tupleDimension + additionalDimensions;

            Assert.AreEqual(expectedResultDimension, resultDimension);

            Assert.AreEqual(monoid.Zero, result[resultDimension - 1]);
        }

        #endregion
    }
}