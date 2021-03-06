﻿//  *************************************************************
// <copyright file="NLogAdapter.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Common
{
    using GenericMath.Common.Contracts;
    using System;
    using NLog;

    /// <summary>
    /// Adapter for the <see cref="LogManager"/>
    /// </summary>
    internal sealed class NLogAdapter : GenericMath.Common.Contracts.ILogger
    {
        #region fields

        private readonly Logger _logger;

        #endregion

        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogAdapter"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public NLogAdapter (Logger logger)
        {
            this._logger = logger;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public String Name
        {
            get { return this._logger.Name; }
        }

        #endregion

        #region ILogger implementation

        /// <summary>
        /// Trace with the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Trace (String message)
        {
            this._logger.Trace(message);
        }

        /// <summary>
        /// Debug with the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug (String message)
        {
            this._logger.Debug(message);
        }

        /// <summary>
        /// Info with the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info (String message)
        {
            this._logger.Info(message);
        }

        /// <summary>
        /// Warn with the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warn (String message)
        {
            this._logger.Warn(message);
        }

        /// <summary>
        /// Error with the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error (String message)
        {
            this._logger.Error(message);
        }

        /// <summary>
        /// Fatal with the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal (String message)
        {
            this._logger.Fatal(message);
        }

        /// <summary>
        /// Log the specified log level and message.
        /// </summary>
        /// <param name="loglevel">The log level.</param>
        /// <param name="message">The message.</param>
        public void Log (GenericMath.Common.Contracts.LogLevel loglevel, String message)
        {
            this._logger.Log(loglevel.ConvertToNLogLogLevel(), message);
        }

        /// <summary>
        /// Determines whether this instance is enabled the specified log level.
        /// </summary>
        /// <returns><c>true</c> if this instance is enabled the specified log level; otherwise, <c>false</c>.</returns>
        /// <param name="loglevel">The log level.</param>
        public Boolean IsEnabled (GenericMath.Common.Contracts.LogLevel loglevel)
        {
            return this._logger.IsEnabled(loglevel.ConvertToNLogLogLevel());
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="DocToMarkdown.Common.NLogAdapter"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override Int32 GetHashCode ()
        {
            return this._logger.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="DocToMarkdown.Common.NLogAdapter"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="DocToMarkdown.Common.NLogAdapter"/>.</returns>
        public override String ToString ()
        {
            var nlogToString = this._logger.ToString();
            return String.Format("[NLogAdapter: Name={0}, NLog: {1}]", this.Name, nlogToString);
        }

        #endregion
    }
}