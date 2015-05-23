//  *************************************************************
// <copyright file="IMatrixExtensionsTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;
using GenericMath.LinearAlgebra.Contracts;

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
    public class MatrixExtensionsTest
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
        public void Transpose_CheckResultWithGivenParameter_EqualsExpected<T, TStruct> (
            T hack1,
            TStruct hack2, 
            IMatrix<T, TStruct> matrix)
            where TStruct : IStructure, new()
        {
            var result = matrix.Transpose();

            Assert.IsNotNull(result);

            Assert.AreEqual(matrix.RowDimension, result.ColumnDimension);
            Assert.AreEqual(matrix.ColumnDimension, result.RowDimension);

            for (UInt32 i = 0; i < matrix.RowDimension; i++) {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++) {
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
        public void Copy_CheckResultWithGivenParameter_EqualsExpected<T, TStruct> (
            T hack1,
            TStruct hack2, 
            IMatrix<T, TStruct> matrix)
            where TStruct : IStructure, new()
        {
            var result = matrix.Copy();

            Assert.IsNotNull(result);
            Assert.IsFalse(Object.ReferenceEquals(matrix, result));

            Assert.AreEqual(matrix.RowDimension, result.RowDimension);
            Assert.AreEqual(matrix.ColumnDimension, result.ColumnDimension);

            for (UInt32 i = 0; i < matrix.RowDimension; i++) {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++) {
                    Assert.AreEqual(matrix[i, j], result[i, j]);
                }
            }
        }

        /// <summary>
        /// Tests the matrix swap rows extension method.
        /// </summary>
        /// <param name="hack1">The frist Hack1.</param>
        /// <param name="hack2">The second Hack2.</param>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        [Category("MatrixExtensionTest")]
        [Test]
        [TestCaseSource("TransposeDataSource")]
        public void SwapRows_CheckResultWithGivenParameter_EqualsExpected<T, TStruct> (
            T hack1,
            TStruct hack2, 
            IMatrix<T, TStruct> matrix)
            where TStruct : IStructure, new()
        {
            const UInt32 FirstRowIndex = 0;
            const UInt32 SecondRowIndex = 1;
            var result = matrix.SwapRows(FirstRowIndex, SecondRowIndex);

            Assert.IsNotNull(result);
            Assert.IsFalse(Object.ReferenceEquals(matrix, result));

            Assert.AreEqual(matrix.RowDimension, result.RowDimension);
            Assert.AreEqual(matrix.ColumnDimension, result.ColumnDimension);

            for (UInt32 i = 0; i < matrix.RowDimension; i++) {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++) {
                    if (i != FirstRowIndex && i != SecondRowIndex) {
                        Assert.AreEqual(matrix[i, j], result[i, j]);
                    }

                    if (i == FirstRowIndex) {
                        Assert.AreEqual(matrix[SecondRowIndex, j], result[i, j]);
                    }

                    if (i == SecondRowIndex) {
                        Assert.AreEqual(matrix[FirstRowIndex, j], result[i, j]);
                    }
                }
            }
        }

        /// <summary>
        /// Tests the matrix swap columns extension method.
        /// </summary>
        /// <param name="hack1">The frist Hack1.</param>
        /// <param name="hack2">The second Hack2.</param>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure.</typeparam>
        [Category("MatrixExtensionTest")]
        [Test]
        [TestCaseSource("TransposeDataSource")]
        public void SwapColumns_CheckResultWithGivenParameter_EqualsExpected<T, TStruct> (
            T hack1,
            TStruct hack2, 
            IMatrix<T, TStruct> matrix)
            where TStruct : IStructure, new()
        {
            const UInt32 FirstColumnIndex = 0;
            const UInt32 SecondColumnIndex = 1;
            var result = matrix.SwapColumns(FirstColumnIndex, SecondColumnIndex);

            Assert.IsNotNull(result);
            Assert.IsFalse(Object.ReferenceEquals(matrix, result));

            Assert.AreEqual(matrix.RowDimension, result.RowDimension);
            Assert.AreEqual(matrix.ColumnDimension, result.ColumnDimension);

            for (UInt32 i = 0; i < matrix.RowDimension; i++) {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++) {
                    if (i != FirstColumnIndex && i != SecondColumnIndex) {
                        Assert.AreEqual(matrix[i, j], result[i, j]);
                    }

                    if (i == FirstColumnIndex) {
                        Assert.AreEqual(matrix[SecondColumnIndex, j], result[i, j]);
                    }

                    if (i == SecondColumnIndex) {
                        Assert.AreEqual(matrix[FirstColumnIndex, j], result[i, j]);
                    }
                }
            }
        }

        #endregion
    }
}