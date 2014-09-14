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
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception class for <see cref="DirectSum{T, TStruct}"/> classes.
    /// </summary>
    [Serializable]
    public class DirectSumException : ApplicationException
    {
        #region ctors

        /// <summary>
        /// Initialises a new instance of the <see cref="DirectSumException"/> class.
        /// </summary>
        /// <param name = "exceptionType"></param>
        public DirectSumException(DirectSumExceptionType exceptionType)
            : base()
        {
            this.ExceptionType = exceptionType;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DirectSumException"/> class.
        /// </summary>
        /// <param name = "exceptionType"></param>
        /// <param name="message">The message.</param>
        public DirectSumException(DirectSumExceptionType exceptionType, String message)
            : base(message)
        {
            this.ExceptionType = exceptionType;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DirectSumException"/> class.
        /// </summary>
        /// <param name = "exceptionType"></param>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        protected DirectSumException(DirectSumExceptionType exceptionType, SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.ExceptionType = exceptionType;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the type of the exception.
        /// </summary>
        /// <value>The type of the exception.</value>
        public DirectSumExceptionType ExceptionType
        {
            get;
            private set;
        }

        #endregion

        #region overrides of object

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="DirectSumException"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="DirectSumException"/>.</returns>
        public override string ToString()
        {
            return string.Format("[DirectSumException: ExceptionType={0}] {1} {2}", 
                this.ExceptionType.ToString(), Environment.NewLine, base.ToString());
        }

        #endregion
    }
}