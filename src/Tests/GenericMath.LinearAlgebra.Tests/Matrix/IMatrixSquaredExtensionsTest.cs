//  *************************************************************
// <copyright file="IMatrixSquaredExtensionsTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  20 / 9 / 2014 Created the Class
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

        private IEnumerable<TestCaseData> GaussJordanSource
        {
            get
            {
                yield return new TestCaseData(
                    new Double(),
                    new DoubleField(),
                    this.MockDataSource.FieldDoubleSource2);
                yield return new TestCaseData(
                    new Double(),
                    new DoubleField(),
                    this.MockDataSource.FieldDoubleSource);
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

        /// <summary>
        /// Tests the GaussJordanAlgorithm method.
        /// </summary>
        /// <param name="hack1">Hack to get first generic parameter.</param>
        /// <param name="hack2">Hack to get second generic parameter.</param>
        /// <param name="matrix">The matrix.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TField">The underlying field.</typeparam>
        [Test]
        [Category("MatrixSquaredExtensionTest")]
        [TestCaseSource("GaussJordanSource")]
        [Ignore]
        public void GaussJordanAlgorithm_Run_IsNotNull<T, TField>(
            T hack1,
            TField hack2,
            IMatrix<T, TField> matrix)
            where T : IComparable
            where TField : IField<T>, new()
        {
            // TODO GaussJordanAlgorithm (TEST) the arithmetic in the calculation is not right
            // TODO GaussJordanAlgorithm (TEST) test needs to be written
            var resultList = matrix.GaussJordanAlgorithmWithSteps();

            Assert.IsNotNull(resultList);

            throw new ArithmeticException("The calculation is not correct yet");
            //// Check if the under triangle has zero values
        }

        #endregion
    }
}