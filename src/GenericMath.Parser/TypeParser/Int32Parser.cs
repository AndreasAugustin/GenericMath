//  *************************************************************
// <copyright file="Int32Parser.cs" company="None">
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
    /// Parser for integer values.
    /// </summary>
    public class Int32Parser : IParser<Int32>
    {
        #region ITypeParser implementation

        /// <summary>
        /// Parse the specified inputString.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <returns>The parsed integer value.</returns>
        /// <exception cref="InvalidCastException">Thrown when the cast did not work.</exception>
        public Int32 Parse(String inputString)
        {
            Int32 value;

            if (!Int32.TryParse(inputString, out value))
            {
                throw new InvalidCastException();
            }
                
            return value;
        }

        #endregion
    }
}