﻿//  *************************************************************
// <copyright file="DirectSumTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.LinearAlgebra.Tests
{
    using System;
    using System.Numerics;

    using GenericMath.Base;
    using NUnit.Framework;

    /// <summary>
    /// Test methods for the <see cref="DirectSum{T, TStruct}"/> class.
    /// </summary>
    /// <typeparam name="T">The set,</typeparam>
    /// <typeparam name="TStruct">The structure.</typeparam>
    [TestFixture(typeof(Double), typeof(DoubleMonoid))]
    [TestFixture(typeof(Complex), typeof(ComplexGroup))]
    [TestFixture(typeof(Int32), typeof(Int32Ring))]
    public class DirectSumTest<T, TStruct> 
        where T : new() 
        where TStruct : IStructure<T>, new()
    {
        #region methods

        /// <summary>
        /// Initializes the check dimension equals given dimension.
        /// </summary>
        /// <param name="givenDimension">The dimension.</param>
        [Test]
        [Category("DirectSumTest")]
        [TestCase((uint)2)]
        [TestCase((uint)6)]
        public void Initialize_CheckDimension_EqualsGivenDimension(uint givenDimension)
        {
            var vec = new DirectSum<T, TStruct>(givenDimension);
            Assert.IsNotNull(vec);

            Assert.AreEqual(givenDimension, vec.Dimension);
        }

        /// <summary>
        /// Indexers the setting to high dimension throws vector exception.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="index">The index.</param>
        [Test]
        [Category("DirectSumTest")]
        [TestCase((uint)2, (uint)4)]
        [TestCase((uint)1, (uint)4)]
        public void Indexer_SettingToHighDimension_ThrowsVectorException(
            uint dimension,
            uint index)
        {
            var value = default(T);
            var vec = new DirectSum<T, TStruct>(dimension);
            Assert.IsNotNull(vec);

            Assert.Throws<LinearAlgebraException>(() => vec[index] = value);
        }

        #endregion
    }
}