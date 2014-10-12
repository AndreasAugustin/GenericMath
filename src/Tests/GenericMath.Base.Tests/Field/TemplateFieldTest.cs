//  *************************************************************
// <copyright file="TemplateFieldTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  17 / 8 / 2014 Created the Class
// ************************************************************

namespace GenericMath.Base.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Template ring test.
    /// </summary>
    /// <typeparam name="T">The type parameter</typeparam>
    [TestFixture]
    public abstract class TemplateFieldTest<T>
    {
        #region properties

        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <value>The field.</value>
        protected abstract IField<T> Field
        {
            get;
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the multiplication inverse.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="expected">Expected solution.</param>
        [Test]
        [Category("FieldTest")]
        public abstract void TestMultiplicationInverse(T input, T expected);

        /// <summary>
        /// Templates for the test multiplication inverse.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="expected">The expected value.</param>
        protected void TemplateTestMultiplicationInverse(T input, T expected)
        {
            var result = this.Field.MultiplicationInverse(input);
            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}