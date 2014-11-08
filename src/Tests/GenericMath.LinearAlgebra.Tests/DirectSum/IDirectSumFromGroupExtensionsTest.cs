//  *************************************************************
// <copyright file="IDirectSumFromGroupExtensionsTest.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra.Tests
{
    using System.Collections.Generic;
    using System.Numerics;

    using GenericMath.Base;
    using NUnit.Framework;

    /// <summary>
    /// Test methods for the extension methods for IDirectSum with groups as structure.
    /// Underlying class is <see cref="IDirectSumFromGroupExtensions"/>.
    /// </summary>
    [TestFixture]
    public class IDirectSumFromGroupExtensionsTest
    {
        #region fields

        private FakeDirectSumTestDataSource _mockDirectSumTestDataSource;

        #endregion

        #region properties

        private FakeDirectSumTestDataSource MockDirectSumTestDataSource
        {
            get
            {
                return this._mockDirectSumTestDataSource ?? (this._mockDirectSumTestDataSource = new FakeDirectSumTestDataSource());
            }
        }

        private IEnumerable<TestCaseData> DirectSumInverseElementTestDataSource
        {
            get
            {
                yield return new TestCaseData(
                    0,
                    new Int32Group(),
                    this.MockDirectSumTestDataSource.GroupInt32IDirectSumSource);
                yield return new TestCaseData(
                    3.678,
                    new DoubleField(),
                    this.MockDirectSumTestDataSource.FieldDoubleIDirectSumSource);
                yield return new TestCaseData(
                    new Complex(5, 58),
                    new ComplexRing(),
                    this.MockDirectSumTestDataSource.RingComplexIDirectSumSource);
            }
        }

        #endregion

        /// <summary>
        /// Tests the inverting of an element.
        /// </summary>
        /// <param name="hackForGenericParameter">Hack for generic parameter.</param>
        /// <param name="underlyingGroup">Underlying group.</param>
        /// <param name="tuple">The Tuple.</param>
        /// <typeparam name="T">The underlying set.</typeparam>
        /// <typeparam name="TGroup">The underlying group.</typeparam>
        [Test]
        [Category("DirectSumTest")]
        [TestCaseSource("DirectSumInverseElementTestDataSource")]
        public void InverseElement<T, TGroup>(
            T hackForGenericParameter, 
            TGroup underlyingGroup, 
            IDirectSum<T, TGroup> tuple)
            where TGroup : IGroup<T>, new()
        {
            var inverseElement = tuple.InverseElement();

            Assert.IsNotNull(inverseElement);

            Assert.AreEqual(tuple.Dimension, inverseElement.Dimension);

            for (uint i = 0; i < tuple.Dimension; i++)
            {
                var expectedInverse = underlyingGroup.Inverse(tuple[i]);
                Assert.AreEqual(expectedInverse, inverseElement[i]);
            }
        }
    }
}