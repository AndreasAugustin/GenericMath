//  *************************************************************
// <copyright file="Interval.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 9 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Base
{
    using System;

    /// <summary>
    /// Implementation of <see cref="IInterval{T, TStruct}"/>
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    public class Interval<T, TStruct> : IInterval<T, TStruct>,  IEquatable<Interval<T, TStruct>>
        where T : IComparable
        where TStruct : IStructure<T>, new()
    {
        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval{T, TStruct}"/> class.
        /// </summary>
        /// <param name="minElement">Minimum element.</param>
        /// <param name="maxElement">Max element.</param>
        /// <exception cref="AccessViolationException">Thrown when the minElement is greater or equal maxElement</exception>
        public Interval(T minElement, T maxElement)
        {
            if (minElement.CompareTo(maxElement) >= 0)
            {
                throw new AccessViolationException("minElement needs to be less then maxElement");
            }

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
        /// <returns><c>true</c> if the element is in the Interval else <c>false</c></returns>
        /// <param name="elementToCheck">Element to check.</param>
        public bool IsinInterval(T elementToCheck)
        {
            return elementToCheck.CompareTo(this.MinElement) >= 0 && elementToCheck.CompareTo(this.MaxElement) <= 0;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Interval{T, TStruct}"/> is equal to the current 
        /// <see cref="Interval{T, TStruct}"/>.
        /// </summary>
        /// <param name="other">The <see cref="Interval{T, TStruct}"/> to compare with the current 
        /// <see cref="Interval{T, TStruct}"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Interval{T, TStruct}"/> is equal to the current
        /// <see cref="Interval{T, TStruct}"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Interval<T, TStruct> other)
        {
            return this.MaxElement.Equals(other.MaxElement) && this.MinElement.Equals(other.MinElement);
        }

        #endregion

        #region overrides of OBJECT

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Interval{T, TStruct}"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Interval{T, TStruct}"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "[Interval: MaxElement={0}, MinElement={1}]",
                this.MaxElement,
                this.MinElement);
        }

        #endregion
    }
}