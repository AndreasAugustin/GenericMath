// //  *************************************************************
// // <copyright file="SquaredMatrix.cs" company="None">
// //     Copyright (c) 2014  AndreasAugustin. All rights reserved.
// // </copyright>
// // <license>MIT Licence</license>
// // <author>AndreasAugustin </author>
// // <email>andy.augustin@t-online.de</email>
// // *************************************************************
//
using System;
using GenericMath.LinearAlgebra.Contracts;
using GenericMath.Base.Contracts;

namespace GenericMath.LinearAlgebra
{
	public class SquaredMatrix<T, TStruct> : Matrix<T, TStruct> , ISquaredMatrix<T, TStruct>
		where TStruct : IStructure<T>, new()
	{
		#region properties

		/// <summary>
		/// Gets the dimension.
		/// </summary>
		/// <value>The dimension.</value>
		public uint Dimension { get; private set; }

		#endregion

		#region ctors

		public SquaredMatrix (UInt32 dimension)
			: base(dimension, dimension)
		{
			this.Dimension = dimension;
		}

		#endregion

		/// <summary>
		/// Returns the new instance.
		/// </summary>
		/// <returns>The new instance.</returns>
		/// <param name="dimension">Row dimension.</param>
		public IMatrix<T, TStruct> ReturnNewInstance (uint dimension)
		{
			return new SquaredMatrix<T, TStruct> (dimension);
		}
	}
}