//  *************************************************************
// <copyright file="VectorExceptionType.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System.ComponentModel;

    /// <summary>
    /// Vector exception type.
    /// </summary>
    public enum VectorExceptionType
    {
        /// <summary>
        /// The default.
        /// </summary>
        [Description("There has been an exception")]
        Default = 0,

        /// <summary>
        /// The index equal or greater dimension.
        /// </summary>
        [Description("The index needs to be less the dimension")]
        IndexEqualOrGreaterDimension = 1,

        /// <summary>
        /// The index equals max unsigned integer.
        /// </summary>
        [Description("The index is equal to the max unsigned integer value")]
        IndexEqualsMaxUnsignedInteger = 2,
    }
}