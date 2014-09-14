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
    using NUnit.Framework;

    /// <summary>
    /// Vector extensions test.
    /// </summary>
    [TestFixture]
    public class IDirectSumExtensionsTest
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

        IEnumerable<TestCaseData> DirectSumComparableDataSource
        {
            get
            {
                yield return new TestCaseData(default(Int32), new Int32Group(), MockDirectSumTestDataSource.GroupInt32IDirectSumSource, MockDirectSumTestDataSource.Int32List);
                yield return new TestCaseData(default(Double), new DoubleField(), MockDirectSumTestDataSource.FieldDoubleIDirectSumSource, MockDirectSumTestDataSource.DoubleList);
            }
        }

        IEnumerable<TestCaseData> DirectSumTestDataSource
        {
            get
            {
                yield return new TestCaseData(default(Int32), new Int32Group(), MockDirectSumTestDataSource.GroupInt32IDirectSumSource);
                yield return new TestCaseData(default(Double), new DoubleField(), MockDirectSumTestDataSource.FieldDoubleIDirectSumSource);
                yield return new TestCaseData(default(Complex), new ComplexRing(), MockDirectSumTestDataSource.RingComplexIDirectSumSource);
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