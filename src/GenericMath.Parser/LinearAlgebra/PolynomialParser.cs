//  *************************************************************
// <copyright file="PolynomialParser.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Parser
{
    using System;

    using GenericMath.Base;
    using GenericMath.LinearAlgebra;

    /// <summary>
    /// Polynomial parser.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    /// <typeparam name="TParser">The parser for the set.</typeparam>
    public class PolynomialParser<T, TStruct, TParser> : IParser<Polynomial<T, TStruct>>
        where TStruct : IStructure<T>, new()
        where TParser : IParser<T>, new()
    {
        #region fields

        private readonly TParser _parser = new TParser();

        #endregion

        #region IParser implementation

        /// <summary>
        /// Parse the specified inputString.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <returns>A new polynomial with values from the string.</returns>
        public Polynomial<T, TStruct> Parse(String inputString)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}