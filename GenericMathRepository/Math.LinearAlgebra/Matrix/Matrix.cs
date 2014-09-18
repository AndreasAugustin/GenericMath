//  *************************************************************
// <copyright file="Matrix.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  15 / 7 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Math.Base;

    /// <summary>
    /// Creates a matrix. 
    /// The elements of the matrix are of the struct T.
    /// </summary>
    /// <typeparam name="T">The first type parameter.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    public class Matrix<T, TStruct> : IMatrix<T, TStruct>, IEquatable<Matrix<T, TStruct>> 
        where TStruct : IStructure<T>, new()
    {
        #region FIELDS

        readonly List<List<T>> _entries;

        #endregion

        #region ctor

        /// <summary>
        /// Initialises a new instance of the <see cref="Matrix{T, TStruct}"/> class.
        /// The matrix is squared.
        /// </summary>
        /// <param name="dimension">The Dimension of the matrix.</param>
        public Matrix(UInt32 dimension)
        {
            _entries = new List<List<T>>();
            for (var i = 0; i < dimension; i++)
            {
                _entries.Add(new List<T>(new T[dimension]));
            }
                
            RowDimension = dimension;
            ColumnDimension = dimension;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Matrix{T, TStruct}"/> class.
        /// </summary>
        /// <param name="rowDimension">Row dimension.</param>
        /// <param name="columnDimension">Column dimension.</param>
        public Matrix(UInt32 rowDimension, UInt32 columnDimension)
        {
            _entries = new List<List<T>>();
            for (var i = 0; i < columnDimension; i++)
            {
                _entries.Add(new List<T>(new T[rowDimension]));
            }
                
            RowDimension = rowDimension;
            ColumnDimension = columnDimension;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Matrix{T, TStruct}"/> class.
        /// </summary>
        /// <param name="entries">Entreis.</param>
        public Matrix(IEnumerable<List<T>> entries)
        {
            this._entries = entries.ToList();

            this.ColumnDimension = (UInt32)_entries.Count;
            this.RowDimension = (UInt32)_entries[0].Count;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the row dimension.
        /// </summary>
        /// <value>The row dimension.</value>
        public UInt32 RowDimension { get; private set; }

        /// <summary>
        /// Gets the column dimension.
        /// </summary>
        /// <value>The column dimension.</value>
        public UInt32 ColumnDimension
        {
            get;
            private set;
        }

        #endregion

        #region INDEXERS

        /// <summary>
        /// Gets or sets the <see cref="Matrix{T, TStrruct}"/> with the specified row column.
        /// </summary>
        /// <param name="row">The Row.</param>
        /// <param name="column">The Column.</param>
        /// <returns>The value at row and column.</returns>
        public T this[UInt32 row, UInt32 column]
        {
            get
            {	
                CheckColumnOutOfRange(column);

                return _entries[(Int32)column][(Int32)row]; 
            }

            set
            {      
                CheckColumnOutOfRange(column);

                _entries[(Int32)column][(Int32)row] = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Matrix{T, TStruct}"/> with the specified column.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns>The tuple <see cref="IDirectSum{T, TStruct}"/> at column.</returns>
        public IDirectSum<T, TStruct> this[UInt32 column]
        {
            get
            { 
                CheckColumnOutOfRange(column);

                return  new DirectSum<T, TStruct>(_entries[(Int32)column]);

            }
        }

        #endregion

        #region IMATRIX implementations

        /// <summary>
        /// Returns the new instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        /// <param name="rowDimension">Row dimension.</param>
        /// <param name="columnDimension">Column dimension.</param>
        public IMatrix<T, TStruct> ReturnNewInstance(UInt32 rowDimension, UInt32 columnDimension)
        {
            return new Matrix<T, TStruct>(rowDimension, columnDimension);
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
            var str = new StringBuilder("Columns and entries: \n");
            for (var j = 0; j < ColumnDimension; j++)
            {
                str.AppendFormat("Column:{0}; Vector: {1}; ", j, _entries[j]);
            }

            return str.ToString();
        }

        #endregion

        #region IEquatable implementation

        /// <summary>
        /// Determines whether the specified <see cref="Matrix{T, TStruct}"/> is equal to the current <see cref="Matrix{T, TStruct}"/>.
        /// </summary>
        /// <param name="other">The <see cref="Matrix{T, TStruct}"/> to compare with the current <see cref="Matrix{T, TStruct}"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Matrix{T, TStruct}"/> is equal to the current
        /// <see cref="Matrix{T, TStruct}"/>; otherwise, <c>false</c>.</returns>
        public Boolean Equals(Matrix<T, TStruct> other)
        {
            for (UInt32 j = 0; j < ColumnDimension; j++)
            {
                if (!other[j].Equals(this[j]))
                    return false;
            }

            return true;
        }

        #endregion

        #region METHODS

        void CheckColumnOutOfRange(UInt32 column)
        {
            if (ColumnDimension == UInt32.MaxValue)
                throw new IndexOutOfRangeException(String.Format("Matrix class: The index is equal to max value"));

            if (ColumnDimension + 1 < column)
                throw new IndexOutOfRangeException(string.Format("Matrix class: The column ({0}) is greater or equal then the column dimension ({1})", column, ColumnDimension));                
        }

        #endregion
    }
}
