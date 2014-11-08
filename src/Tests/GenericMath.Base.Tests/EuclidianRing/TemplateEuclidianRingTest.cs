//  *************************************************************
// <copyright file="TemplateEuclidianRingTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Template for euclidian ring tests.
    /// </summary>
    /// <typeparam name="T">The type parameter.</typeparam>
    [TestFixture]
    public abstract class TemplateEuclidianRingTest<T>
    {
        #region properties

        /// <summary>
        /// Gets the ring.
        /// </summary>
        /// <value>The ring.</value>
        protected abstract IEuclidianRing<T> EuclidianRing
        {
            get;
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the euclidian norm.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="expected">Expected solution.</param>
        [Test]
        [Category("EuclidianRingTest")]
        public abstract void TestEuclidianNorm(T input, Double expected);

        /// <summary>
        /// Templates for the test multiplication.
        /// </summary>
        /// <param name="input">Left input.</param>
        /// <param name="expected">The expected value.</param>
        protected void TemplateTestEuclidianNorm(T input, Double expected)
        {
            var result = this.EuclidianRing.Norm(input);
            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}