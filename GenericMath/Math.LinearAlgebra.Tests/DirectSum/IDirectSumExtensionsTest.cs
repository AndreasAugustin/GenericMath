//  *************************************************************
// <copyright file="IDirectSumExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  29 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NSubstitute;
    using NUnit.Framework;

    /// <summary>
    /// Vector extensions test.
    /// </summary>
    [TestFixture]
    public class IDirectSumExtensionsTest
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

        IEnumerable<TestCaseData> DirectSumComparableDataSource
        {
            get
            {
                yield return new TestCaseData(default(Int32), new Int32Group(), Int32IVectorSource, _int32List);
                yield return new TestCaseData(default(Double), new DoubleMonoid(), DoubleIVectorSource, _doubleList);
            }
        }

        IEnumerable<TestCaseData> DirectSumTestDataSource
        {
            get
            {
                yield return new TestCaseData(default(Int32), new Int32Group(), Int32IVectorSource);
                yield return new TestCaseData(default(Double), new DoubleMonoid(), DoubleIVectorSource);
                yield return new TestCaseData(default(Complex), new ComplexRing(), ComplexIVectorSource);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the copy method.
        /// Checks if the copied vector is a new instance 
        /// and that the vectors equal each other.
        /// </summary>
        /// <typeparam name="hackForGenericParameter1">This parameter is not needed for the test, only to make the method work.</typeparam>
        /// <typeparam name="hackForGenericParameter2">This parameter is not needed for the test, only to make the method work.</typeparam>
        /// <typeparam name="tuple">The vector for the test.</typeparam>
        [Category("DirectSumTest")]
        [Test, TestCaseSource("DirectSumTestDataSource")]
        public void Copy_IsNewInstance_VectorsAreEqual<T, TStruct>(T hackForGenericParameter1, TStruct hackForGenericParameter2, IDirectSum<T, TStruct> tuple)
            where TStruct : IStructure<T>, new()
        {
            var vectorCopy = tuple.Copy();

            // the references and the type should not be the same.
            Assert.IsFalse(Object.ReferenceEquals(tuple, vectorCopy));

            // The values should be the same.
            Assert.AreEqual(tuple.Dimension, vectorCopy.Dimension);         

            Assert.AreEqual(tuple, vectorCopy);
        }

        /// <summary>
        /// Tests the insertionSort method.
        /// Checks if the copied vector is a new instance 
        /// and that the vectors equal each other.
        /// </summary>
        /// <typeparam name="hackForGenericParameter1">This parameter is not needed for the test, only to make the method work.</typeparam>
        /// <typeparam name="hackForGenericParameter2">This parameter is not needed for the test, only to make the method work.</typeparam>
        /// <typeparam name="tupleToSort">The vector for the test.</typeparam>
        /// <typeparam name="expectedSortedVector">The expected vector to compare.</typeparam>
        [Category("DirectSumTest")]
        [Test, TestCaseSource("DirectSumComparableDataSource")]
        public void InsertionSort_Sort_AreEqual<T, TStruct>(T hackForGenericParameter1, TStruct hackForGenericParameter2,
                                                            IDirectSum<T, TStruct> tupleToSort, List<T> list)
            where T : IComparable
            where TStruct : IStructure<T>, new()
        {
            list.Sort();

            var sortedVector = tupleToSort.InsertionSort();

            // the references and the type should not be the same.
            Assert.IsFalse(Object.ReferenceEquals(sortedVector, tupleToSort));

            // The values should be the same.
            Assert.AreEqual(tupleToSort.Dimension, sortedVector.Dimension);
            Assert.AreEqual(list.Count, sortedVector.Dimension);

            for (UInt32 i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(list[(Int32)i], sortedVector[i]);
            }
        }

        /// <summary>
        /// Tests the insertionSort method.
        /// Checks if the copied vector is a new instance 
        /// and that the vectors equal each other.
        /// </summary>
        /// <typeparam name="hackForGenericParameter1">This parameter is not needed for the test, only to make the method work.</typeparam>
        /// <typeparam name="hackForGenericParameter2">This parameter is not needed for the test, only to make the method work.</typeparam>
        /// <typeparam name="tupleToSort">The vector for the test.</typeparam>
        /// <typeparam name="expectedSortedVector">The expected vector to compare.</typeparam>
        [Category("DirectSumTest")]
        [Test, TestCaseSource("DirectSumComparableDataSource")]
        public void BubbleSort_Sort_AreEqual<T, TStruct>(T hackForGenericParameter1, TStruct hackForGenericParameter2, 
                                                         IDirectSum<T, TStruct> tupleToSort, List<T> list)
            where T : IComparable
            where TStruct : IStructure<T>, new()
        {
            list.Sort();

            var sortedVector = tupleToSort.BubbleSort();

            // the references and the type should not be the same.
            Assert.IsFalse(Object.ReferenceEquals(sortedVector, tupleToSort));

            // The values should be the same.
            Assert.AreEqual(tupleToSort.Dimension, sortedVector.Dimension);
            Assert.AreEqual(list.Count, sortedVector.Dimension);

            for (UInt32 i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(list[(Int32)i], sortedVector[i]);
            }
        }

        #endregion
    }
}