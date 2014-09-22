//  *************************************************************
// <copyright file="IGroupExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 9 / 2014 Created the Class
// *************************************************************
namespace Math.Analysis.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Analysis;
    using Math.Base;
    using NSubstitute;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="IGroupExtensions"/> class.
    /// </summary>
    [TestFixture]
    public class IGroupExtensionsTest
    {
        #region properties

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
    }
}