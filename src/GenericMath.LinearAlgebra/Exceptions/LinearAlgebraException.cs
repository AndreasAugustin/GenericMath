﻿//  *************************************************************
// <copyright file="LinearAlgebraException.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.LinearAlgebra
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception class for Math.LinearAlgebra assembly.
    /// </summary>
    [Serializable]
    public class LinearAlgebraException : ApplicationException
    {
        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearAlgebraException"/> class.
        /// </summary>
        /// <param name="exceptionType">Exception type.</param>
        public LinearAlgebraException(LinearAlgebraExceptionType exceptionType)
            : base()
        {
            this.ExceptionType = exceptionType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearAlgebraException"/> class.
        /// </summary>
        /// <param name="exceptionType">Exception type.</param>
        /// <param name="message">The message.</param>
        public LinearAlgebraException(
            LinearAlgebraExceptionType exceptionType,
            String message)
            : base(message)
        {
            this.ExceptionType = exceptionType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearAlgebraException"/> class.
        /// </summary>
        /// <param name="exceptionType">Exception type.</param>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        protected LinearAlgebraException(
            LinearAlgebraExceptionType exceptionType,
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
            this.ExceptionType = exceptionType;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the type of the exception.
        /// </summary>
        /// <value>The type of the exception.</value>
        public LinearAlgebraExceptionType ExceptionType
        {
            get;
            private set;
        }

        #endregion
    }
}