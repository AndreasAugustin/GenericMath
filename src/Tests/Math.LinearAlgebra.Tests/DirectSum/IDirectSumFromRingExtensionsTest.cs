//  *************************************************************
// <copyright file="IDirectSumFromRingExtensionsTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
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

        private IDirectSum<int, Int32Ring> ExpectedInt32IVectorSource
        {
            get
            {               
                var dimension = (uint)this.MockDirectSumTestDataSource.Int32List.Count;
                var vector = new DirectSum<int, Int32Ring>(dimension);

                for (uint i = 0; i < dimension; i++)
                {
                    var el = this.MockDirectSumTestDataSource.Int32List[(int)i];
                    vector[i] = el * el;
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
                    var el = this.MockDirectSumTestDataSource.ComplexList[(int)i];
                    vector[i] = el * el;
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
                    var el = this.MockDirectSumTestDataSource.DoubleList[(int)i];
                    vector[i] = el * el;
                }

                return vector;
            }
        }

        private IEnumerable<TestCaseData> DirectSumMultiplyTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    0,
                    new Int32Ring(),
                    this.MockDirectSumTestDataSource.RingInt32IDirectSumSource,
                    this.MockDirectSumTestDataSource.RingInt32IDirectSumSource,
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

        #endregion

        #region methods

        /// <summary>
        /// Test the Multipliy method. Multiplies two tuples and checks if the reuslt equals the expected tuple.
        /// </summary>
        /// <param name="hackForGenericParameter1">Hack for generic parameter1.</param>
        /// <param name="hackForGenericParameter2">Hack for generic parameter2.</param>
        /// <param name="tuple1">The frist tuple.</param>
        /// <param name="tuple2">The second tuple.</param>
        /// <param name="expectedTuple">Expected tuple.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TRing">The underlying ring.</typeparam>
        [Test]
        [Category("DirectSumFromRingTest")]
        [TestCaseSource("DirectSumMultiplyTestDataSource")]
        public void Multiply_MultiplyTwoTuples_EqualsExpectedTuple<T, TRing>(
            T hackForGenericParameter1, 
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