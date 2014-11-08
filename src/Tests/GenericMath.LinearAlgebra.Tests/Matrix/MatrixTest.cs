//  *************************************************************
// <copyright file="MatrixTest.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra.Tests
{
    using System;
    using System.Numerics;

    using GenericMath.Base;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="Matrix{T, TStruct}"/> class.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure for T.</typeparam>
    [TestFixture(typeof(Double), typeof(DoubleMonoid))]
    [TestFixture(typeof(Complex), typeof(ComplexGroup))]
    [TestFixture(typeof(Int32), typeof(Int32Ring))]
    public class MatrixTest<T, TStruct>
        where TStruct : IStructure<T>, new()
    {
        #region methods

        /// <summary>
        /// Initializes a new matrix with given row dimension and checks the row dimension.
        /// </summary>
        /// <param name="rowDimension">The rowDimension.</param>
        [Test]
        [Category("MatrixTest")]
        [TestCase((uint)2)]
        [TestCase((uint)6)]
        public void Initialize_CheckRowDimension_EqualsGivenRowDimension(UInt32 rowDimension)
        {
            var matrix = new Matrix<T, TStruct>(rowDimension, 1);
            Assert.IsNotNull(matrix);

            Assert.AreEqual(rowDimension, matrix.RowDimension);
        }

        /// <summary>
        /// Initializes a new matrix with given column dimension and checks the column dimension.
        /// </summary>
        /// <param name="columnDimension">The column dimension.</param>
        [Test]
        [Category("MatrixTest")]
        [TestCase((UInt32)2)]
        [TestCase((UInt32)6)]
        public void Initialize_CheckColumnDimension_EqualsGivenColumnDimension(UInt32 columnDimension)
        {
            var matrix = new Matrix<T, TStruct>(1, columnDimension);
            Assert.IsNotNull(matrix);

            Assert.AreEqual(columnDimension, matrix.ColumnDimension);
        }

        /// <summary>
        /// Initializes a new squared matrix with given dimension and checks the dimension.
        /// </summary>
        /// <param name="dimension">The dimension for squared matrix.</param>
        [Test]
        [Category("MatrixTest")]
        [TestCase((uint)2)]
        [TestCase((uint)6)]
        public void InitializeSquared_CheckDimension_EqualsGivenDimension(UInt32 dimension)
        {
            var matrix = new Matrix<T, TStruct>(dimension);
            Assert.IsNotNull(matrix);

            Assert.AreEqual(dimension, matrix.RowDimension);
            Assert.AreEqual(dimension, matrix.ColumnDimension);
        }

        /// <summary>
        /// Queries the polynomial for index out of range.
        /// Throws a <see cref="LinearAlgebraException"/>. 
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="rowIndex">The index.</param>
        [Test]
        [Category("MatrixTest")]
        [TestCase((UInt32)2, (UInt32)4)]
        [TestCase((UInt32)1, (UInt32)4)]
        public void Indexer_SettingToHighIndex_ThrowsPolynomialException(
            UInt32 dimension,
            UInt32 rowIndex)
        {
            var value = default(T);
            var matrix = new Matrix<T, TStruct>(dimension);
            Assert.IsNotNull(matrix);

            Assert.Throws<LinearAlgebraException>(() => matrix[rowIndex, 0] = value);
        }

        #endregion
    }
}