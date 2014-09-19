//  *************************************************************
// <copyright file="IGroupExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  11 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Analysis.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NSubstitute;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the IGroupExtensions
    /// </summary>
    [TestFixture]
    public class IGroupExtensionsTest
    {
        #region properties

        static IEnumerable<TestCaseData> AdditionOfTwoAdditonFunctionsSource
        {
            get
            {
                yield return new TestCaseData(2, 3, 10, new Int32Group());
                yield return new TestCaseData(2.0, 3.5, 11.0, new DoubleGroup());
                yield return new TestCaseData(new Complex(2, 4), new Complex(4, 2), new Complex(12, 12), new ComplexGroup());
            }
        }

        static IEnumerable<TestCaseData> AdditionLeftMultiplicationFunctionRightAdditionFunctionFunctionSource
        {
            get
            {
                yield return new TestCaseData(2, 3, 11, new Int32Ring());
                yield return new TestCaseData(1.0, 3.5, 8.0, new DoubleRing());
                yield return new TestCaseData(new Complex(1, 0), new Complex(0, 1), new Complex(1, 2), new ComplexRing());
            }
        }

        static IEnumerable<TestCaseData> GroupsWithElements
        {
            get
            {
                yield return new TestCaseData(5, new Int32Group());
                yield return new TestCaseData(4.5, new DoubleGroup());
                yield return new TestCaseData(new Complex(123, 34), new ComplexGroup());
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Test the addition of two functions.
        /// </summary>
        /// <param name="value1">the second value.</param>
        /// <param name="value2">The first value.</param>
        /// <param name="expectedResult">The expected result.</param>
        /// <param name="group">The group.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        [Test]
        [TestCaseSource("AdditionOfTwoAdditonFunctionsSource")]
        public void Addition_OfTwoAdditionFunctions_PointsAreEqual<T>(T value1, T value2, T expectedResult, IGroup<T> group)
        {
            Func<T, T, T> func1 = group.Addition;
            Func<T, T, T> func2 = group.Addition;

            var calc = group.Addition(func1, func2);

            Assert.NotNull(calc);
            Assert.AreEqual(expectedResult, calc(value1, value2));
        }

        /// <summary>
        /// Additions the left argument multiplication function.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value2.</param>
        /// <param name="expectedResult">Expected result.</param>
        /// <param name="ring">The ring.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        [Test]
        [TestCaseSource("AdditionLeftMultiplicationFunctionRightAdditionFunctionFunctionSource")]
        public void Addition_LeftMultiplicationFunctionRightAdditionFunction_PointsAreEqual<T>(T value1, T value2, T expectedResult, IRing<T> ring)
        {
            Func<T, T, T> func1 = ring.Addition; 
            Func<T, T, T> func2 = ring.Multiplication;

            var calc = ring.Addition(func1, func2);

            Assert.NotNull(calc);
            Assert.AreEqual(expectedResult, calc(value1, value2));
        }

        /// <summary>
        /// Zeros the function equals mock.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="group">The group.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        [Test]
        [TestCaseSource("GroupsWithElements")]
        public void ZeroFunction_PointsEqualsMock<T>(T value, IGroup<T> group)
        {
            Func<T, T> functionMock = Substitute.For<Func<T, T>>();
            functionMock(value).Returns(value);

            var testFunction = group.Addition(group.ZeroFunction(), functionMock);

            Assert.AreEqual(functionMock(value), testFunction(value));
        }

        /// <summary>
        /// Inverses the function add with function points equals mock.
        /// </summary>
        /// <param name="value">the value.</param>
        /// <param name="group">The group.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        [Test]
        [TestCaseSource("GroupsWithElements")]
        public void InverseFunction_AddWithFunction_PointsEqualsMock<T>(T value, IGroup<T> group)
        {
            Func<T, T> functionMock = Substitute.For<Func<T, T>>();
            functionMock(value).Returns(value);

            var inverseFunction = group.InverseFunction(functionMock);

            var testFunction = group.Addition(inverseFunction, functionMock);

            Assert.AreEqual(group.Zero, testFunction(value));
        }

        #endregion
    }
}