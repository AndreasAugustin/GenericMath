//  *************************************************************
// <copyright file="DoubleFieldTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  18 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Test for the <see cref="DoubleField"/> class.
    /// </summary>
    [TestFixture]
    public class DoubleFieldTest : TemplateFieldTest<Double>
    {
        #region fields

        private IField<Double> _field;

        #endregion

        #region properties

        #region implemented abstract members of TemplateEuclidianRingTest

        /// <summary>
        /// Gets the ring.
        /// </summary>
        /// <value>The ring.</value>
        protected override IField<Double> Field
        {
            get
            {
                return this._field ?? (this._field = new DoubleField());
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
        [TestCase(2.0, 0.5)]
        [TestCase(4.0, 0.25)]
        public override void TestMultiplicationInverse(
            Double input,
            Double expected)
        {
            this.TemplateTestMultiplicationInverse(input, expected);
        }

        #endregion
    }
}