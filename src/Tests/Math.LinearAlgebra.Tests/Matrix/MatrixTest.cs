//  *************************************************************
// <copyright file="MatrixTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  15 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="Matrix{T, TStruct}"/> class.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure for T.</typeparam>
    [TestFixture(typeof(double), typeof(DoubleMonoid))]
    [TestFixture(typeof(Complex), typeof(ComplexGroup))]
    [TestFixture(typeof(int), typeof(Int32Ring))]
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
        public void Initialize_CheckRowDimension_EqualsGivenRowDimension(uint rowDimension)
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
        [TestCase((uint)2)]
        [TestCase((uint)6)]
        public void Initialize_CheckColumnDimension_EqualsGivenColumnDimension(uint columnDimension)
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
        public void InitializeSquared_CheckDimension_EqualsGivenDimension(uint dimension)
        {
            var matrix = new Matrix<T, TStruct>(dimension);
            Assert.IsNotNull(matrix);

            Assert.AreEqual(dimension, matrix.RowDimension);
            Assert.AreEqual(dimension, matrix.ColumnDimension);
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Polynomial{T, TStruct}"/> class with given degree.
        /// Queries the polynomial for index out of range.
        /// Throws a <see cref="DirectSumException"/>. 
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="rowIndex">The index.</param>
        [Test]
        [Category("MatrixTest")]
        [TestCase((uint)2, (uint)4)]
        [TestCase((uint)1, (uint)4)]
        public void Indexer_SettingToHighIndex_ThrowsPolynomialException(
            uint dimension,
            uint rowIndex)
        {
            var value = default(T);
            var matrix = new Matrix<T, TStruct>(dimension);
            Assert.IsNotNull(matrix);

            Assert.Throws<LinearAlgebraException>(() => matrix[rowIndex, 0] = value);
        }

        #endregion
    }
}