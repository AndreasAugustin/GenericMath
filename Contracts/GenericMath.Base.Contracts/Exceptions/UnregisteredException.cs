// *************************************************************
// <copyright file="UnregisteredException.cs" company="None">
//      Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>AndreasAugustin</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception which determines that an object is not registered.
    /// </summary>
    [Serializable]
    public class UnregisteredException : KeyNotFoundException, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericMath.Base.Contracts.UnregisteredException"/> class.
        /// </summary>
        public UnregisteredException ()
            : base()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericMath.Base.Contracts.UnregisteredException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public UnregisteredException (string message)
            : base(message)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericMath.Base.Contracts.UnregisteredException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public UnregisteredException (string message, Exception innerException)
            : base(message, innerException)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericMath.Base.Contracts.UnregisteredException"/> class.
        /// </summary>
        /// <param name="info">Info.</param>
        /// <param name="context">Context.</param>
        protected UnregisteredException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            
        }
    }
}

