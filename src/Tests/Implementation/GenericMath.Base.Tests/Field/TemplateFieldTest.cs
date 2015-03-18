//  *************************************************************
// <copyright file="TemplateFieldTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base.Tests
{
    using System.Collections.Generic;
    using System.Numerics;
    using GenericMath.Base.Contracts;

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
        protected abstract IField<T> Field { get; }

        #endregion

        #region methods

        /// <summary>
        /// Tests the multiplication inverse.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="expected">Expected solution.</param>
        [Test]
        [Category("FieldTest")]
        public abstract void TestMultiplicationInverse (T input, T expected);

        /// <summary>
        /// Templates for the test multiplication inverse.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="expected">The expected value.</param>
        protected void TemplateTestMultiplicationInverse (T input, T expected)
        {
            var result = this.Field.MultiplicationInverse(input);
            if (typeof(T) == typeof(Complex)) {
                Assert.That(expected, Is.EqualTo(result).Using(new ComplexComparer()));
            } else {
                Assert.That(expected, Is.EqualTo(result));
            }
        }

        #endregion
    }

    /// <summary>
    /// Comparer for complex numbers
    /// </summary>
    internal class ComplexComparer : IComparer<Complex>
    {
        #region IComparer implementation

        /// <summary>
        /// Compare the specified x and y.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public int Compare (Complex x, Complex y)
        {
            const double epsilon = 0.000001;

            if (System.Math.Abs(x.Real - y.Real) > epsilon) {
                return -1;
            }
            if (System.Math.Abs(x.Imaginary - y.Imaginary) > epsilon) {
                return -1;
            }

            return 0;
        }

        #endregion


    }
}