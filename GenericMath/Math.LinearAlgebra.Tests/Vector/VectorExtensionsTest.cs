//  *************************************************************
// <copyright file="VectorExtensionsTest.cs" company="${Company}">
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
    public class VectorExtensionsTest
    {
        #region fields

        List<Int32> _int32List;
        List<Double> _doubleList;
        List<Complex> _complexList;

        #endregion

        #region properties

        IVector<Int32, Int32Group> Int32IVectorSource
        {
            get
            {
                _int32List = new List<int>{ 2, -2 };

                var vector = Substitute.For<IVector<Int32, Int32Group>>();

                var dimension = (UInt32)_int32List.Count;
                vector.Dimension.Returns(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i].Returns(_int32List[(Int32)i]);
                }

                return vector;
            }
        }

        IVector<Complex, ComplexRing> ComplexIVectorSource
        {
            get
            {
                _complexList = new List<Complex>{ new Complex(1, 2), new Complex(4, 56) };

                var vector = Substitute.For<IVector<Complex, ComplexRing>>();

                var dimension = (UInt32)_complexList.Count;
                vector.Dimension.Returns(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i].Returns(_complexList[(Int32)i]);
                }

                return vector;
            }
        }

        IVector<Double, DoubleMonoid> DoubleIVectorSource
        {
            get
            {
                _doubleList = new List<Double>{ 3.678 };

                var vector = Substitute.For<IVector<Double, DoubleMonoid>>();

                var dimension = (UInt32)_doubleList.Count;
                vector.Dimension.Returns(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i].Returns(_doubleList[(Int32)i]);
                }

                return vector;
            }
        }

        IEnumerable<TestCaseData> VectorComparableDataSource
        {
            get
            {
                yield return new TestCaseData(default(Int32), new Int32Group(), Int32IVectorSource, _int32List);
                yield return new TestCaseData(default(Double), new DoubleMonoid(), DoubleIVectorSource, _doubleList);
            }
        }

        IEnumerable<TestCaseData> VectorTestDataSource
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
        /// and that the vetors equal each other.
        /// </summary>
        /// <typeparam name="hackForGenericParameter1">This parameter is not needed for the test, only to make the method work.</typeparam>
        /// <typeparam name="hackForGenericParameter2">This parameter is not needed for the test, only to make the method work.</typeparam>
        /// <typeparam name="vector">The vector for the test.</typeparam>
        [Category("VectorTest")]
        [Test, TestCaseSource("VectorTestDataSource")]
        public void Copy_IsNewInstance_VectorsAreEqual<T, TStruct>(T hackForGenericParameter1, TStruct hackForGenericParameter2, IVector<T, TStruct> vector)
            where TStruct : IStructure<T>, new()
        {
            var vectorCopy = vector.Copy();

            // the references and the type should not be the same.
            Assert.IsFalse(Object.ReferenceEquals(vector, vectorCopy));
            Assert.AreNotEqual(vector, vectorCopy);

            // The values should be the same.
            Assert.AreEqual(vector.Dimension, vectorCopy.Dimension);

            for (UInt32 i = 0; i < vector.Dimension; i++)
            {
                Assert.AreEqual(vector[i], vectorCopy[i]);
            }

        }

        /// <summary>
        /// Tests the insertionSort method.
        /// Checks if the copied vector is a new instance 
        /// and that the vetors equal each other.
        /// </summary>
        /// <typeparam name="hackForGenericParameter1">This parameter is not needed for the test, only to make the method work.</typeparam>
        /// <typeparam name="hackForGenericParameter2">This parameter is not needed for the test, only to make the method work.</typeparam>
        /// <typeparam name="vector">The vector for the test.</typeparam>
        /// <typeparam name="expectedSortedVector">The expected vector to compare.</typeparam>
        [Category("VectorTest")]
        [Test, TestCaseSource("VectorComparableDataSource")]
        public void InsertionSort_Sort_AreEqual<T, TStruct>(T hackForGenericParameter1, TStruct hackForGenericParameter2, IVector<T, TStruct> vectorToSort, List<T> list)
            where T : IComparable
            where TStruct : IStructure<T>, new()
        {
            list.Sort();

            var sortedVector = vectorToSort.InsertionSort();

            // the references and the type should not be the same.
            Assert.IsFalse(Object.ReferenceEquals(sortedVector, vectorToSort));

            // The values should be the same.
            Assert.AreEqual(vectorToSort.Dimension, sortedVector.Dimension);
            Assert.AreEqual(list.Count, sortedVector.Dimension);

            for (UInt32 i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(list[(Int32)i], sortedVector[i]);
            }
        }

        #endregion
    }
}