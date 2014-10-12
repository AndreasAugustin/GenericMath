//  *************************************************************
// <copyright file="PolynomialParserTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  24 / 9 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Parser.Tests
{
    using System;
    using System.Collections.Generic;

    using GenericMath.Base;
    using GenericMath.LinearAlgebra;
    using GenericMath.Parser;
    using NUnit.Framework;

    /// <summary>
    /// Polynomial parser test.
    /// </summary>
    [TestFixture]
    public class PolynomialParserTest
    {
        // TODO abstract test

        #region fields

        private PolynomialParser<Int32, Int32Monoid, Int32Parser> _parser;

        #endregion

        #region properties

        /// <summary>
        /// Gets the parser.
        /// </summary>
        /// <value>The parser.</value>
        public PolynomialParser<Int32, Int32Monoid, Int32Parser> Parser
        {
            get
            {
                return this._parser ?? (this._parser = new PolynomialParser<int, Int32Monoid, Int32Parser>());
            }
        }

        private IEnumerable<TestCaseData> TestCaseSource
        {
            get
            {
                yield return new TestCaseData("x^2 - 4*x^4", 1);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the parse method.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <param name="expected">The expected value.</param>
        [Test]
        [Category("PolynomialParser")]
        [TestCaseSource("TestCaseSource")]
        [Ignore]
        public void Parse_ValidParse_ElementEqualsExpected(
            String inputString,
            Int32 expected)
        {
            var result = this.Parser.Parse(inputString);

            Assert.IsNotNull(result);

            Assert.AreEqual(expected, result[2]);
        }

        #endregion
    }
}