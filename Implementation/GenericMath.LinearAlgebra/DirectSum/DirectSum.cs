﻿//  *************************************************************
// <copyright file="DirectSum.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;
using GenericMath.LinearAlgebra.Contracts;

namespace GenericMath.LinearAlgebra
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// The Vector class.
    /// </summary>
    /// <typeparam name="T">The first type parameter.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    public class DirectSum<T, TStruct> : IEquatable<DirectSum<T, TStruct>>, IDirectSum<T, TStruct>
        where TStruct : IStructure, new()
    {
        #region fields

        /// <summary>
        /// The entries of the vector.
        /// </summary>
        private readonly List<T> _entries;

        #endregion

        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectSum{T,TStruct}"/> class.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        public DirectSum (UInt32 dimension)
        {
            this.CheckState();

            this._entries = new List<T>(new T[dimension]);
            this.Dimension = dimension;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the dimension.
        /// </summary>
        /// <value>The dimension.</value>
        public UInt32 Dimension { get; private set; }

        #endregion

        #region indexers

        /// <summary>
        /// Gets or sets the <see cref="DirectSum{T, TStruct}"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The value at index.</returns>
        /// <exception cref="LinearAlgebraException">Thrown when the 
        /// index is not within the dimension of the direct sum.</exception>
        public T this [UInt32 index]
        {
            get
            { 
                this.CheckState();

                this.CheckOutOfRange(index);

                return this._entries[(Int32)index]; 
            }

            set
            {
                this.CheckState();

                this.CheckOutOfRange(index);

                this._entries[(Int32)index] = value; 
            }
        }

        #endregion

        #region overrides of object

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="DirectSum{T, TStruct}"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="DirectSum{T, TStruct}"/>.</returns>
        public override String ToString ()
        {
            var str = new StringBuilder("Index and entries: \n");
            for (var i = 0; i < this.Dimension; i++) {
                str.AppendFormat("{0}:{1}; ", i, this._entries[i]);
            }

            return str.ToString();
        }

        #endregion

        #region IDIRECTSUM implementaition

        /// <summary>
        /// Returns the new instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        /// <param name="rowDimension">Row dimension.</param>
        public IDirectSum<T, TStruct> ReturnNewInstance (UInt32 rowDimension)
        {
            return new DirectSum<T, TStruct>(rowDimension);
        }

        #endregion

        #region IEquatable implementation

        /// <summary>
        /// Determines whether the specified <see cref="DirectSum{T,TStruct}"/> is equal to the current <see cref="DirectSum{T,TStruct}"/>.
        /// </summary>
        /// <param name="other">The <see cref="DirectSum{T,TStruct}"/> to compare with the current <see cref="DirectSum{T,TStruct}"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="DirectSum{T,TStruct}"/> is equal to the current
        /// <see cref="DirectSum{T,TStruct}"/>otherwise, <c>false</c>.</returns>
        public Boolean Equals (DirectSum<T, TStruct> other)
        {
            if (other == null) {
                return false;
            }

            if (Object.ReferenceEquals(this, other)) {
                return true;
            }

            for (UInt32 i = 0; i < this._entries.Count; i++) {
                if (!this[i].Equals(other[i])) {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region helper methods

        private void CheckOutOfRange (UInt32 index)
        {
            if (this.Dimension == UInt32.MaxValue) {
                throw new LinearAlgebraException(
                    LinearAlgebraExceptionType.IndexEqualsMaxUnsignedInteger,
                    String.Format("Vector class: The index is equal to max value"));
            }
                               
            if (this.Dimension + 1 < index) {
                var errorMessage = String.Format(
                           "Vector class: The index ({0}) is greater or equal then the column dimension ({1})", 
                           index, 
                           this.Dimension);

                throw new LinearAlgebraException(
                    LinearAlgebraExceptionType.IndexEqualOrGreaterDimension,
                    errorMessage);
            }
        }

        #endregion

        #region debug methods

        [Conditional("DEBUG")]
        private void CheckState ()
        {
            var methodName = new StackTrace().GetFrame(1).GetMethod().Name;
            Trace.Write("Hi");
            Console.WriteLine("--- Entering check state for vector");
            Console.WriteLine(String.Format(
                "The constraint type is {0}",
                typeof(T)));
            Console.Write("\t called by");
            Console.WriteLine(methodName);
        }

        #endregion
    }
}