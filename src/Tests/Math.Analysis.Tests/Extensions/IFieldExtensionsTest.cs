//  *************************************************************
// <copyright file="IFieldExtensionsTest.cs" company="${Company}">
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
    /// Test methods for the <see cref="IFieldExtensions"/> class.
    /// </summary>
    [TestFixture]
    public class IFieldExtensionsTest
    {
        #region properties

        IEnumerable<TestCaseData> InverseFunctionSource
        {
            get
            {
                yield return new TestCaseData(1.0, new DoubleField(), 1.0 / 1.0);
                yield return new TestCaseData(new Complex(3.0, 4.0), new ComplexField(), Complex.One / new Complex(3.0, 4.0));
            }
        }

        IEnumerable<TestCaseData> InverseFunctionExceptionSource
        {
            get
            {
                yield return new TestCaseData(0.0, new DoubleField());
                yield return new TestCaseData(Complex.Zero, new ComplexField());
            }
        }

        #endregion

        #region methods

        [Category("IFieldExtensionsTest")]
        [Test]
        [TestCaseSource("InverseFunctionSource")]
        public void MultiplicationInverseFunction_CalculateAtPoint_EqualsExpectedPoint<T>(T point, IField<T> field, T expeced)
        {
            Func<T, T> result = field.MultiplicationInverseFunction();
            Assert.IsNotNull(result);

            var calculated = result(point);

            Assert.AreEqual(expeced, calculated);
        }

        [Category("IFieldExtensionsTest")]
        [Test]
        [TestCaseSource("InverseFunctionExceptionSource")]
        public void MultiplicationInverseFunction_CalculateAtZero_ThrowsException<T>(T zero, IField<T> field)
        {
            Func<T,T> result = field.MultiplicationInverseFunction();
            Assert.IsNotNull(result);

            Assert.Throws<DivideByZeroException>(() => result(zero));
        }

        #endregion
    }
}