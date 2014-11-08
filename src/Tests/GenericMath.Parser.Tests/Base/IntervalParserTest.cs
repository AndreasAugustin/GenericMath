//  *************************************************************
// <copyright file="IntervalParserTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
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
    using GenericMath.Parser;
    using NUnit.Framework;

    /// <summary>
    /// Test for the interval parser
    /// </summary>
    [TestFixture]
    public class IntervalParserTest
    {
        // TODO abstract IntervalParser test

        #region fields

        private IntervalParser<Int32, Int32Monoid, Int32Parser> _parser;

        #endregion

        #region properties

        private IntervalParser<Int32, Int32Monoid, Int32Parser> Parser
        {
            get
            {
                return this._parser ?? (this._parser = new IntervalParser<int, Int32Monoid, Int32Parser>());
            }
        }

        private IEnumerable<TestCaseData> TestCaseSource
        {
            get
            {
                yield return new TestCaseData("1:3", 1, 3, 2);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Parses the valid parse minimum and max equals expected.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <param name="minElement">Minimum element.</param>
        /// <param name="maxElement">Max element.</param>
        /// <param name="elementOfInterval">Element of interval.</param>
        [Category("IntervalParser")]
        [Test]
        [TestCaseSource("TestCaseSource")]
        public void Parse_ValidParse_MinAndMaxEqualsExpected(
            String inputString, 
            Int32 minElement, 
            Int32 maxElement, 
            Int32 elementOfInterval)
        {
            var result = this.Parser.Parse(inputString);

            Assert.IsNotNull(result);

            Assert.AreEqual(minElement, result.MinElement);
            Assert.AreEqual(maxElement, result.MaxElement);

            Assert.IsTrue(result.IsinInterval(elementOfInterval));
        }

        #endregion
    }
}