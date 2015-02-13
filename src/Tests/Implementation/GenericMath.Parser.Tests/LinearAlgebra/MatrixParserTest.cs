//  *************************************************************
// <copyright file="MatrixParserTest.cs" company="None">
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
	/// Test for the <see cref="MatrixParser{T, TStruct, TParser}"/> class.
	/// </summary>
	[TestFixture]
	public class MatrixParserTest
	{
		#region properties

		private IEnumerable<ITestCaseData> TestCaseSource
		{
			get
			{
				var expectedInt32Matrix = new Matrix<Int32, Int32Group> (2, 3);
				expectedInt32Matrix [0, 0] = 1;
				expectedInt32Matrix [0, 1] = 2;
				expectedInt32Matrix [0, 2] = 4;
				expectedInt32Matrix [1, 0] = 4;
				expectedInt32Matrix [1, 1] = 5;
				expectedInt32Matrix [1, 2] = 2;

				yield return new TestCaseData (
					0,
					new Int32Group (),
					new Int32Parser (),
					new MatrixParser<Int32, Int32Group, Int32Parser> (),
					"1, 2, 4; 4, 5, 2",
					expectedInt32Matrix);
			}
		}

		#endregion

		#region methods

		/// <summary>
		/// Parses the valid parse element equals expected.
		/// </summary>
		/// <param name = "hack1">The first hack.</param>
		/// <param name = "hack2">The second hack.</param>
		/// <param name = "hack3">The third hack.</param>
		/// <param name = "parser">The parser.</param>
		/// <param name="inputString">The input string.</param>
		/// <param name="expected">The expected matrix.</param>
		/// <typeparam name="TSet">The underlying set.</typeparam>
		/// <typeparam name="TStruct">The underlying structure of the set.</typeparam>
		/// <typeparam name="TParser">The parser for the underlying set.</typeparam>
		[Test]
		[Category("MatrixParser")]
		[TestCaseSource("TestCaseSource")]
		public void Parse_ValidParse_ElementEqualsExpected<TSet, TStruct, TParser> (
			TSet hack1,
			TStruct hack2,
			TParser hack3,
			MatrixParser<TSet, TStruct, TParser> parser,
			String inputString,
			Matrix<TSet, TStruct> expected)
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