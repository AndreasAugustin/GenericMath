//  *************************************************************
// <copyright file="PolynomialTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  13 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    /// <summary>
    /// Test methods for the <see cref="Polynomial{T, TStruct}"/> class.
    /// </summary>
    /// <typeparam name="T">The underlying set.</typeparam>
    /// <typeparam name="TStruct">The underlying structure for T.</typeparam>
    [TestFixture(typeof(Double), typeof(DoubleMonoid))]
    [TestFixture(typeof(Complex), typeof(ComplexGroup))]
    [TestFixture(typeof(Int32), typeof(Int32Ring))]
    public class PolynomialTest<T, TStruct>
        where TStruct : IStructure<T>, new()
    {
        #region methods

        /// <summary>
        /// Initializes a new polynomial with given degree and checks the degree.
        /// </summary>
        /// <param name="givenDegree">The degree.</param>
        [Test]
        [Category("PolynomialTest")]
        [TestCase((UInt32)2)]
        [TestCase((UInt32)6)]
        public void Initialize_CheckDegree_EqualsGivenDegree(UInt32 givenDegree)
        {
            var poly = new Polynomial<T, TStruct>(givenDegree);
            Assert.IsNotNull(poly);

            Assert.AreEqual(givenDegree, poly.Degree);
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Polynomial{T, TStruct}"/> class with given degree.
        /// Queries the polynomial for index out of range.
        /// Throws a <see cref="DirectSumException"/>. 
        /// </summary>
        /// <param name="degree">The dimension.</param>
        /// <param name="index">The index.</param>
        [Test]
        [Category("PolynomialTest")]
        [TestCase((UInt32)2, (UInt32)4)]
        [TestCase((UInt32)1, (UInt32)4)]
        public void Indexer_SettingToHighIndex_ThrowsPolynomialException(UInt32 degree, UInt32 index)
        {
            var value = default(T);
            var poly = new Polynomial<T, TStruct>(degree);
            Assert.IsNotNull(poly);

            Assert.Throws<LinearAlgebraException>(() => poly[index] = value);
        }

        #endregion
    }
}