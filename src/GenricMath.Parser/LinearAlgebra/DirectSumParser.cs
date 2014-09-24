//  *************************************************************
// <copyright file="IDirectSumParser.cs" company="${Company}">
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
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using Math.Base;
    using Math.LinearAlgebra;

    /// <summary>
    /// Parser for DirectSum
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    public class DirectSumParser<T, TStruct, TTypeParser> : IParser<DirectSum<T, TStruct>>
        where TStruct : IStructure<T>, new()
        where TTypeParser : ITypeParser<T>, new()
    {
        #region fields

        List<T> _entries = new List<T>();
        TTypeParser _typeParser = new TTypeParser();

        #endregion

        #region methods

        /// <summary>
        /// Parse the specified stringInput.
        /// </summary>
        /// <param name="inputString">String input.</param>
        public DirectSum<T, TStruct> Parse(string inputString)
        {
            var matchArray = Regex.Split(inputString, ",");

            if (matchArray.Length <= 0)
                throw new NotSupportedException("No match");

            var tuple = new DirectSum<T, TStruct>((UInt32)matchArray.Length);

            for (UInt32 i = 0; i < matchArray.Length; i++)
            {
                tuple[i] = _typeParser.Parse(matchArray[i]);
            }

            return tuple;
        }

        #endregion
    }
}