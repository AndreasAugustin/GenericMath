//  *************************************************************
// <copyright file="IMatrixExtensionsTest.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
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
    /// Tests for the extensions methods of IMatrix.
    /// </summary>
    [TestFixture]
    public class IMatrixExtensionsTest
    {
        #region fields

        private FakeMatrixTestDataSource _mockTestDataSource;

        #endregion

        #region properties

        private FakeMatrixTestDataSource MockTestDataSource
        {
            get
            {
                return this._mockTestDataSource ?? (this._mockTestDataSource = new FakeMatrixTestDataSource());
            }
        }

        private IEnumerable<TestCaseData> GetVectorDataSource
        {
            get
            {
                yield return new TestCaseData(
                    default(Int32),
                    new Int32Group(),
                    (UInt32)0,
                    this.MockTestDataSource.GroupInt32Source,
                    this.MockTestDataSource.Int32List);
                yield return new TestCaseData(
                    default(Double),
                    new DoubleField(),
                    (UInt32)0,
                    this.MockTestDataSource.FieldDoubleSource,
                    this.MockTestDataSource.DoubleList);
                yield return new TestCaseData(
                    default(Complex),
                    new ComplexRing(),
                    (UInt32)0,
                    this.MockTestDataSource.RingComplexSource,
                    this.MockTestDataSource.ComplexList);
            }
        }

        private IEnumerable<TestCaseData> TransposeDataSource
        {
            get
            {
                yield return new TestCaseData(
                    default(Int32),
                    new Int32Group(),
                    this.MockTestDataSource.GroupInt32Source);
                yield return new TestCaseData(
                    default(Double),
                    new DoubleField(),
                    this.MockTestDataSource.FieldDoubleSource);
                yield return new TestCaseData(
                    default(Complex),
                    new ComplexRing(),
                    this.MockTestDataSource.RingComplexSource);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Gets the column vector check result with expected equals expected.
        /// </summary>
        /// <param name="hack1">Hack for generic parameter.</param>
        /// <param name="hack2">Hack for generic structure.</param>
        /// <param name ="columnIndex">The column index.</param>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The the underlying structure.</typeparam>
        /// <param name = "underlyingList">The underlying list for the matrix</param>
        [Category("MatrixExtensionTest")]
        [Test]
        [TestCaseSource("GetVectorDataSource")]
        public void GetColumnVector_CheckResultWithExpected_EqualsExpected<T, TStruct>(
            T hack1,
            TStruct hack2, 
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

        /// <summary>
        /// Gets the row vector check result with expected equals expected.
        /// </summary>
        /// <param name="hack1">The first Hack1.</param>
        /// <param name="hack2">The second Hack2.</param>
        /// <param name="rowIndex">Row index.</param>
        /// <param name="matrix">The matrix.</param>
        /// <param name="underlyingList">Underlying list for the matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        [Category("MatrixExtensionTest")]
        [Test]
        [TestCaseSource("GetVectorDataSource")]
        public void GetRowVector_CheckResultWithExpected_EqualsExpected<T, TStruct>(
            T hack1,
            TStruct hack2, 
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
        /// <param name="hack1">The first Hack1.</param>
        /// <param name="hack2">The second Hack2.</param>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        [Category("MatrixExtensionTest")]
        [Test]
        [TestCaseSource("TransposeDataSource")]
        public void Transpose_CheckResultWithGivenParameter_EqualsExpected<T, TStruct>(
            T hack1,
            TStruct hack2, 
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
        /// <param name="hack1">The frist Hack1.</param>
        /// <param name="hack2">The second Hack2.</param>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        [Category("MatrixExtensionTest")]
        [Test]
        [TestCaseSource("TransposeDataSource")]
        public void Copy_CheckResultWithGivenParameter_EqualsExpected<T, TStruct>(
            T hack1,
            TStruct hack2, 
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