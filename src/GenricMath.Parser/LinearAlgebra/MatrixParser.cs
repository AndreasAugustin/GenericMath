//  *************************************************************
// <copyright file="MatrixParser.cs" company="${Company}">
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
    using System.Text.RegularExpressions;

    using Math.Base;
    using Math.LinearAlgebra;

    /// <summary>
    /// Matrix parser.
    /// </summary>
    public class MatrixParser<T, TStruct, TParser> : IParser<Matrix<T, TStruct>>
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
        public Matrix<T, TStruct> Parse(String inputString)
        {
            var rows = Regex.Split(inputString, ";");

            if (rows.Length < 1)
                throw new NotSupportedException("No rows");

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
                    throw new NotSupportedException("Column count must agree");

                for (UInt32 j = 0; j < temp.Length; j++)
                {
                    mat[i, j] = _parser.Parse(temp[j]);
                }
                    
            }

            return mat;
        }

        #endregion
    }
}