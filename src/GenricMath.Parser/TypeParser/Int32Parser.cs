//  *************************************************************
// <copyright file="Int32OrdinaryParser.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  24 / 9 / 2014 Created the Class
// *************************************************************

namespace GenricMath.Parser
{
    using System;

    /// <summary>
    /// Parser for Int32 values.
    /// </summary>
    public class Int32Parser : IParser<Int32>
    {
        #region ITypeParser implementation

        /// <summary>
        /// Parse the specified inputString.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        public Int32 Parse(String inputString)
        {
            Int32 value;

            if (!Int32.TryParse(inputString, out value))
                throw new InvalidCastException();

            return value;
        }

        #endregion
    }
}