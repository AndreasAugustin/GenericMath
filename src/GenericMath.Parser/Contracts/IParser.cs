//  *************************************************************
// <copyright file="IParser.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  24 / 9 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Parser
{
    using System;

    /// <summary>
    /// Interface for parser.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    public interface IParser<T>
    {
        #region methods

        /// <summary>
        /// Parse the specified inputString.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <returns>The parsed value.</returns>
        T Parse(String inputString);

        #endregion
    }
}