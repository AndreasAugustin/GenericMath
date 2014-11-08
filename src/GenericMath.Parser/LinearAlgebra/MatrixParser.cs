//  *************************************************************
// <copyright file="MatrixParser.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Parser
{
    using System;
    using System.Text.RegularExpressions;

    using GenericMath.Base;
    using GenericMath.LinearAlgebra;

    /// <summary>
    /// Matrix parser.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    /// <typeparam name="TParser">The parser for the set.</typeparam>
    public class MatrixParser<T, TStruct, TParser> : IParser<Matrix<T, TStruct>>
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
        /// <returns>A matrix with values from the inputString</returns>
        /// <exception cref="NotSupportedException">When the string does not contain valid information.</exception>
        public Matrix<T, TStruct> Parse(String inputString)
        {
            var rows = Regex.Split(inputString, ";");

            if (rows.Length < 1)
            {
                throw new NotSupportedException("No rows");
            }

            Int32 columns = 0;
            Matrix<T, TStruct> mat = null;
            for (UInt32 i = 0; i < rows.Length; i++)
            {
                var temp = Regex.Split(rows[(Int32)i], ",");

                if (temp.Length == 0)
                {
                    throw new NotSupportedException("No columns");
                }

                if (columns == 0)
                {
                    columns = temp.Length;
                    mat = new Matrix<T, TStruct>(
                        (UInt32)rows.Length,
                        (UInt32)columns);
                }
                    
                if (columns != temp.Length)
                {
                    throw new NotSupportedException("Column count must agree");
                }

                for (UInt32 j = 0; j < temp.Length; j++)
                {
                    mat[i, j] = this._parser.Parse(temp[j]);
                }                    
            }

            return mat;
        }

        #endregion
    }
}