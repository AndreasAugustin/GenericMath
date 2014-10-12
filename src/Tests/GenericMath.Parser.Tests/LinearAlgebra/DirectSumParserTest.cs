//  *************************************************************
// <copyright file="DirectSumParserTest.cs" company="SuperDevelop">
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

    using GenricMath.Parser;
    using Math.Base;
    using Math.LinearAlgebra;
    using NUnit.Framework;

    /// <summary>
    /// Test for the <see cref="DirectSumParser{T, TStruct, TParser}"/> class.
    /// </summary>
    [TestFixture]
    public class DirectSumParserTest
    {
        // TODO abstract direct sum parser test

        #region fields

        DirectSumParser<Int32, Int32Monoid, Int32Parser> _parser;

        #endregion

        #region properties

        DirectSumParser<Int32, Int32Monoid, Int32Parser> Parser
        {
            get
            {
                return _parser ?? (_parser = new DirectSumParser<Int32, Int32Monoid, Int32Parser>());
            }
        }

        IEnumerable<TestCaseData> TestDataSet
        {
            get
            {
                yield return new TestCaseData("1,2,3", 2);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Parses the valid parse equals expected.
        /// </summary>
        /// <param name="stringInput">String input.</param>
        /// <param name="expected">Expected.</param>
        [Test]
        [Category("DirectSumParserTest")]
        [TestCaseSource("TestDataSet")]
        public void Parse_ValidParse_EqualsExpected(
            String stringInput,
            Int32 expected)
        {
            var result = Parser.Parse(stringInput);
            Assert.IsNotNull(result);

            Assert.IsInstanceOf<DirectSum<Int32, Int32Monoid>>(result);

            Assert.AreEqual(expected, result[1]);
        }

        #endregion
    }
}