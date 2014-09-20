//  *************************************************************
// <copyright file="IMatrixSquaredExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  20 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the extension methods for squared matrices.
    /// </summary>
    [TestFixture]
    public class IMatrixSquaredExtensionsTest
    {
        #region fields

        FakeMatrixSquaredTestDataSource _mockDataSource;

        #endregion

        #region properties

        FakeMatrixSquaredTestDataSource MockDataSource
        {
            get
            {
                return _mockDataSource ?? (_mockDataSource = new FakeMatrixSquaredTestDataSource());
            }
        }

        IEnumerable<TestCaseData> GaussJordanSource
        {
            get
            {
                yield return new TestCaseData(new Double(), new DoubleField(), MockDataSource.FieldDoubleSource2);
                yield return new TestCaseData(new Double(), new DoubleField(), MockDataSource.FieldDoubleSource);
            }
        }

        IEnumerable<TestCaseData> TraceSource
        {
            get
            {
                yield return new TestCaseData(new Double(), new DoubleField(), MockDataSource.FieldDoubleSource, MockDataSource.DoubleList);
            }
        }

        #endregion

        #region methods

        [Category("MatrixSquaredExtensionsTest")]
        [Test]
        [TestCaseSource("TraceSource")]
        public void Trace_CalculatrTrace_EqualsExpected<T, TMonoid>(T hack1, TMonoid hack2, IMatrix<T, TMonoid> matrix, List<List<T>> underlyingList)
            where TMonoid : IMonoid<T>, new()
        {
            var result = matrix.Trace();
            Assert.IsNotNull(result);

            var monoid = new TMonoid();

            var expected = monoid.Zero;

            for (Int32 i = 0; i < underlyingList.Count; i++)
            {
                expected = monoid.Addition(expected, (underlyingList[i])[i]);
            }

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Gauses the jordan algorithm run is not null.
        /// </summary>
        /// <param name="hack1">Hack to get generic parameter.</param>
        /// <param name="hack2">Hack to get generic parameter.</param>
        /// <param name="matrix">Matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TField">The 2nd type parameter.</typeparam>
        [Test]
        [Category("MatrixSquaredExtensionTest")]
        [TestCaseSource("GaussJordanSource")]
        public void GausJordanAlgorithm_Run_IsNotNull<T, TField>(T hack1, TField hack2, IMatrix<T, TField> matrix)
            where T : IComparable
            where TField : IField<T>, new()
        {
            var resultList = matrix.GaussJordanAlgorithmWithSteps();

            Assert.IsNotNull(resultList);

            throw new ArithmeticException("The calculation is not correct yet");
            // Check if the under triangle has zero values
        }

        #endregion
    }
}