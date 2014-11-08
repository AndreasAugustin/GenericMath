//  *************************************************************
// <copyright file="DirectSumParser.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Parser
{
    using System;
    using System.Collections.Generic;

    using GenericMath.Base;
    using GenericMath.Common;
    using GenericMath.LinearAlgebra;

    /// <summary>
    /// Parser for DirectSum
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    /// <typeparam name="TParser">The parser for the type.</typeparam>
    public class DirectSumParser<T, TStruct, TParser> : IParser<DirectSum<T, TStruct>>
        where TStruct : IStructure<T>, new()
        where TParser : IParser<T>, new()
    {
        #region fields

        private readonly TParser _typeParser = new TParser();
        private readonly IRegex _regex = new RegexAdapter();
        private List<T> _entries = new List<T>();

        #endregion

        #region methods

        /// <summary>
        /// Parse the specified stringInput.
        /// </summary>
        /// <param name="inputString">String input.</param>
        /// <returns>A new direct sum with the specified values in the string.</returns>
        /// <exception cref="NotSupportedException">Thrown if the string is not valid to parse.</exception>
        public DirectSum<T, TStruct> Parse(String inputString)
        {
            var matchArray = this._regex.Split(inputString, ",");

            if (matchArray.Length <= 0)
            {
                throw new NotSupportedException("No match");
            }
                
            var tuple = new DirectSum<T, TStruct>((uint)matchArray.Length);

            for (uint i = 0; i < matchArray.Length; i++)
            {
                tuple[i] = this._typeParser.Parse(matchArray[i]);
            }

            return tuple;
        }

        #endregion
    }
}