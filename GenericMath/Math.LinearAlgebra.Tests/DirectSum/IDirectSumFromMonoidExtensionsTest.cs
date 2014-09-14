//  *************************************************************
// <copyright file="IDirectSumFromMonoidExtensions.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    /// <summary>
    /// Test for the extension methods for direct sums for monoids.
    /// </summary>
    [TestFixture]
    public class IDirectSumFromMonoidExtensions
    {
        #region fields

        FakeDirectSumTestDataSource _mockDirectSumTestDataSource;

        #endregion

        #region properties

        FakeDirectSumTestDataSource MockDirectSumTestDataSource
        {
            get
            {
                return _mockDirectSumTestDataSource ?? (_mockDirectSumTestDataSource = new FakeDirectSumTestDataSource());
            }
        }

        IDirectSum<Int32, Int32Group> ExpectedInt32IVectorSource
        {
            get
            {               
                var dimension = (UInt32)MockDirectSumTestDataSource.Int32List.Count;
                var vector = new DirectSum<Int32, Int32Group>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = 2 * MockDirectSumTestDataSource.Int32List[(Int32)i];
                }

                return vector;
            }
        }

        IDirectSum<Complex, ComplexRing> ExpectedComplexIVectorSource
        {
            get
            {
                var dimension = (UInt32)MockDirectSumTestDataSource.ComplexList.Count;
                var vector = new DirectSum<Complex, ComplexRing>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = 2 * MockDirectSumTestDataSource.ComplexList[(Int32)i];
                }

                return vector;
            }
        }

        IDirectSum<Double, DoubleField> ExpectedDoubleIVectorSource
        {
            get
            {
                var dimension = (UInt32)MockDirectSumTestDataSource.DoubleList.Count;
                var vector = new DirectSum<Double, DoubleField>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = 2 * MockDirectSumTestDataSource.DoubleList[(Int32)i];
                }

                return vector;
            }
        }

        IEnumerable<TestCaseData> DirectSumSumElementsTestDataSource
        {
            get
            {
                yield return new TestCaseData(0, new Int32Group(), MockDirectSumTestDataSource.GroupInt32IDirectSumSource);
                yield return new TestCaseData(3.678, new DoubleField(), MockDirectSumTestDataSource.FieldDoubleIDirectSumSource);
                yield return new TestCaseData(new Complex(5, 58), new ComplexRing(), MockDirectSumTestDataSource.RingComplexIDirectSumSource);
            }
        }

        IEnumerable<TestCaseData> DirectSumAddTestDataSource
        {
            get
            {
                yield return new TestCaseData(0, new Int32Group(), MockDirectSumTestDataSource.GroupInt32IDirectSumSource, MockDirectSumTestDataSource.GroupInt32IDirectSumSource, ExpectedInt32IVectorSource);
                yield return new TestCaseData(3.678, new DoubleField(), MockDirectSumTestDataSource.FieldDoubleIDirectSumSource, MockDirectSumTestDataSource.FieldDoubleIDirectSumSource, ExpectedDoubleIVectorSource);
                yield return new TestCaseData(new Complex(5, 58), new ComplexRing(), MockDirectSumTestDataSource.RingComplexIDirectSumSource, MockDirectSumTestDataSource.RingComplexIDirectSumSource, ExpectedComplexIVectorSource);
            }
        }

        IEnumerable<TestCaseData> DirectSumInjectionTestDataSource
        {
            get
            {
                yield return new TestCaseData(0, new Int32Group(), MockDirectSumTestDataSource.GroupInt32IDirectSumSource, 3);
                yield return new TestCaseData(3.678, new DoubleField(), MockDirectSumTestDataSource.FieldDoubleIDirectSumSource, 2);
                yield return new TestCaseData(new Complex(5, 58), new ComplexRing(), MockDirectSumTestDataSource.RingComplexIDirectSumSource, 1);
            }
        }

        #endregion

        #region methods

        [Category("DirectSumFromMonoidTest")]
        [TestCaseSource("DirectSumSumElementsTestDataSource")]
        [Test]
        public void SumElements_EqualsExpectedValue<T, TMonoid>(T expectedValue, TMonoid hackForGenericParameter, 
                                                                IDirectSum<T, TMonoid> tuple)
            where TMonoid : IMonoid<T>, new()
        {
            var result = tuple.SumElements();

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        [Category("DirectSumFromMonoidTest")]
        [TestCaseSource("DirectSumAddTestDataSource")]
        public void Add_AddTwoTuples_EqualsExpectedTuple<T, TMonoid>(T hackForGenericParameter1, 
                                                                     TMonoid hackForGenericParameter2, 
                                                                     IDirectSum<T, TMonoid> tuple1, 
                                                                     IDirectSum<T, TMonoid> tuple2, 
                                                                     IDirectSum<T, TMonoid> expectedTuple)
            where TMonoid : IMonoid<T>, new()
        {
            var result = tuple1.Add(tuple2);

            Assert.AreEqual(expectedTuple, result);
        }

        [Test]
        [TestCaseSource("DirectSumInjectionTestDataSource")]
        [Category("DirectSumFromMonoidTest")]
        public void Injection_InjectNewDimension_DimensionEqualsExpected<T, TMonoid>(T hackForGenericParameter1, 
                                                                                     TMonoid monoid, 
                                                                                     IDirectSum<T, TMonoid> tuple, 
                                                                                     UInt32 additionalDimensions)
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