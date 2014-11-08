//  *************************************************************
// <copyright file="IParser.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
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