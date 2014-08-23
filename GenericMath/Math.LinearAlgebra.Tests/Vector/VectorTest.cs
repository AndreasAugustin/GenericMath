//  *************************************************************
// <copyright file="VectorTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  22 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Numerics;

    using Math.Base;
    using NSubstitute;
    using NUnit.Framework;

    /// <summary>
    /// Test methods for the vector class.
    /// </summary>
    /// <typeparam name="T">The set,</typeparam>
    /// <typeparam name="TStruct>The structure.</typeparam>
    [TestFixture(typeof(Double), typeof(DoubleMonoid))]
    [TestFixture(typeof(Complex), typeof(ComplexMonoid))]
    public class VectorTestTemplate<T, TStruct> 
        where T : new() where TStruct : IStructure<T>, new()
    {
        #region fields

        #endregion

        #region properties

        #endregion

        #region methods

        /// <summary>
        /// Initializes the check dimension equals given dimension.
        /// </summary>
        /// <param name="givenDimension">The dimension.</param>
        [Test]
        [TestCase((UInt32)2)]
        [TestCase((UInt32)6)]
        public void Initialize_CheckDimension_EqualsGivenDimension(UInt32 givenDimension)
        {
            var vec = new Vector<T, TStruct>(givenDimension);
            Assert.IsNotNull(vec);

            Assert.AreEqual(givenDimension, vec.Dimension);
        }

        /// <summary>
        /// Indexers the setting to high dimension throws vector exception.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="index">The index.</param>
        [Test]
        [TestCase((UInt32)2, (UInt32)4)]
        [TestCase((UInt32)1, (UInt32)4)]
        public void Indexer_SettingToHighDimension_ThrowsVectorException(UInt32 dimension, UInt32 index)
        {
            var value = default(T);
            var vec = new Vector<T, TStruct>(dimension);
            Assert.IsNotNull(vec);

            Assert.Throws<VectorException>(() => vec[index] = value);
        }

        #endregion
    }
}