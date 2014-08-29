//  *************************************************************
// <copyright file="TemplateRingTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  17 / 8 / 2014 Created the Class
// ************************************************************

namespace Math.Base.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Template ring test.
    /// </summary>
    /// <typeparam name="T">The type parameter</typeparam>
    [TestFixture]
    public abstract class TemplateRingTest<T>
    {
        #region properties

        /// <summary>
        /// Gets the ring.
        /// </summary>
        /// <value>The ring.</value>
        protected abstract IRing<T> Ring
        {
            get;
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the multiplication.
        /// </summary>
        /// <param name="leftInput">Left input.</param>
        /// <param name="rightInput">Right input.</param>
        /// <param name="expected">Expected solution.</param>
        [Test]
        [Category("RingTest")]
        public abstract void TestMultiplication(T leftInput, T rightInput, T expected);

        /// <summary>
        /// Templates for the test multiplication.
        /// </summary>
        /// <param name="leftInput">Left input.</param>
        /// <param name="rightInput">Right input.</param>
        /// <param name="expected">The expected value.</param>
        protected void TemplateTestMultiplication(T leftInput, T rightInput, T expected)
        {
            Assert.AreEqual(expected, Ring.Multiplication(leftInput, rightInput));
        }

        #endregion
    }
}