//  *************************************************************
// <copyright file="IRing.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  26 / 7 / 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    /// <summary>
    /// Interface for declaring a ring (Here it is an integer ring).
    /// </summary>
    /// <typeparam name="T">The type parameter is the set of the elements for the ring.</typeparam> 
    public interface IRing<T> : IGroup<T>, IStructure<T>
    {
        #region properties

        /// <summary>
        /// Gets the one element of the ring.
        /// </summary>
        /// <value>The one.</value>
        T One { get; }

        #endregion

        #region methods

        /// <summary>
        /// Multiplication of the specified leftElement and rightElement.
        /// </summary>
        /// <param name="leftElement">Left element.</param>
        /// <param name="rightElement">Right element.</param>
        /// <returns>The multiplication of the leftElement and rightElement (leftElement * rightElement)</returns>
        T Multiplication(T leftElement, T rightElement);

        #endregion
    }
}