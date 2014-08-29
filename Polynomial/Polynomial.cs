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

        readonly IVector<T, TStruct> _coefficients;

        #endregion

        #region ctors

        /// <summary>
        /// Initialises a new instance of the <see cref="Polynomial{T, TStruct}"/> class.
        /// </summary>
        /// <param name="degree">The degree of the polynomial.</param>
        public Polynomial(UInt32 degree)
        {
            _coefficients = new Vector<T, TStruct>(degree + 1);
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Polynomial{T, TStruct}"/> class.
        /// </summary>
        /// <param name="coefficients">The coefficients.</param>
        public Polynomial(IVector<T, TStruct> coefficients)
        {
            _coefficients = coefficients.Copy();
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the degree of the polynomial.
        /// </summary>
        /// <value>The degree.</value>
        public UInt32 Degree
        {
            get { return _coefficients.Dimension - 1; }
        }

        /// <summary>
        /// Gets the coefficients.
        /// </summary>
        /// <value>The coefficients.</value>
        internal IVector<T, TStruct> Coefficients
        {
            get { return _coefficients; }
        }

        /// <summary>
        /// Gets the base structure.
        /// </summary>
        /// <value>The base structure.</value>
        internal TStruct BaseStructure
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
        public T this[UInt32 index]
        {
            get
            {
                return _coefficients[index];
            }

            set
            {
                _coefficients[index] = value;
            }
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
            return other != null && this.Coefficients.Equals(other.Coefficients);
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
    }
}