//  *************************************************************
// <copyright file="ConsoleLogger.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  26 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Console
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Logger for the <see cref="Console"/> class.
    /// </summary>
    public class ConsoleLogger : TraceListener
    {
        #region implemented abstract members of TraceListener

        /// <summary>
        /// Write the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Write(String message)
        {
            #if __ANDROID__ || __IOS__
            Debug.Write(message);
            #else
            Console.Write(message);
            #endif
        }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void WriteLine(String message)
        {
            #if __ANDROID__ || __IOS__
            Debug.WriteLine(message);
            #else
            Console.WriteLine(message);
            #endif
        }

        #endregion
    }
}