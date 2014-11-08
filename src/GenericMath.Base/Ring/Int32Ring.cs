//  *************************************************************
// <copyright file="Int32Ring.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base
{
    using System;

    /// <summary>
    /// Integer ring. Mathematical ring for Integer values.
    /// </summary>
    public class Int32Ring : Int32Group, IRing<Int32>
    {
        #region properties

        #region implementation of IRing

        /// <summary>
        /// Gets the one element of the ring.
        /// </summary>
        /// <value>The one.</value>
        public Int32 One
        {
            get
            {
                return 1;
            }
        }

        #endregion

        #endregion

        #region methods

        #region IRing implementation

        /// <summary>
        /// Multiplication of the specified leftElement and rightElement.
        /// </summary>
        /// <param name="leftElement">Left element.</param>
        /// <param name="rightElement">Right element.</param>
        /// <returns>The multiplication of the leftElement and rightElement (leftElement * rightElement)</returns>
        public Int32 Multiplication(Int32 leftElement, Int32 rightElement)
        {
            return leftElement * rightElement;
        }

        #endregion

        #endregion

        #region OVERRIDES OF OBJECT

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override String ToString()
        {
            return String.Format(
                "[{0}: Zero={1}, One={2} Generic argument type: {3}]",
                this.GetType().Name,
                this.Zero,
                this.One,
                typeof(Int32));
        }

        #endregion
    }
}