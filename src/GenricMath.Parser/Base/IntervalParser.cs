//  *************************************************************
// <copyright file="IntervalParser.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  24 / 9 / 2014 Created the Class
// *************************************************************

namespace GenricMath.Parser
{
    using System;
    using System.Text.RegularExpressions;

    using Math.Base;

    /// <summary>
    /// Interval parser.
    /// </summary>
    public class IntervalParser<T, TStruct, TTypeParser>
        where T : IComparable
        where TStruct : IStructure<T>, new()
        where TTypeParser : ITypeParser<T>, new()
    {
        #region fields

        readonly TTypeParser parser = new TTypeParser();

        #endregion

        #region methods

        /// <summary>
        /// Parse the specified inputString.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        public Interval<T, TStruct> Parse(String inputString)
        {
            var match = Regex.Split(inputString, ":");

            if (match.Length != 2)
                throw new NotSupportedException();

            var minElement = parser.Parse(match[0]);
            var maxElement = parser.Parse(match[1]);

            return new Interval<T, TStruct>(minElement, maxElement);
        }

        #endregion
    }
}