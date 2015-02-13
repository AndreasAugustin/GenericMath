//  *************************************************************
// <copyright file="IntervalParser.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;

namespace GenericMath.Parser
{
	using System;
	using System.Text.RegularExpressions;

	using GenericMath.Base;

	/// <summary>
	/// Interval parser.
	/// </summary>
	/// <typeparam name="T">The underlying set.</typeparam>
	/// <typeparam name="TStruct">The underlying structure.</typeparam>
	/// <typeparam name="TParser">The parser for the set.</typeparam>
	public class IntervalParser<T, TStruct, TParser> : IParser<Interval<T, TStruct>>
        where T : IComparable
        where TStruct : IStructure<T>, new()
        where TParser : IParser<T>, new()
	{
		#region fields

		private readonly TParser parser = new TParser ();

		#endregion

		#region methods

		/// <summary>
		/// Parse the specified inputString.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>A Interval parsed from the input.</returns>
		/// <exception cref="NotSupportedException">Thrown when the input is not valid.</exception>
		public Interval<T, TStruct> Parse (String inputString)
		{
			var match = Regex.Split(inputString, ":");

			if (match.Length != 2) {
				throw new NotSupportedException ();
			}

			var minElement = this.parser.Parse(match [0]);
			var maxElement = this.parser.Parse(match [1]);

			return new Interval<T, TStruct> (minElement, maxElement);
		}

		#endregion
	}
}