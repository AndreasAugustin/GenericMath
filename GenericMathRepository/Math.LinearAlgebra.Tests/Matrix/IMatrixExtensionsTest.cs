//  *************************************************************
// <copyright file="IMatrixExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  18 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the extensions methods of IMatrix.
    /// </summary>
    [TestFixture]
    public class IMatrixExtensionsTest
    {
        #region fields

        FakeMatrixTestDataSource _mockTestDataSource;

        #endregion

        #region properties

        FakeMatrixTestDataSource MockTestDataSource
        {
            get
            {
                return _mockTestDataSource ?? (_mockTestDataSource = new FakeMatrixTestDataSource());
            }
        }

        IEnumerable<TestCaseData> GetVectorDataSource
        {
            get
            {
                yield return new TestCaseData(default(Int32), new Int32Group(), (UInt32)0, MockTestDataSource.GroupInt32Source, MockTestDataSource.Int32List);
                yield return new TestCaseData(default(Double), new DoubleField(), (UInt32)0, MockTestDataSource.FieldDoubleSource, MockTestDataSource.DoubleList);
                yield return new TestCaseData(default(Complex), new ComplexRing(), (UInt32)0, MockTestDataSource.RingComplexSource, MockTestDataSource.ComplexList);
            }
        }

        IEnumerable<TestCaseData> TransposeDataSource
        {
            get
            {
                yield return new TestCaseData(default(Int32), new Int32Group(), MockTestDataSource.GroupInt32Source);
                yield return new TestCaseData(default(Double), new DoubleField(), MockTestDataSource.FieldDoubleSource);
                yield return new TestCaseData(default(Complex), new ComplexRing(), MockTestDataSource.RingComplexSource);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Gets the column vector check result with expected equals expected.
        /// </summary>
        /// <param name="hack1">Hack for generic parameter.</param>
        /// <param name="hack2">Hack for generic structure.</param>
        /// <param name = "columnIndex"></param>
        /// <param name="matrix">Matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The 2nd type parameter.</typeparam>
        /// <param name = "underlyingList"></param>
        [Category("MatrixExtensionTest")]
        [Test]
        [TestCaseSource("GetVectorDataSource")]
        public void GetColumnVector_CheckResultWithExpected_EqualsExpected<T, TStruct>(T hack1, TStruct hack2, 
                                                                                       UInt32 columnIndex,
                                                                                       IMatrix<T, TStruct> matrix, 
                                                                                       List<List<T>> underlyingList)
                where TStruct : IStructure<T>, new()
        {
            var result = matrix.GetColumnVector(columnIndex);
            var expected = new List<T>();

            foreach (var item in underlyingList)
            {
                expected.Add(item[(Int32)columnIndex]);
            }

            Assert.IsNotNull(result);

            Assert.AreEqual(matrix.RowDimension, result.Dimension);

            for (UInt32 i = 0; i < matrix.RowDimension; i++)
            {
                Assert.AreEqual(expected[(Int32)i], result[i]);
            }
        }

        [Category("MatrixExtensionTest")]
        [Test]
        [TestCaseSource("GetVectorDataSource")]
        public void GetRowVector_CheckResultWithExpected_EqualsExpected<T, TStruct>(T hack1, TStruct hack2, 
                                                                                    UInt32 rowIndex,
                                                                                    IMatrix<T, TStruct> matrix, 
                                                                                    List<List<T>> underlyingList)
            where TStruct : IStructure<T>, new()
        {
            var result = matrix.GetRowVector(rowIndex);

            var expected = new List<T>();

            foreach (var item in underlyingList[(Int32)rowIndex])
            {
                expected.Add(item);
            }

            Assert.IsNotNull(result);

            Assert.AreEqual(matrix.ColumnDimension, result.Dimension);

            for (UInt32 i = 0; i < matrix.ColumnDimension; i++)
            {
                Assert.AreEqual(expected[(Int32)i], result[i]);
            }
        }

        /// <summary>
        /// Tests the matrix transpose extension method.
        /// </summary>
        /// <param name="hack1">Hack1.</param>
        /// <param name="hack2">Hack2.</param>
        /// <param name="matrix">Matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The 2nd type parameter.</typeparam>
        [Category("MatrixExtensionTest")]
        [Test]
        [TestCaseSource("TransposeDataSource")]
        public void Transpose_CheckResultWithGivenParameter_EqualsExpected<T, TStruct>(T hack1, TStruct hack2, 
                                                                                       IMatrix<T, TStruct> matrix)
            where TStruct : IStructure<T>, new()
        {
            var result = matrix.Transpose();

            Assert.IsNotNull(result);

            Assert.AreEqual(matrix.RowDimension, result.ColumnDimension);
            Assert.AreEqual(matrix.ColumnDimension, result.RowDimension);

            for (UInt32 i = 0; i < matrix.RowDimension; i++)
            {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
                {
                    Assert.AreEqual(matrix[i, j], result[j, i]);
                }
            }
        }

        /// <summary>
        /// Tests the matrix copy extension method.
        /// </summary>
        /// <param name="hack1">Hack1.</param>
        /// <param name="hack2">Hack2.</param>
        /// <param name="matrix">Matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TStruct">The 2nd type parameter.</typeparam>
        [Category("MatrixExtensionTest")]
        [Test]
        [TestCaseSource("TransposeDataSource")]
        public void Copy_CheckResultWithGivenParameter_EqualsExpected<T, TStruct>(T hack1, TStruct hack2, 
                                                                                  IMatrix<T, TStruct> matrix)
            where TStruct : IStructure<T>, new()
        {
            var result = matrix.Copy();

            Assert.IsNotNull(result);
            Assert.IsFalse(Object.ReferenceEquals(matrix, result));

            Assert.AreEqual(matrix.RowDimension, result.RowDimension);
            Assert.AreEqual(matrix.ColumnDimension, result.ColumnDimension);

            for (UInt32 i = 0; i < matrix.RowDimension; i++)
            {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
                {
                    Assert.AreEqual(matrix[i, j], result[i, j]);
                }
            }
        }

        #endregion
    }
}