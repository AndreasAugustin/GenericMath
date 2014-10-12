//  *************************************************************
// <copyright file="PolynomialParser.cs" company="${Company}">
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

    using Math.Base;
    using Math.LinearAlgebra;

    /// <summary>
    /// Polynomial parser.
    /// </summary>
    public class PolynomialParser<T, TStruct, TParser> : IParser<Polynomial<T, TStruct>>
        where TStruct : IStructure<T>, new()
        where TParser : IParser<T>, new()
    {
        #region fields

        readonly TParser _parser = new TParser();

        #endregion

        #region IParser implementation

        /// <summary>
        /// Parse the specified inputString.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        public Polynomial<T, TStruct> Parse(String inputString)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}