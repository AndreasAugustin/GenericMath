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
    using System.Linq;
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

        List<Int32> _int32List;
        List<Double> _doubleList;
        List<Complex> _complexList;

        #endregion

        #region properties

        IDirectSum<Int32, Int32Group> Int32IVectorSource
        {
            get
            {
                _int32List = new List<int>{ 2, -2 };

                var dimension = (UInt32)_int32List.Count;
                var vector = new DirectSum<Int32, Int32Group>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = _int32List[(Int32)i];
                }

                return vector;
            }
        }

        IDirectSum<Complex, ComplexRing> ComplexIVectorSource
        {
            get
            {
                _complexList = new List<Complex>{ new Complex(1, 2), new Complex(4, 56) };


                var dimension = (UInt32)_complexList.Count;
                var vector = new DirectSum<Complex, ComplexRing>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = _complexList[(Int32)i];
                }

                return vector;
            }
        }

        IDirectSum<Double, DoubleMonoid> DoubleIVectorSource
        {
            get
            {
                _doubleList = new List<Double>{ 3.678 };

                var dimension = (UInt32)_doubleList.Count;
                var vector = new DirectSum<Double, DoubleMonoid>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = _doubleList[(Int32)i];
                }

                return vector;
            }
        }

        IEnumerable<TestCaseData> DirectSumSumElementsTestDataSource
        {
            get
            {
                yield return new TestCaseData(0, new Int32Group(), Int32IVectorSource);
                yield return new TestCaseData(3.678, new DoubleMonoid(), DoubleIVectorSource);
                yield return new TestCaseData(new Complex(5, 58), new ComplexRing(), ComplexIVectorSource);
            }
        }

        #endregion

        #region methods

        [Category("DirectSumTest")]
        [TestCaseSource("DirectSumSumElementsTestDataSource")]
        [Test]
        public void SumElements_EqualsExpectedValue<T, TMonoid>(T expectedValue, TMonoid hackForGenericParameter, IDirectSum<T, TMonoid> tuple)
            where TMonoid : IMonoid<T>, new()
        {
            var result = tuple.SumElements();

            Assert.AreEqual(expectedValue, result);
        }

        #endregion
    }
}