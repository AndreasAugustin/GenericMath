//  *************************************************************
// <copyright file="IDirectSumExtensionsTest.cs" company="None">
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
    /// Vector extensions test.
    /// </summary>
    [TestFixture]
    public class IDirectSumExtensionsTest
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

        private IEnumerable<TestCaseData> DirectSumComparableDataSource
        {
            get
            {
                yield return new TestCaseData(
                    default(int),
                    new Int32Group(),
                    this.MockDirectSumTestDataSource.GroupInt32IDirectSumSource,
                    this.MockDirectSumTestDataSource.Int32List);
                yield return new TestCaseData(
                    default(double),
                    new DoubleField(),
                    this.MockDirectSumTestDataSource.FieldDoubleIDirectSumSource,
                    this.MockDirectSumTestDataSource.DoubleList);
            }
        }

        private IEnumerable<TestCaseData> DirectSumTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    default(int),
                    new Int32Group(),
                    this.MockDirectSumTestDataSource.GroupInt32IDirectSumSource);
                yield return new TestCaseData(
                    default(double),
                    new DoubleField(),
                    this.MockDirectSumTestDataSource.FieldDoubleIDirectSumSource);
                yield return new TestCaseData(
                    default(Complex),
                    new ComplexRing(),
                    this.MockDirectSumTestDataSource.RingComplexIDirectSumSource);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the copy method.
        /// Checks if the copied vector is a new instance 
        /// and that the vectors equal each other.
        /// </summary>
        /// <param name="hackForGenericParameter1">The first parameter is not needed for the test, only to make the method work.</param>
        /// <param name="hackForGenericParameter2">The second parameter is not needed for the test, only to make the method work.</param>
        /// <param name="tuple">The vector for the test.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure for the set.</typeparam>
        [Category("DirectSumTest")]
        [Test, TestCaseSource("DirectSumTestDataSource")]
        public void Copy_IsNewInstance_VectorsAreEqual<T, TStruct>(
            T hackForGenericParameter1,
            TStruct hackForGenericParameter2,
            IDirectSum<T, TStruct> tuple)
            where TStruct : IStructure<T>, new()
        {
            var tupleCopy = tuple.Copy();

            // the references and the type should not be the same.
            Assert.IsFalse(object.ReferenceEquals(tuple, tupleCopy));

            // The values should be the same.
            Assert.AreEqual(tuple.Dimension, tupleCopy.Dimension);         

            Assert.AreEqual(tuple, tupleCopy);
        }

        /// <summary>
        /// Tests the insertionSort method.
        /// Checks if the copied vector is a new instance 
        /// and that the vectors equal each other.
        /// </summary>
        /// <param name="hackForGenericParameter1">The first parameter is not needed for the test, only to make the method work.</param>
        /// <param name="hackForGenericParameter2">The second parameter is not needed for the test, only to make the method work.</param>
        /// <param name="tupleToSort">The vector for the test.</param>
        /// <param name="list">The expected vector to compare.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure for the set.</typeparam>
        [Category("DirectSumTest")]
        [Test, TestCaseSource("DirectSumComparableDataSource")]
        public void InsertionSort_Sort_AreEqual<T, TStruct>(
            T hackForGenericParameter1,
            TStruct hackForGenericParameter2,
            IDirectSum<T, TStruct> tupleToSort,
            List<T> list)
            where T : IComparable
            where TStruct : IStructure<T>, new()
        {
            list.Sort();

            var sortedVector = tupleToSort.InsertionSort();

            // the references and the type should not be the same.
            Assert.IsFalse(object.ReferenceEquals(sortedVector, tupleToSort));

            // The values should be the same.
            Assert.AreEqual(tupleToSort.Dimension, sortedVector.Dimension);
            Assert.AreEqual(list.Count, sortedVector.Dimension);

            for (uint i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(list[(int)i], sortedVector[i]);
            }
        }

        /// <summary>
        /// Tests the insertionSort method.
        /// Checks if the copied vector is a new instance 
        /// and that the vectors equal each other.
        /// </summary>
        /// <param name="hackForGenericParameter1">The first parameter is not needed for the test, only to make the method work.</param>
        /// <param name="hackForGenericParameter2">The second parameter is not needed for the test, only to make the method work.</param>
        /// <param name="tupleToSort">The vector for the test.</param>
        /// <param name="list">The expected vector to compare.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure for the set.</typeparam>
        [Category("DirectSumTest")]
        [Test, TestCaseSource("DirectSumComparableDataSource")]
        public void BubbleSort_Sort_AreEqual<T, TStruct>(
            T hackForGenericParameter1,
            TStruct hackForGenericParameter2, 
            IDirectSum<T, TStruct> tupleToSort,
            List<T> list)
            where T : IComparable
            where TStruct : IStructure<T>, new()
        {
            list.Sort();

            var sortedVector = tupleToSort.BubbleSort();

            // the references and the type should not be the same.
            Assert.IsFalse(object.ReferenceEquals(sortedVector, tupleToSort));

            // The values should be the same.
            Assert.AreEqual(tupleToSort.Dimension, sortedVector.Dimension);
            Assert.AreEqual(list.Count, sortedVector.Dimension);

            for (uint i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(list[(int)i], sortedVector[i]);
            }
        }

        #endregion
    }
}