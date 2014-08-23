//  *************************************************************
// <copyright file="VectorException.cs" company="${Company}">
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
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception class for vectors.
    /// </summary>
    [Serializable]
    public class VectorException : Exception
    {
        #region ctors

        /// <summary>
        /// Initialises a new instance of the <see cref="VectorException"/> class.
        /// </summary>
        public VectorException()
            : base()
        {
            // nothing to do here
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="VectorException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public VectorException(String message)
            : base(message)
        {
            // nothing to do here
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="VectorException"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        protected VectorException(SerializationInfo info, StreamingContext context)
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