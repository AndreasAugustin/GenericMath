//  *************************************************************
// <copyright file="IntervalTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.Base.Tests
{
    using System;
    using System.Collections.Generic;

    using NSubstitute;
    using NUnit.Framework;

    /// <summary>
    /// Test methods for the <see cref="Interval{T, TStruct}"/>class.
    /// </summary>
    [TestFixture]
    public abstract class IntervalTest<T, TStruct>
        where T : IComparable
        where TStruct : IStructure<T>, new()
    {
        #region properties

        /// <summary>
        /// Gets the construct test data source.
        /// </summary>
        /// <value>The construct test data source.</value>
        protected abstract IEnumerable<TestCaseData> ConstructTestDataSource
        {
            get;
        }

        /// <summary>
        /// Gets the construct throws test data source.
        /// </summary>
        /// <value>The construct throws test data source.</value>
        protected abstract IEnumerable<TestCaseData> ConstructThrowsTestDataSource
        {
            get;
        }

        /// <summary>
        /// Gets the test data source.
        /// </summary>
        /// <value>The test data source.</value>
        protected abstract IEnumerable<TestCaseData> TestDataSource
        {
            get;
        }

        #endregion

        #region methods

        /// <summary>
        /// Constructs the right parameter is not null.
        /// </summary>
        /// <param name="minElement">Minimum element.</param>
        /// <param name="maxElement">Max element.</param>
        [Category("IntervalTest")]
        [Test]
        [TestCaseSource("ConstructTestDataSource")]
        public virtual void Construct_RightParameter_IsNotNull(T minElement, T maxElement)
        {
            var interval = new Interval<T, TStruct>(minElement, maxElement);
            Assert.IsNotNull(interval);
        }

        /// <summary>
        /// Constructs the wrong parameter throws exception.
        /// </summary>
        /// <param name="minElement">Minimum element.</param>
        /// <param name="maxElement">Max element.</param>
        [Category("IntervalTest")]
        [Test]
        [TestCaseSource("ConstructThrowsTestDataSource")]
        public virtual void Construct_WrongParameter_ThrowsException(T minElement, T maxElement)
        {
            Assert.Throws<AccessViolationException>(() => new Interval<T, TStruct>(minElement, maxElement));
        }

        /// <summary>
        /// Determines whether this instance is in interval check value equals expected the specified minElement
        /// maxElement elementTocheck expected.
        /// </summary>
        /// <returns><c>true</c> if this instance is in interval check value equals expected the specified minElement maxElement
        /// elementTocheck expected; otherwise, <c>false</c>.</returns>
        /// <param name="minElement">Minimum element.</param>
        /// <param name="maxElement">Max element.</param>
        /// <param name="elementToCheck">Element tocheck.</param>
        /// <param name="expected">If set to <c>true</c> expected.</param>
        [Category("IntervalTest")]
        [Test]
        [TestCaseSource("TestDataSource")]
        public virtual void IsInInterval_CheckValue_EqualsExpected(T minElement, T maxElement, T elementToCheck, Boolean expected)
        {
            var interval = new Interval<T, TStruct>(minElement, maxElement);
            var result = interval.IsinInterval(elementToCheck);

            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}