//  *************************************************************
// <copyright file="IDirectSumFromRingExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  13 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    /// <summary>
    /// Test class for the <see cref="IDirectSumFromRingExtensions"/> class. 
    /// </summary>
    [TestFixture]
    public class IDirectSumFromRingExtensionsTest
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

        IDirectSum<Int32, Int32Ring> ExpectedInt32IVectorSource
        {
            get
            {               
                var dimension = (UInt32)MockDirectSumTestDataSource.Int32List.Count;
                var vector = new DirectSum<Int32, Int32Ring>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    var el = MockDirectSumTestDataSource.Int32List[(Int32)i];
                    vector[i] = el * el;
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
                    var el = MockDirectSumTestDataSource.ComplexList[(Int32)i];
                    vector[i] = el * el;
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
                    var el = MockDirectSumTestDataSource.DoubleList[(Int32)i];
                    vector[i] = el * el;
                }

                return vector;
            }
        }

        IEnumerable<TestCaseData> DirectSumMultiplyTestDataSource
        {
            get
            {
                yield return new TestCaseData(0, new Int32Ring(), MockDirectSumTestDataSource.RingInt32IDirectSumSource, MockDirectSumTestDataSource.RingInt32IDirectSumSource, ExpectedInt32IVectorSource);
                yield return new TestCaseData(3.678, new DoubleField(), MockDirectSumTestDataSource.FieldDoubleIDirectSumSource, MockDirectSumTestDataSource.FieldDoubleIDirectSumSource, ExpectedDoubleIVectorSource);
                yield return new TestCaseData(new Complex(5, 58), new ComplexRing(), MockDirectSumTestDataSource.RingComplexIDirectSumSource, MockDirectSumTestDataSource.RingComplexIDirectSumSource, ExpectedComplexIVectorSource);
            }
        }

        #endregion

        #region methods

        [Test]
        [Category("DirectSumFromRingTest")]
        [TestCaseSource("DirectSumMultiplyTestDataSource")]
        public void Multiply_MultiplyTwoTuples_EqualsExpectedTuple<T, TRing>(T hackForGenericParameter1, 
                                                                             TRing hackForGenericParameter2, 
                                                                             IDirectSum<T, TRing> tuple1, 
                                                                             IDirectSum<T, TRing> tuple2, 
                                                                             IDirectSum<T, TRing> expectedTuple)
            where TRing : IRing<T>, new()
        {
            var result = tuple1.Multiply(tuple2);

            Assert.AreEqual(expectedTuple, result);
        }

        #endregion
    }
}