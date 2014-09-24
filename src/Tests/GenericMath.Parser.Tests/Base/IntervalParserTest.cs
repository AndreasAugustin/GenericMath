//  *************************************************************
// <copyright file="IntervalParserTest.cs" company="${Company}">
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
    /// Test for the interval parser
    /// </summary>
    [TestFixture]
    public class IntervalParserTest
    {
        // TODO abstract IntervalParser test

        #region fields

        IntervalParser<Int32, Int32Monoid, Int32Parser> _parser;

        #endregion

        #region properties

        IntervalParser<Int32, Int32Monoid, Int32Parser> Parser
        {
            get
            {
                return _parser ?? (_parser = new IntervalParser<int, Int32Monoid, Int32Parser>());
            }
        }

        IEnumerable<TestCaseData> TestCaseSource
        {
            get
            {
                yield return new TestCaseData("1:3", 1, 3, 2);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Parses the valid parse minimum and max equals expcted.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <param name="minElement">Minimum element.</param>
        /// <param name="maxElement">Max element.</param>
        /// <param name="elementOfInterval">Element of interval.</param>
        [Category("IntervalParser")]
        [Test]
        [TestCaseSource("TestCaseSource")]
        public void Parse_ValidParse_MinAndMaxEqualsExpcted(
            String inputString, 
            Int32 minElement, 
            Int32 maxElement, 
            Int32 elementOfInterval)
        {
            var result = Parser.Parse(inputString);

            Assert.IsNotNull(result);

            Assert.AreEqual(minElement, result.MinElement);
            Assert.AreEqual(maxElement, result.MaxElement);

            Assert.IsTrue(result.IsinInterval(elementOfInterval));
        }

        #endregion
    }
}