//  *************************************************************
// <copyright file="Vector.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  21 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    using Math.Base;

    /// <summary>
    /// The Vector class.
    /// </summary>
    /// <typeparam name="T">The first type parameter.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    public class Vector<T, TStruct> : IEquatable<Vector<T, TStruct>>, IVector<T, TStruct>
        where TStruct : IStructure<T>, new()
    {
        #region fields

        /// <summary>
        /// The entries of the vector.
        /// </summary>
        readonly List<T> _entries;

        #endregion

        #region ctors

        /// <summary>
        /// Initialises a new instance of the <see cref="Vector{T,TStruct}"/> class.
        /// </summary>
        /// <param name="dimension">the dimension.</param>
        public Vector(UInt32 dimension)
        {
            _entries = new List<T>(new T[dimension]);
            this.Dimension = dimension;

            this.BaseStructure = new TStruct();
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the dimension.
        /// </summary>
        /// <value>The dimension.</value>
        public UInt32 Dimension { get; private set; }

        /// <summary>
        /// Gets the entries.
        /// </summary>
        /// <value>The entries.</value>
        internal List<T> Entries
        {
            get
            { 
                return _entries;
            }
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
        /// Gets or sets the <see cref="Vector{T, TStruct}"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The value at index.</returns>
        public T this[UInt32 index]
        {
            get
            { 
                CheckOutOfRange(index);

                return _entries[(Int32)index]; 
            }

            set
            {
                CheckOutOfRange(index);

                _entries[(Int32)index] = value; 
            }
        }

        #endregion

        #region overrides of object

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Vector{T, TStruct}"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Vector{T, TStruct}"/>.</returns>
        public override String ToString()
        {
            var str = new StringBuilder("Index and entries: \n");
            for (var i = 0; i < Dimension; i++)
            {
                str.AppendFormat("{0}:{1}; ", i, _entries[i]);
            }

            return str.ToString();
        }

        #endregion

        #region IEquatable implementation

        /// <summary>
        /// Determines whether the specified <see cref="Vector{T,TStruct}"/> is equal to the current <see cref="Vector{T,TStruct}"/>.
        /// </summary>
        /// <param name="other">The <see cref="Vector{T,TStruct}"/> to compare with the current <see cref="Vector{T,TStruct}"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Vector{T,TStruct}"/> is equal to the current
        /// <see cref="Vector{T,TStruct}"/>otherwise, <c>false</c>.</returns>
        public Boolean Equals(Vector<T, TStruct> other)
        {
            if (other == null)
                return false;

            if (Object.ReferenceEquals(this, other))
                return true;

            for (var i = 0; i < Entries.Count; i++)
            {
                if (!Entries[i].Equals(other.Entries[i]))
                    return false;
            }

            return true;
        }

        #endregion

        #region helper methods

        void CheckOutOfRange(UInt32 index)
        {
            if (Dimension == UInt32.MaxValue)
                throw new VectorException(String.Format("Vector class: The index is equal to max value"))
                { 
                    ExceptionType = VectorExceptionType.IndexEqualsMaxUnsignedInteger 
                };

            if (Dimension + 1 < index)
                throw new VectorException(String.Format("Vector class: The index ({0}) is greater or equal then the column dimension ({1})", index, Dimension))
                { 
                    ExceptionType = VectorExceptionType.IndexEqualOrGreaterDimension
                };
        }

        #endregion

        #region debug methods

        [Conditional("DEBUG")]
        void CheckState()
        {
            var methodName = new StackTrace().GetFrame(1).GetMethod().Name;

            Console.WriteLine("--- Entering check state for vector");
            Console.WriteLine(String.Format("The constraint type is {0}", typeof(T)));
            Console.Write("\t called by");
            Console.WriteLine(methodName);
        }

        #endregion
    }
}