//  *************************************************************
// <copyright file="RingFactory.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 7 / 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    /// <summary>
    /// Factory for creating rings.
    /// </summary>
    public class RingFactory
    {
        #region FIELDS

        readonly Dictionary<Type, Func<object>> _dict;

        #endregion

        #region ctor

        /// <summary>
        /// Initialises a new instance of the <see cref="RingFactory"/> class.
        /// </summary>
        public RingFactory()
        {
            if (_dict == null)
                _dict = new Dictionary<Type, Func<object>>();

            AddDictItem(typeof(Double), SelectDoubleRing);
            AddDictItem(typeof(Int32), SelectInt32Ring);
            AddDictItem(typeof(Complex), SelectComplexRing);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Selects the group.
        /// </summary>
        /// <returns>The calculator.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public IRing<T> SelectRing<T>()
        {
            var type = typeof(T);
            if (_dict.ContainsKey(type))
            {
                var ring = this._dict[type]() as IRing<T>;
                if (ring == null)
                {
                    throw new InvalidCastException(
                        String.Format("Unexpected: The cast from {0} object to {1} was not successfull", ring.GetType(), typeof(IRing<T>)));
                }

                return ring; 
            }

            // when the calculator is not registered
            throw new NotSupportedException(string.Format("The struct type {0} is not supported (yet)", typeof(T)));
        }

        #endregion

        #region OVERRIDES OF OBJECT

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return String.Format("[{0}]", this.GetType().Name);
        }

        #endregion

        #region HELPER METHODS

        void AddDictItem(Type type, Func<object> calculatorFunction)
        {
            if (!_dict.ContainsKey(type))
                _dict.Add(type, calculatorFunction);
        }

        object SelectDoubleRing()
        {
            return new DoubleRing();
        }

        object SelectInt32Ring()
        {
            return new Int32Ring();
        }

        object SelectComplexRing()
        {
            return new ComplexRing();
        }

        #endregion
    }
}