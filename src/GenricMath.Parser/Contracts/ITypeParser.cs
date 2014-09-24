//  *************************************************************
// <copyright file="ITypeParser.cs" company="${Company}">
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


    /// <summary>
    /// Parser for types.
    /// </summary>
    public interface ITypeParser<T>
    {
        /// <summary>
        /// Parse the specified inputString.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        T Parse(String inputString);
    }
}