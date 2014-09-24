//  *************************************************************
// <copyright file="Polynomial.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  19 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    using Math.Base;

    /// <summary>
    /// Polynomial from set.
    /// </summary>
    /// <typeparam name="T">The type parameter.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    public class Polynomial<T, TStruct> : IEquatable<Polynomial<T, TStruct>>, IPolynomial<T, TStruct>
        where TStruct : IStructure<T>, new()
    {
        #region fields

        readonly List<T> _coefficients;

        #endregion

        #region ctors

        /// <summary>
        /// Initialises a new instance of the <see cref="Polynomial{T, TStruct}"/> class.
        /// </summary>
        /// <param name="degree">The degree of the polynomial.</param>
        public Polynomial(UInt32 degree)
        {
            this._coefficients = new List<T>(new T[degree + 1]);
            this.Degree = degree;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the degree of the polynomial.
        /// </summary>
        /// <value>The degree.</value>
        public UInt32 Degree
        {
            get;
            private set;
        }

        #endregion

        #region indexers

        /// <summary>
        /// Gets or sets the coefficients of <see cref="Polynomial{T, TStruct}"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the coefficient.</param>
        /// <returns>The coefficient at the specified index.</returns>
        /// <exception cref="LinearAlgebraException">Thrown when the 
        /// index is not within the degree of the polynomial.</exception>
        public T this[UInt32 index]
        {
            get
            {
                CheckState();
                CheckOutOfRange(index);

                return _coefficients[(Int32)index];
            }

            set
            {
                CheckState();
                CheckOutOfRange(index);

                _coefficients[(Int32)index] = value;
            }
        }

        #endregion

        #region IPOLYNOMIAL implementation

        /// <summary>
        /// Returns a new the instance with same degree like the calling instance.
        /// </summary>
        /// <returns>The instance with same dimension.</returns>
        /// <param name="degree">The degree of the new polynomial.</param>
        public IPolynomial<T, TStruct> ReturnNewInstance(UInt32 degree)
        {
            return new Polynomial<T, TStruct>(degree);
        }

        #endregion

        #region IEquatable implementation

        /// <summary>
        /// Determines whether the specified <see cref="Polynomial{T, TStruct}"/> is equal to the
        /// current <see cref="Polynomial{T, TStruct}"/>.
        /// </summary>
        /// <param name="other">The <see cref="Polynomial{T, TStruct}"/> to compare with the current <see cref="Polynomial{T, TStruct}"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Polynomial{T, TStruct}"/> is equal to the
        /// current <see cref="Polynomial{T, TStruct}"/>; otherwise, <c>false</c>.</returns>
        public Boolean Equals(Polynomial<T, TStruct> other)
        {
            if (other == null)
                return false;

            if (Object.ReferenceEquals(this, other))
                return true;

            for (UInt32 i = 0; i < _coefficients.Count; i++)
            {
                if (!this[i].Equals(other[i]))
                    return false;
            }

            return true;
        }

        #endregion

        #region overrides of object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            var str = new StringBuilder(String.Format("Degree: {0}| ", Degree));
            for (UInt32 i = Degree; i > 0; i--)
            {
                str.AppendFormat("{0}*x^{1} + ", this[i], i);
            }

            str.Append(this[0]);

            return str.ToString();
        }

        #endregion

        #region helper methods

        #region helper methods

        void CheckOutOfRange(UInt32 index)
        {
            if (this.Degree == UInt32.MaxValue)
            {
                var errorMessage = String.Format("Vector class: The index is equal to max value");

                throw new LinearAlgebraException(LinearAlgebraExceptionType.IndexEqualsMaxUnsignedInteger, errorMessage);
            }

            if (this.Degree + 1 < index)
            {
                var errorMessage = String.Format(
                                       "Vector class: The index ({0}) is greater or equal then the column dimension ({1})", 
                                       index, 
                                       this.Degree);

                throw new LinearAlgebraException(LinearAlgebraExceptionType.IndexEqualOrGreaterDimension, errorMessage);
            }                              
        }

        #endregion

        #endregion

        #region debug methods

        [Conditional("DEBUG")]
        void CheckState()
        {
            var methodName = new StackTrace().GetFrame(1).GetMethod().Name;
            Trace.Write("Hi");
            Console.WriteLine("--- Entering check state for vector");
            Console.WriteLine(String.Format("The constraint type is {0}", typeof(T)));
            Console.Write("\t called by");
            Console.WriteLine(methodName);
        }

        #endregion
    }
}