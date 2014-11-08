//  *************************************************************
// <copyright file="IMatrixSquaredExtensionsTest.cs" company="None">
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
    /// Tests for the extension methods for squared matrices.
    /// </summary>
    [TestFixture]
    public class IMatrixSquaredExtensionsTest
    {
        #region fields

        private FakeMatrixSquaredTestDataSource _mockDataSource;

        #endregion

        #region properties

        private FakeMatrixSquaredTestDataSource MockDataSource
        {
            get
            {
                return this._mockDataSource ?? (this._mockDataSource = new FakeMatrixSquaredTestDataSource());
            }
        }

        private IEnumerable<TestCaseData> TraceSource
        {
            get
            {
                yield return new TestCaseData(
                    new Double(),
                    new DoubleField(),
                    this.MockDataSource.FieldDoubleSource,
                    this.MockDataSource.DoubleList);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the trace method.
        /// </summary>
        /// <param name="hack1">The first hack1.</param>
        /// <param name="hack2">The second hack2.</param>
        /// <param name="matrix">The matrix.</param>
        /// <param name="underlyingList">Underlying list for the matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TMonoid">The underlying monoid.</typeparam>
        [Category("MatrixSquaredExtensionsTest")]
        [Test]
        [TestCaseSource("TraceSource")]
        public void Trace_CalculatrTrace_EqualsExpected<T, TMonoid>(
            T hack1,
            TMonoid hack2,
            IMatrix<T, TMonoid> matrix,
            List<List<T>> underlyingList)
            where TMonoid : IMonoid<T>, new()
        {
            var result = matrix.Trace();
            Assert.IsNotNull(result);

            var monoid = new TMonoid();

            var expected = monoid.Zero;

            for (Int32 i = 0; i < underlyingList.Count; i++)
            {
                expected = monoid.Addition(expected, underlyingList[i][i]);
            }

            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}