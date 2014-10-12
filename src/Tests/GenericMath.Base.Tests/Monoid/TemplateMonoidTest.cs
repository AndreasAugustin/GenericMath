//  *************************************************************
// <copyright file="TemplateMonoidTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  17 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Template for the group tests.
    /// </summary>
    /// <typeparam name="T">The type parameter for the <see cref="IMonoid{T}"/> class.</typeparam>
    [TestFixture]
    public abstract class TemplateMonoidTest<T>
    {
        #region properties

        /// <summary>
        /// Gets the group.
        /// </summary>
        /// <value>The group.</value>
        protected abstract IMonoid<T> Monoid { get; }

        #endregion

        #region methods

        /// <summary>
        /// Tests the addition.
        /// </summary>
        /// <param name="leftInput">The left input.</param>
        /// <param name="rightInput">The right input.</param>
        /// <param name="expectedSum">The expected sum from left and right input.</param>
        [Test]
        [Category("MonoidTest")]
        public abstract void TestAddition(
            T leftInput,
            T rightInput,
            T expectedSum);

        /// <summary>
        /// Tests the addition method.
        /// Can be used as template for test method TestAddition with more input parameters from attribute.
        /// </summary>
        /// <param name="leftInput">The left input.</param>
        /// <param name="rightInput">The right input.</param>
        /// <param name="expectedSum">The expected sum from left and right input.</param>
        protected void TemplateTestAddition(
            T leftInput,
            T rightInput,
            T expectedSum)
        {
            var result = this.Monoid.Addition(leftInput, rightInput);

            Assert.AreEqual(expectedSum, result);
        }

        #endregion
    }
}