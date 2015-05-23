//  *************************************************************
// <copyright file="PolynomialParserTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;

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
        #region properties

        private IEnumerable<TestCaseData> TestDataSet
        {
            get
            {
                var expectedInt32Polynomial = new Polynomial<Int32, Int32Monoid>(2);
                expectedInt32Polynomial[0] = 1;
                expectedInt32Polynomial[1] = 2;
                expectedInt32Polynomial[2] = 3;

                yield return new TestCaseData(
                    0,
                    new Int32Monoid(),
                    new Int32Parser(),
                    new PolynomialParser<Int32, Int32Monoid, Int32Parser>(),
                    "1,2,3",
                    expectedInt32Polynomial);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Parses the valid parse equals expected.
        /// </summary>
        /// <param name = "hack1">First hack.</param>
        /// <param name = "hack2">Second hack.</param>
        /// <param name = "hack3">Third hack.</param>
        /// <param name = "parser">The parser.</param>
        /// <param name="stringInput">The input.</param>
        /// <param name="expected">The expected direct sum.</param>
        /// <typeparam name="TSet">The underlying set.</typeparam>
        /// <typeparam name="TStruct">The underlying structure of the set.</typeparam>
        /// <typeparam name="TParser">The parser for the underlying set.</typeparam>
        [Test]
        [Category("DirectSumParserTest")]
        [TestCaseSource("TestDataSet")]
        public void Parse_ValidParse_EqualsExpected<TSet, TStruct, TParser> (
            TSet hack1,
            TStruct hack2,
            TParser hack3,
            PolynomialParser<TSet, TStruct, TParser> parser,
            String stringInput,
            Polynomial<TSet, TStruct> expected)
            where TStruct : IStructure, new()
            where TParser : IParser<TSet>, new()
        {
            var result = parser.Parse(stringInput);
            Assert.IsNotNull(result);

            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}