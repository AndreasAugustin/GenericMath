//  *************************************************************
// <copyright file="DirectSumException.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;
    using System.ComponentModel;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception class for vectors.
    /// </summary>
    [Serializable]
    public class DirectSumException : ApplicationException
    {
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

        #region ctors

        /// <summary>
        /// Initialises a new instance of the <see cref="DirectSumException"/> class.
        /// </summary>
        public DirectSumException()
            : base()
        {
            // nothing to do here
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DirectSumException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public DirectSumException(String message)
            : base(message)
        {
            // nothing to do here
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DirectSumException"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        protected DirectSumException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // nothing to do here.
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the type of the exception.
        /// </summary>
        /// <value>The type of the exception.</value>
        public VectorExceptionType ExceptionType
        {
            get;
            set;
        }

        #endregion
    }
}