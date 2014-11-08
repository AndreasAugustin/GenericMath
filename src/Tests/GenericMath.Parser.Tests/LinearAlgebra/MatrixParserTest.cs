//  *************************************************************
// <copyright file="MatrixParserTest.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
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
    /// Test for the <see cref="MatrixParser{T, TStruct, TParser}"/> class.
    /// </summary>
    [TestFixture]
    public class MatrixParserTest
    {
        // TODO abstract test

        #region fields

        private MatrixParser<Int32, Int32Group, Int32Parser> _parser;

        #endregion

        #region properties

        private MatrixParser<Int32, Int32Group, Int32Parser> Parser
        {
            get
            {
                return this._parser ?? (this._parser = new MatrixParser<int, Int32Group, Int32Parser>());
            }
        }

        private IEnumerable<ITestCaseData> TestCaseSource
        {
            get
            {
                yield return new TestCaseData("1, 2, 4; 4, 5, 2", 4);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Parses the valid parse element equals expected.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <param name="expected">The expected value.</param>
        [Test]
        [Category("MatrixParser")]
        [TestCaseSource("TestCaseSource")]
        public void Parse_ValidParse_ElementEqualsExpected(
            String inputString,
            Int32 expected)
        {
            var result = this.Parser.Parse(inputString);

            Assert.IsNotNull(result);

            Assert.AreEqual(expected, result[0, 2]);
        }

        #endregion
    }
}