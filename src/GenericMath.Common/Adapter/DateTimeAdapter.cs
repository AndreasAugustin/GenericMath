//  *************************************************************
// <copyright file="DateTimeAdapter.cs" company="${Company}">
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

    public class DateTimeAdapter : IDateTime
    {
        #region IDateTime implementation

        /// <summary>
        /// Gets the current united time.
        /// </summary>
        /// <value>The current united time.</value>
        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        #endregion
    }
}