﻿//  *************************************************************
// <copyright file="ComplexFieldTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  20 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.Base.Tests
{
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    [TestFixture]
    public class ComplexFieldTest : TemplateFieldTest<Complex>
    {
        #region fields

        IField<Complex> _field;

        #endregion

        #region properties

        #region implemented abstract members of TemplateEuclidianRingTest

        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <value>The field.</value>
        protected override IField<Complex> Field
        {
            get
            {
                return this._field ?? (this._field = new ComplexField());
            }
        }

        IEnumerable<TestCaseData> Source
        {
            get
            {
                yield return new TestCaseData(new Complex(3.2, 0), new Complex(1 / 3.2, 0));
                yield return new TestCaseData(new Complex(0, 10), new Complex(0, -(1 / 10.0)));
            }
        }

        #endregion

        #endregion

        #region implemented abstract members of TemplateEuclidianRingTest

        /// <summary>
        /// Tests the euclidian norm.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="expected">Expected solution.</param>
        [Test]
        [Category("FieldTest")]
        [TestCaseSource("Source")]
        public override void TestMultiplicationInverse(Complex input, Complex expected)
        {
            this.TemplateTestMultiplicationInverse(input, expected);
        }

        #endregion
    }
}