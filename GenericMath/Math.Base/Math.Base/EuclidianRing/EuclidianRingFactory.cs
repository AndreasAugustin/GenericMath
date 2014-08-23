//  *************************************************************
// <copyright file="EuclidianRingFactory.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0 15/7/ 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    /// <summary>
    /// Calculator factory.
    /// Produces calculators 
    /// </summary>
    public class EuclidianRingFactory
    {
        #region FIELDS

        readonly Dictionary<Type, Func<object>> _dict;

        #endregion

        #region ctor

        /// <summary>
        /// Initialises a new instance of the <see cref="EuclidianRingFactory"/> class.
        /// </summary>
        public EuclidianRingFactory()
        {
            if (_dict == null)
                _dict = new Dictionary<Type, Func<object>>();
								
            AddDictItem(typeof(Double), SelectDoubleCalculator);
            AddDictItem(typeof(Int32), SelectInt32Calculator);
            AddDictItem(typeof(Complex), SelectComplexCalculator);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Selects the calculator.
        /// </summary>
        /// <returns>The calculator.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public IEuclidianRing<T> SelectEuclidianRing<T>()
        {
            var type = typeof(T);
            if (_dict.ContainsKey(type))
            {
                var calculator = this._dict[type]() as IEuclidianRing<T>;
                if (calculator == null)
                {
                    throw new InvalidCastException(string.Format("Unexpected: The cast from {0} object to {1} was not successfull", calculator.GetType(), typeof(IEuclidianRing<T>)));
                }
					
                return calculator; 
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

        object SelectDoubleCalculator()
        {
            return new DoubleEuclidianRing();
        }

        object SelectInt32Calculator()
        {
            return new Int32EuclidianRing();
        }

        object SelectComplexCalculator()
        {
            return new ComplexEuclidianRing();
        }

        #endregion
    }
}