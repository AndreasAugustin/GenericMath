﻿//  *************************************************************
// <copyright file="IDateTime.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  20 / 9 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Common
{
    using System;

    /// <summary>
    /// Interface for date time.
    /// </summary>
    public interface IDateTime
    {
        #region properties

        /// <summary>
        /// Gets the current united time.
        /// </summary>
        /// <value>The current united time.</value>
        DateTime UtcNow { get; }

        #endregion
    }
}