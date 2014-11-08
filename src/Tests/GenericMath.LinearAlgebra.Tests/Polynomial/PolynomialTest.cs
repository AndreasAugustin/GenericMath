//  *************************************************************
// <copyright file="PolynomialTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
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
        [TestCase((uint)2)]
        [TestCase((uint)6)]
        public void Initialize_CheckDegree_EqualsGivenDegree(uint givenDegree)
        {
            var poly = new Polynomial<T, TStruct>(givenDegree);
            Assert.IsNotNull(poly);

            Assert.AreEqual(givenDegree, poly.Degree);
        }

        /// <summary>
        /// Queries the polynomial for index out of range.
        /// Throws a <see cref="LinearAlgebraException"/>. 
        /// </summary>
        /// <param name="degree">The dimension.</param>
        /// <param name="index">The index.</param>
        [Test]
        [Category("PolynomialTest")]
        [TestCase((uint)2, (uint)4)]
        [TestCase((uint)1, (uint)4)]
        public void Indexer_SettingToHighIndex_ThrowsPolynomialException(
            uint degree,
            uint index)
        {
            var value = default(T);
            var poly = new Polynomial<T, TStruct>(degree);
            Assert.IsNotNull(poly);

            Assert.Throws<LinearAlgebraException>(() => poly[index] = value);
        }

        #endregion
    }
}