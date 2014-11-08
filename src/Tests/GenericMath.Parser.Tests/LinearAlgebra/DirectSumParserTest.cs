//  *************************************************************
// <copyright file="DirectSumParserTest.cs" company="None">
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
    /// Test for the <see cref="DirectSumParser{T, TStruct, TParser}"/> class.
    /// </summary>
    [TestFixture]
    public class DirectSumParserTest
    {
        // TODO abstract direct sum parser test

        #region fields

        private DirectSumParser<Int32, Int32Monoid, Int32Parser> _parser;

        #endregion

        #region properties

        private DirectSumParser<Int32, Int32Monoid, Int32Parser> Parser
        {
            get
            {
                return this._parser ?? (this._parser = new DirectSumParser<Int32, Int32Monoid, Int32Parser>());
            }
        }

        private IEnumerable<TestCaseData> TestDataSet
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
        /// <param name="expected">The expected value.</param>
        [Test]
        [Category("DirectSumParserTest")]
        [TestCaseSource("TestDataSet")]
        public void Parse_ValidParse_EqualsExpected(
            String stringInput,
            Int32 expected)
        {
            var result = this.Parser.Parse(stringInput);
            Assert.IsNotNull(result);

            Assert.IsInstanceOf<DirectSum<Int32, Int32Monoid>>(result);

            Assert.AreEqual(expected, result[1]);
        }

        #endregion
    }
}