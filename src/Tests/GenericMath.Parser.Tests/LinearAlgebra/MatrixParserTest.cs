//  *************************************************************
// <copyright file="MathParserTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  24 / 9 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Parser.Tests
{
    using System;
    using System.Collections.Generic;

    using Math.Base;
    using GenricMath.Parser;
    using NUnit.Framework;

    /// <summary>
    /// Test for the <see cref="MatrixParser{T, TStruct, TParser}"/> class.
    /// </summary>
    [TestFixture]
    public class MatrixParserTest
    {
        // TODO abstract test

        #region fields

        MatrixParser<Int32, Int32Group, Int32Parser> _parser;

        #endregion

        #region properties

        MatrixParser<Int32, Int32Group, Int32Parser> Parser
        {
            get
            {
                return _parser ?? (_parser = new MatrixParser<int, Int32Group, Int32Parser>());
            }
        }

        IEnumerable<ITestCaseData> TestCaseSource
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
        /// <param name="expected">Expected.</param>
        [Test]
        [Category("MatrixParser")]
        [TestCaseSource("TestCaseSource")]
        public void Parse_ValidParse_ElementEqualsExpected(
            String inputString,
            Int32 expected)
        {
            var result = Parser.Parse(inputString);

            Assert.IsNotNull(result);

            Assert.AreEqual(expected, result[0, 2]);
        }

        #endregion
    }
}