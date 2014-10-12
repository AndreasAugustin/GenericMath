//  *************************************************************
// <copyright file="IMatrixFromMonoidExtensionsTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  19 / 9 / 2014 Created the Class
// *************************************************************

namespace GenericMath.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using GenericMath.Base;
    using NUnit.Framework;

    /// <summary>
    /// Test methods for the extension methods for the IMatrix.
    /// </summary>
    [TestFixture]
    public class IMatrixFromMonoidExtensionsTest
    {
        #region fields

        private FakeMatrixTestDataSource _mockDataSource;

        #endregion

        #region properties

        private FakeMatrixTestDataSource MockDataSource
        {
            get
            {
                return this._mockDataSource ?? (this._mockDataSource = new FakeMatrixTestDataSource());
            }
        }

        private IEnumerable<TestCaseData> AddDataSource
        {
            get
            {
                yield return new TestCaseData(
                    default(Int32),
                    new Int32Group(),
                    this.MockDataSource.GroupInt32Source,
                    this.MockDataSource.Int32List);
                yield return new TestCaseData(
                    default(Double),
                    new DoubleField(),
                    this.MockDataSource.FieldDoubleSource,
                    this.MockDataSource.DoubleList);
                yield return new TestCaseData(
                    default(Complex),
                    new ComplexRing(),
                    this.MockDataSource.RingComplexSource,
                    this.MockDataSource.ComplexList);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the Add method.
        /// </summary>
        /// <param name="hack1">The first Hack1.</param>
        /// <param name="hack2">The second Hack2.</param>
        /// <param name="matrix">The matrix.</param>
        /// <param name="underlyingList">Underlying list.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TMonoid">The underlying monoid.</typeparam>
        [Category("MatrixFromMonoidExtensionTest")]
        [Test]
        [TestCaseSource("AddDataSource")]
        public void Add_CheckResultWithExpected_EqualsExpected<T, TMonoid>(
            T hack1,
            TMonoid hack2, 
            IMatrix<T, TMonoid> matrix, 
            List<List<T>> underlyingList)
            where TMonoid : IGroup<T>, new()
        {
            var result = matrix.Add(matrix);

            Assert.IsNotNull(result);
            Assert.IsFalse(Object.ReferenceEquals(matrix, result));

            Assert.AreEqual(matrix.RowDimension, result.RowDimension);
            Assert.AreEqual(matrix.ColumnDimension, matrix.ColumnDimension);

            var group = new TMonoid();

            for (Int32 i = 0; i < matrix.RowDimension; i++)
            {
                for (Int32 j = 0; j < matrix.ColumnDimension; j++)
                {
                    var expected = group.Addition(
                                       underlyingList[i][j],
                                       underlyingList[i][j]);
                    Assert.AreEqual(expected, result[(UInt32)i, (UInt32)j]);
                }
            }
        }

        #endregion
    }
}