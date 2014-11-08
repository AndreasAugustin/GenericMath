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
        #region properties

        private IEnumerable<TestCaseData> TestCaseSource
        {
            get
            {
                var expectedInt32GroupInterval = new Interval<Int32, Int32Group>(1, 3);

                yield return new TestCaseData(
                    "1:3",
                    0,
                    new Int32Group(),
                    new Int32Parser(),
                    new IntervalParser<Int32, Int32Group, Int32Parser>(),
                    expectedInt32GroupInterval);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Parses the valid parse minimum and max equals expected.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <param name="hack1">First hack.</param>
        /// <param name="hack2">Second hack.</param>
        /// <param name="hack3">Third hack.</param>
        /// <param name="parser">The parser.</param>
        /// <param name="expected">The expected.</param>
        /// <typeparam name="TSet">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure of the set.</typeparam>
        /// <typeparam name="TParser">The parser for the underlying set.</typeparam>
        [Category("IntervalParser")]
        [Test]
        [TestCaseSource("TestCaseSource")]
        public void Parse_ValidParse_ResultEqualsExpected<TSet, TStruct, TParser>(
            String inputString, 
            TSet hack1,
            TStruct hack2,
            TParser hack3,
            IntervalParser<TSet, TStruct, TParser> parser,
            Interval<TSet, TStruct> expected)
            where TSet : IComparable
            where TStruct : IStructure<TSet>, new()
            where TParser : IParser<TSet>, new()
        {
            var result = parser.Parse(inputString);

            Assert.IsNotNull(result);

            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}