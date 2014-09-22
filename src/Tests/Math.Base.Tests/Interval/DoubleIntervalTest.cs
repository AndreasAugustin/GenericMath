//  *************************************************************
// <copyright file="DoubleIntervalTest.cs" company="${Company}">
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

    using NUnit.Framework;

    /// <summary>
    /// Test for intervalls with Double as underlying set.
    /// </summary>
    [TestFixture(typeof(DoubleMonoid))]
    [TestFixture(typeof(DoubleField))]
    [TestFixture(typeof(DoubleRing))]
    [TestFixture(typeof(DoubleEuclidianRing))]
    public class DoubleIntervalTest<TStructure> : IntervalTest<Double, TStructure>
        where TStructure : IStructure<Double>, new()
    {
        #region implemented abstract members of IntervalTest


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
        public override void Construct_RightParameter_IsNotNull(double minElement, double maxElement)
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
        public override void Construct_WrongParameter_ThrowsException(double minElement, double maxElement)
        {
            base.Construct_WrongParameter_ThrowsException(minElement, maxElement);
        }

        /// <summary>
        /// Determines whether this instance is in interval check value equals expected the specified minElement
        /// maxElement elementTocheck expected.
        /// </summary>
        /// <returns>true</returns>
        /// <c>false</c>
        /// <param name="minElement">Minimum element.</param>
        /// <param name="maxElement">Max element.</param>
        /// <param name="elementToCheck">Element tocheck.</param>
        /// <param name="elementToCheck">Element to check.</param>
        /// <param name="expected">If set to <c>true</c> expected.</param>
        [Category("IntervalTest")]
        [Test]
        [TestCaseSource("TestDataSource")]
        public override void IsInInterval_CheckValue_EqualsExpected(double minElement, double maxElement, 
                                                                    double elementToCheck, bool expected)
        {
            base.IsInInterval_CheckValue_EqualsExpected(minElement, maxElement, elementToCheck, expected);
        }

        #endregion
    }
}