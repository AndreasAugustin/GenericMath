//  *************************************************************
// <copyright file="IMatrix.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using System;
using GenericMath.Base.Contracts;

namespace GenericMath.LinearAlgebra.Contracts
{
	/// <summary>
	/// Interface for the matrix class.
	/// </summary>
	/// <typeparam name="T">The underlying set.</typeparam>
	/// <typeparam name="TStruct">The underlying structure.</typeparam>
	public interface IMatrix<T, TStruct>
        where TStruct : IStructure<T>, new()
	{
		#region properties

		/// <summary>
		/// Gets the row dimension.
		/// </summary>
		/// <value>The row dimension.</value>
		UInt32 RowDimension { get; }

		/// <summary>
		/// Gets the column dimension.
		/// </summary>
		/// <value>The column dimension.</value>
		UInt32 ColumnDimension { get; }

		/// <summary>
		/// Gets or sets the <see cref="IMatrix{T, TStruct}"/> with the specified row column.
		/// </summary>
		/// <param name="row">The Row.</param>
		/// <param name="column">The Column.</param>
		/// <returns>The value at row and column.</returns>
		T this [UInt32 row, UInt32 column]
		{
			get;
			set;
		}

		#endregion

		#region methods

		/// <summary>
		/// Returns the new instance.
		/// </summary>
		/// <returns>The new instance.</returns>
		/// <param name="rowDimension">Row dimension.</param>
		/// <param name="columnDimension">Column dimension.</param>
		IMatrix<T, TStruct> ReturnNewInstance (
			UInt32 rowDimension,
			UInt32 columnDimension);

		#endregion
	}
}