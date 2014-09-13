//  *************************************************************
// <copyright file="IDirectSumFromGroupExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  10 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    /// <summary>
    /// Test methods for the extesnion methods for IDirectSum with groups as strucure.
    /// Underlying class is <see cref="IDirectSumFromGroupExtensions"/>.
    /// </summary>
    [TestFixture]
    public class IDirectSumFromGroupExtensionsTest
    {
        #region fields

        List<Int32> _int32List;
        List<Double> _doubleList;
        List<Complex> _complexList;

        #endregion

        #region properties

        List<Double> DoubleList
        {
            get
            {
                return _doubleList ?? (_doubleList = new List<Double>{ 3.678 });
            }
        }

        List<Complex> ComplexList
        {
            get
            {
                return _complexList ?? (_complexList = new List<Complex>{ new Complex(1, 2), new Complex(4, 56) });
            }
        }

        List<Int32> Int32List
        {
            get
            {
                return _int32List ?? (_int32List = new List<int>{ 2, -2 });
            }

        }

        IDirectSum<Int32, Int32Group> Int32IVectorSource
        {
            get
            {               
                var dimension = (UInt32)Int32List.Count;
                var vector = new DirectSum<Int32, Int32Group>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = Int32List[(Int32)i];
                }

                return vector;
            }
        }

        IDirectSum<Complex, ComplexRing> ComplexIVectorSource
        {
            get
            {
                var dimension = (UInt32)ComplexList.Count;
                var vector = new DirectSum<Complex, ComplexRing>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = ComplexList[(Int32)i];
                }

                return vector;
            }
        }

        IDirectSum<Double, DoubleField> DoubleIVectorSource
        {
            get
            {
                var dimension = (UInt32)DoubleList.Count;
                var vector = new DirectSum<Double, DoubleField>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = DoubleList[(Int32)i];
                }

                return vector;
            }
        }

        IEnumerable<TestCaseData> DirectSumInverseElementTestDataSource
        {
            get
            {
                yield return new TestCaseData(0, new Int32Group(), Int32IVectorSource);
                yield return new TestCaseData(3.678, new DoubleField(), DoubleIVectorSource);
                yield return new TestCaseData(new Complex(5, 58), new ComplexRing(), ComplexIVectorSource);
            }
        }

        #endregion

        /// <summary>
        /// Tests the InverseElement Method.
        /// </summary>
        [Test]
        [Category("DirectSumTest")]
        [TestCaseSource("DirectSumInverseElementTestDataSource")]
        public void InverseElement<T, TGroup>(T hackForGenericParameter, TGroup underlyingGroup, 
                                              IDirectSum<T, TGroup> tuple)
            where TGroup : IGroup<T>, new()
        {
            var inverseElement = tuple.InverseElement();

            Assert.IsNotNull(inverseElement);

            Assert.AreEqual(tuple.Dimension, inverseElement.Dimension);

            for (UInt32 i = 0; i < tuple.Dimension; i++)
            {
                var expectedInverse = underlyingGroup.Inverse(tuple[i]);
                Assert.AreEqual(expectedInverse, inverseElement[i]);
            }
        }
    }
}