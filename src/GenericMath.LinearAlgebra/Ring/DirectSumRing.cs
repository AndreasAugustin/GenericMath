//  *************************************************************
// <copyright file="DirectSumRing.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Base.Contracts;

namespace GenericMath.LinearAlgebra
{
	using System;

	using GenericMath.Base;

	/// <summary>
	/// Direct sum ring.
	/// </summary>
	/// <typeparam name="T">The underlying set.</typeparam>
	/// <typeparam name="TRing">The underlying structure</typeparam>
	public class DirectSumRing<T, TRing> : DirectSumGroup<T, TRing>, IRing<DirectSum<T, TRing>>
        where TRing : IRing<T>, new()
	{
		#region ctors

		/// <summary>
		/// Initializes a new instance of the <see cref="DirectSumRing{T, TRing}"/> class.
		/// </summary>
		/// <param name="dimension">The dimension.</param>
		public DirectSumRing (UInt32 dimension)
			: base (dimension)
		{
			// Nothing to do here.
		}

		#endregion

		#region IRING implementation

		/// <summary>
		/// Gets the one element of the ring.
		/// </summary>
		/// <value>The one.</value>
		public DirectSum<T, TRing> One {
			get {
				return new SpecialDirectSums ().OneTuple<T, TRing> (this.Dimension);
			}
		}

		/// <summary>
		/// Multiplication of the specified leftElement and rightElement.
		/// </summary>
		/// <param name="leftElement">Left element.</param>
		/// <param name="rightElement">Right element.</param>
		/// <returns>The multiplication of the leftElement and rightElement (leftElement * rightElement)</returns>
		/// <exception cref="InvalidCastException">Thrown when the cast was not possible.</exception>
		public DirectSum<T, TRing> Multiplication (
			DirectSum<T, TRing> leftElement,
			DirectSum<T, TRing> rightElement)
		{
			var tuple = leftElement.Multiply (rightElement) as DirectSum<T, TRing>;

			if (tuple == null) {
				throw new InvalidCastException ();
			}
                
			return tuple;
		}

		#endregion
	}
}