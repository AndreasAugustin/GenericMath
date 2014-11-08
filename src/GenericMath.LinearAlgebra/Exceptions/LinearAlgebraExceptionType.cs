//  *************************************************************
// <copyright file="LinearAlgebraExceptionType.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra
{
    using System.ComponentModel;

    /// <summary>
    /// Exception type for the Math.LinearAlgebra assembly.
    /// </summary>
    public enum LinearAlgebraExceptionType
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