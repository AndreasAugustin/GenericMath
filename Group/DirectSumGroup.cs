//  *************************************************************
// <copyright file="DirectSumGroup.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 8 / 2014 Created the Class
// *************************************************************
using System;

namespace Math.LinearAlgebra
{
    public class DirectSumGroup
    {
        #region fields

        readonly UInt32 _dimension;

        #endregion

        #region ctors

        /// <summary>
        /// Initialises a new instance of the <see cref="Math.LinearAlgebra.DirectSumGroup"/> class.
        /// </summary>
        /// <param name="dimension">Dimension.</param>
        public DirectSumGroup(UInt32 dimension)
        {
            _dimension = dimension;
        }

        #endregion

        #region properties

        #endregion
    }
}