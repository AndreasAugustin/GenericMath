//  *************************************************************
// <copyright file="IMatrixFromGroupExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  19 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    [TestFixture]
    public class IMatrixFromGroupExtensionsTest
    {
        #region fields

        FakeMatrixTestDataSource _mockDataSource;

        #endregion

        #region properties

        FakeMatrixTestDataSource MockDataSource
        {
            get
            {
                return _mockDataSource ?? (_mockDataSource = new FakeMatrixTestDataSource());
            }
        }

        IEnumerable<TestCaseData> InverseDataSource
        {
            get
            {
                yield return new TestCaseData(default(Int32), new Int32Group(), MockDataSource.GroupInt32Source);
                yield return new TestCaseData(default(Double), new DoubleField(), MockDataSource.FieldDoubleSource);
                yield return new TestCaseData(default(Complex), new ComplexRing(), MockDataSource.RingComplexSource);
            }
        }

        #endregion

        #region methods

        [Category("MatrixFromGroupExtensionTest")]
        [Test]
        [TestCaseSource("InverseDataSource")]
        public void Inverse_CheckResultWithExpected_EqualsElementalInverse<T, TGroup>(T hack1, TGroup hack2, 
                                                                                      IMatrix<T, TGroup> matrix)
            where TGroup : IGroup<T>, new()
        {
            var result = matrix.Inverse();

            Assert.IsNotNull(result);
            Assert.IsFalse(Object.ReferenceEquals(matrix, result));

            Assert.AreEqual(matrix.RowDimension, result.RowDimension);
            Assert.AreEqual(matrix.ColumnDimension, matrix.ColumnDimension);

            var group = new TGroup();

            for (UInt32 i = 0; i < matrix.RowDimension; i++)
            {
                for (UInt32 j = 0; j < matrix.ColumnDimension; j++)
                {
                    var expected = group.Inverse(matrix[i, j]);
                    Assert.AreEqual(expected, result[i, j]);
                }
            }
        }

        #endregion
    }
}