//  *************************************************************
// <copyright file="Matrix.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using GenericMath.Base;

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

        private readonly List<List<T>> _entries;

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T, TStruct}"/> class.
        /// The matrix is squared.
        /// </summary>
        /// <param name="dimension">The Dimension of the matrix.</param>
        public Matrix(UInt32 dimension)
            : this(dimension, dimension)
        {
            // Noting to do here
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T, TStruct}"/> class.
        /// </summary>
        /// <param name="rowDimension">Row dimension.</param>
        /// <param name="columnDimension">Column dimension.</param>
        public Matrix(UInt32 rowDimension, UInt32 columnDimension)
        {
            this._entries = new List<List<T>>();
            for (var i = 0; i < columnDimension; i++)
            {
                this._entries.Add(new List<T>(new T[rowDimension]));
            }
                
            this.RowDimension = rowDimension;
            this.ColumnDimension = columnDimension;
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
                this.CheckOutOfRange(row, column);

                return this._entries[(Int32)column][(Int32)row]; 
            }

            set
            {      
                this.CheckOutOfRange(row, column);

                this._entries[(Int32)column][(Int32)row] = value;
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
        public IMatrix<T, TStruct> ReturnNewInstance(
            UInt32 rowDimension,
            UInt32 columnDimension)
        {
            return new Matrix<T, TStruct>(rowDimension, columnDimension);
        }

        #endregion

        #region OVERRIDES OF OBJECT

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
        {
            var str = new StringBuilder(String.Format(
                              "Rows: {0}, Columns: {1} {2}",
                              this.RowDimension,
                              this.ColumnDimension,
                              Environment.NewLine));

            for (UInt32 i = 0; i < this.RowDimension; i++)
            {
                str.AppendFormat("Row: {0} \t", i);

                for (UInt32 j = 0; j < this.ColumnDimension; j++)
                {
                    str.AppendFormat("{0} \t", this[i, j]);
                }

                str.Append(Environment.NewLine);
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
            for (UInt32 j = 0; j < this.ColumnDimension; j++)
            {
                for (UInt32 i = 0; i < this.RowDimension; i++)
                {
                    if (!other[i, j].Equals(this[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        #region METHODS

        private void CheckOutOfRange(UInt32 rowIndex, UInt32 columnIndex)
        {
            this.CheckColumnOutOfRange(columnIndex);

            this.CheckRowOutOfRange(rowIndex);
        }

        private void CheckColumnOutOfRange(UInt32 columnIndex)
        {
            if (this.ColumnDimension == UInt32.MaxValue)
            {
                throw new LinearAlgebraException(
                    LinearAlgebraExceptionType.IndexEqualOrGreaterDimension, 
                    String.Format("Matrix class: The index is equal to max value"));
            }

            if (this.ColumnDimension + 1 < columnIndex)
            {
                var errorMessage = String.Format(
                                       "Matrix class: The column ({0}) is greater or equal then the column dimension ({1})",
                                       columnIndex,
                                       this.ColumnDimension);

                throw new LinearAlgebraException(
                    LinearAlgebraExceptionType.IndexEqualOrGreaterDimension,
                    errorMessage); 
            }               
        }

        private void CheckRowOutOfRange(UInt32 rowIndex)
        {
            if (this.RowDimension == UInt32.MaxValue)
            {
                var errorMessage = String.Format("Matrix class: The index is equal to max value");

                throw new LinearAlgebraException(
                    LinearAlgebraExceptionType.IndexEqualOrGreaterDimension,
                    errorMessage);
            }

            if (this.RowDimension + 1 < rowIndex)
            {
                var errorMessage = String.Format(
                                       "Matrix class: The row ({0}) is greater or equal then the row dimension ({1})",
                                       rowIndex, 
                                       this.ColumnDimension);

                throw new LinearAlgebraException(
                    LinearAlgebraExceptionType.IndexEqualOrGreaterDimension,
                    errorMessage);   
            }                             
        }

        #endregion
    }
}
