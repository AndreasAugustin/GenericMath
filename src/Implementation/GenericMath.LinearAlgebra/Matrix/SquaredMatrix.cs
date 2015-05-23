// //  *************************************************************
// // <copyright file="SquaredMatrix.cs" company="None">
// //     Copyright (c) 2014  AndreasAugustin. All rights reserved.
// // </copyright>
// // <license>MIT Licence</license>
// // <author>AndreasAugustin </author>
// // <email>andy.augustin@t-online.de</email>
// // *************************************************************
//

namespace GenericMath.LinearAlgebra
{
    using System;
    using GenericMath.Base.Contracts;
    using GenericMath.LinearAlgebra.Contracts;

    /// <summary>
    /// Matrix where the rowDimension is equal to the column dimension.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure.</typeparam>
    public class SquaredMatrix<T, TStruct> : Matrix<T, TStruct> , ISquaredMatrix<T, TStruct>
		where TStruct : IStructure, new()
    {
        #region properties

        /// <summary>
        /// Gets the dimension.
        /// </summary>
        /// <value>The dimension.</value>
        public uint Dimension { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericMath.LinearAlgebra.SquaredMatrix{T, TStruct}"/> class.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
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
        public ISquaredMatrix<T, TStruct> ReturnNewInstance (uint dimension)
        {
            return new SquaredMatrix<T, TStruct>(dimension);
        }
    }
}