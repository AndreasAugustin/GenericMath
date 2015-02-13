// //  *************************************************************
// // <copyright file="ISquaredMatrix.cs" company="None">
// //     Copyright (c) 2014  AndreasAugustin. All rights reserved.
// // </copyright>
// // <license>MIT Licence</license>
// // <author>AndreasAugustin </author>
// // <email>andy.augustin@t-online.de</email>
// // *************************************************************
//

using System;
using GenericMath.Base.Contracts;

namespace GenericMath.LinearAlgebra.Contracts
{
	/// <summary>
	/// Interface for squared matrizes.
	/// </summary>
	public interface ISquaredMatrix<T, TStruct> : IMatrix<T, TStruct>
		where TStruct : IStructure<T>, new()
	{
		/// <summary>
		/// Gets the dimension.
		/// </summary>
		/// <value>The dimension.</value>
		UInt32 Dimension { get; }

		/// <summary>
		/// Returns the new instance.
		/// </summary>
		/// <returns>The new instance.</returns>
		/// <param name="dimension">Row dimension.</param>
		IMatrix<T, TStruct> ReturnNewInstance (
			UInt32 dimension);
	}
}