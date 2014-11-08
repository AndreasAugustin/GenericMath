//  *************************************************************
// <copyright file="IFieldExtensionsTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Analysis.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using GenericMath.Analysis;
    using GenericMath.Base;
    using NUnit.Framework;

    /// <summary>
    /// Test methods for the <see cref="IFieldExtensions"/> class.
    /// </summary>
    [TestFixture]
    public class IFieldExtensionsTest
    {
        #region properties

        private IEnumerable<TestCaseData> InverseFunctionSource
        {
            get
            {
                yield return new TestCaseData(
                    1.0,
                    new DoubleField(),
                    1.0 / 1.0);
                yield return new TestCaseData(
                    new Complex(3.0, 4.0),
                    new ComplexField(),
                    Complex.Reciprocal(new Complex(
                            3.0,
                            4.0)));
            }
        }

        private IEnumerable<TestCaseData> InverseFunctionWithFuncSource
        {
            get
            {
                // Parameter function is (x) => field.Pow(field.Addition(x, field.One), 2)
                yield return new TestCaseData(
                    1.0,
                    new DoubleField(),
                    1.0 / 4.0);
                yield return new TestCaseData(
                    new Complex(3.0, 0.0),
                    new ComplexField(),
                    Complex.Reciprocal(new Complex(
                            16.0,
                            0.0)));
            }
        }

        private IEnumerable<TestCaseData> InverseFunctionExceptionSource
        {
            get
            {
                yield return new TestCaseData(0.0, new DoubleField());
                yield return new TestCaseData(Complex.Zero, new ComplexField());
            }
        }

        private IEnumerable<TestCaseData> InverseFunctionWithFuncExceptionSource
        {
            get
            {
                // Parameter function is (x) => field.Pow(field.Addition(x, field.One), 2)
                yield return new TestCaseData(-1.0, new DoubleField());
                yield return new TestCaseData(
                    new Complex(-1.0, 0.0),
                    new ComplexField());
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the MultiplicationInverseFunction.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="field">The field.</param>
        /// <param name="expected">The expected value.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        [Category("IFieldExtensionsTest")]
        [Test]
        [TestCaseSource("InverseFunctionSource")]
        public void MultiplicationInverseFunction_CalculateAtPoint_EqualsExpectedPoint<T>(
            T point,
            IField<T> field,
            T expected)
        {
            Func<T, T> result = field.MultiplicationInverseFunction();
            Assert.IsNotNull(result);

            var calculated = result(point);

            Assert.AreEqual(expected, calculated);
        }

        /// <summary>
        /// Tests the MultiplicationInverseMethod.
        /// </summary>
        /// <param name="zero">The zero.</param>
        /// <param name="field">The field.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        [Category("IFieldExtensionsTest")]
        [Test]
        [TestCaseSource("InverseFunctionExceptionSource")]
        public void MultiplicationInverseFunction_CalculateAtZero_ThrowsException<T>(
            T zero,
            IField<T> field)
        {
            Func<T, T> result = field.MultiplicationInverseFunction();
            Assert.IsNotNull(result);

            Assert.Throws<DivideByZeroException>(() => result(zero));
        }

        /// <summary>
        /// Tests the MultiplicationInverseFunctionWithFunction method.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="field">The field.</param>
        /// <param name="expected">The expected value.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        [Category("IFieldExtensionsTest")]
        [Test]
        [TestCaseSource("InverseFunctionWithFuncSource")]
        public void MultiplicationInverseFunctionWithFunc_CalculateAtPoint_EqualsExpectedPoint<T>(
            T point,
            IField<T> field,
            T expected)
        {
            Func<T, T> func = (x) => field.Pow(field.Addition(x, field.One), 2);
            Func<T, T> result = field.MultiplicationInverseFunction(func);
            Assert.IsNotNull(result);

            var calculated = result(point);

            Assert.AreEqual(expected, calculated);
        }

        /// <summary>
        /// Tests the MultiplicationInverseFunctionWithFunction.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="field">The field.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        [Category("IFieldExtensionsTest")]
        [Test]
        [TestCaseSource("InverseFunctionWithFuncExceptionSource")]
        public void MultiplicationInverseFunctionWithFunc_CalculateAtPointFuncIsZero_ThrowsException<T>(
            T point,
            IField<T> field)
        {
            Func<T, T> func = (x) => field.Pow(field.Addition(x, field.One), 2);
            Func<T, T> result = field.MultiplicationInverseFunction(func);
            Assert.IsNotNull(result);

            Assert.Throws<DivideByZeroException>(() => result(point));
        }

        #endregion
    }
}