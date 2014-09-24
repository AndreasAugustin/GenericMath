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
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using Math.Base;
    using Math.LinearAlgebra;

    /// <summary>
    /// Polynomial parser.
    /// </summary>
    public class PolynomialParser<T, TStruct, TTypeParser> : IParser<Polynomial<T, TStruct>>
        where TStruct : IStructure<T>, new()
        where TTypeParser : ITypeParser<T>, new()
    {
        #region fields

        readonly TTypeParser _parser = new TTypeParser();

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