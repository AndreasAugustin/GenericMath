//  *************************************************************
// <copyright file="DoubleIntervalTest.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    /// <summary>
    /// Test for double intervals.
    /// </summary>
    /// <typeparam name="TStructure">The underlying structure.</typeparam>
    [TestFixture(typeof(DoubleMonoid))]
    [TestFixture(typeof(DoubleField))]
    [TestFixture(typeof(DoubleRing))]
    [TestFixture(typeof(DoubleEuclidianRing))]
    public class DoubleIntervalTest<TStructure> : IntervalTest<Double, TStructure>
        where TStructure : IStructure<Double>, new()
    {
        #region implemented abstract members of IntervalTest

        /// <summary>
        /// Gets the test data source.
        /// </summary>
        /// <value>The test data source.</value>
        protected override IEnumerable<TestCaseData> TestDataSource
        {
            get
            {
                // Min element, max element, element to check, expected
                yield return new TestCaseData(1.0, 2.0, 1.0, true);
                yield return new TestCaseData(-2.0, 3.0, 10.0, false);
            }
        }

        /// <summary>
        /// Gets the construct test data source.
        /// </summary>
        /// <value>The construct test data source.</value>
        protected override IEnumerable<TestCaseData> ConstructTestDataSource
        {
            get
            {
                yield return new TestCaseData(1.0, 2.0);
                yield return new TestCaseData(-2.0, 3.0);
            }
        }

        /// <summary>
        /// Gets the construct throws test data source.
        /// </summary>
        /// <value>The construct throws test data source.</value>
        protected override IEnumerable<TestCaseData> ConstructThrowsTestDataSource
        {
            get
            {
                yield return new TestCaseData(3.0, -1.0);
            }
        }

        #endregion

        #region overrides of INTERVALTEST

        /// <summary>
        /// Constructs the right parameter is not null.
        /// </summary>
        /// <param name="minElement">Minimum element.</param>
        /// <param name="maxElement">Max element.</param>
        [Category("IntervalTest")]
        [Test]
        [TestCaseSource("ConstructTestDataSource")]
        public override void Construct_RightParameter_IsNotNull(
            Double minElement,
            Double maxElement)
        {
            base.Construct_RightParameter_IsNotNull(minElement, maxElement);
        }

        /// <summary>
        /// Constructs the wrong parameter throws exception.
        /// </summary>
        /// <param name="minElement">Minimum element.</param>
        /// <param name="maxElement">Max element.</param>
        [Category("IntervalTest")]
        [Test]
        [TestCaseSource("ConstructThrowsTestDataSource")]
        public override void Construct_WrongParameter_ThrowsException(
            Double minElement,
            Double maxElement)
        {
            base.Construct_WrongParameter_ThrowsException(
                minElement,
                maxElement);
        }

        /// <summary>
        /// Determines whether this instance is in interval check value equals expected the specified minElement
        /// maxElement equals expected.
        /// </summary>
        /// <param name="minElement">Minimum element.</param>
        /// <param name="maxElement">Max element.</param>
        /// <param name="elementToCheck">Element to check.</param>
        /// <param name="expected">If set to <c>true</c> expected.</param>
        [Category("IntervalTest")]
        [Test]
        [TestCaseSource("TestDataSource")]
        public override void IsInInterval_CheckValue_EqualsExpected(
            Double minElement,
            Double maxElement, 
            Double elementToCheck,
            Boolean expected)
        {
            base.IsInInterval_CheckValue_EqualsExpected(
                minElement,
                maxElement,
                elementToCheck,
                expected);
        }

        #endregion
    }
}