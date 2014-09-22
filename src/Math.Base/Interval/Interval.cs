//  *************************************************************
// <copyright file="Interval.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    using System;

    /// <summary>
    /// Implementation of <see cref="IInterval{T, TStruct}"/>
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    public class Interval<T, TStruct> : IInterval<T, TStruct>
        where T : IComparable
        where TStruct : IStructure<T>, new()
    {
        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval{T, TStruct}"/> class.
        /// </summary>
        /// <param name="minElement">Minimum element.</param>
        /// <param name="maxElement">Max element.</param>
        /// <exception cref="AccessViolationException">Thrown when the minElement is reater or equal maxElement</exception>
        public Interval(T minElement, T maxElement)
        {
            if (minElement.CompareTo(maxElement) >= 0)
                throw new AccessViolationException("minElement needs to be less then maxElement");

            this.MinElement = minElement;
            this.MaxElement = maxElement;
        }

        #endregion

        #region IInterval implementation

        /// <summary>
        /// Gets the max element.
        /// </summary>
        /// <value>The max element.</value>
        public T MaxElement
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the minimum element.
        /// </summary>
        /// <value>The minimum element.</value>
        public T MinElement
        {
            get;
            private set;
        }

        /// <summary>
        /// Determines whether this element is within interval.
        /// </summary>
        /// <returns>true</returns>
        /// <c>false</c>
        /// <param name="elementToCheck">Element to check.</param>
        public Boolean IsinInterval(T elementToCheck)
        {
            return elementToCheck.CompareTo(MinElement) >= 0 && elementToCheck.CompareTo(MaxElement) <= 0;
        }

        #endregion
    }
}