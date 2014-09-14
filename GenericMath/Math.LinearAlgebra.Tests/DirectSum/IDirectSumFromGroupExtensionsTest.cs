//  *************************************************************
// <copyright file="IDirectSumFromGroupExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  10 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    /// <summary>
    /// Test methods for the extesnion methods for IDirectSum with groups as strucure.
    /// Underlying class is <see cref="IDirectSumFromGroupExtensions"/>.
    /// </summary>
    [TestFixture]
    public class IDirectSumFromGroupExtensionsTest
    {
        #region fields

        FakeDirectSumTestDataSource _mockDirectSumTestDataSource;

        #endregion

        #region properties

        FakeDirectSumTestDataSource MockDirectSumTestDataSource
        {
            get
            {
                return _mockDirectSumTestDataSource ?? (_mockDirectSumTestDataSource = new FakeDirectSumTestDataSource());
            }
        }

        IEnumerable<TestCaseData> DirectSumInverseElementTestDataSource
        {
            get
            {
                yield return new TestCaseData(0, new Int32Group(), MockDirectSumTestDataSource.GroupInt32IDirectSumSource);
                yield return new TestCaseData(3.678, new DoubleField(), MockDirectSumTestDataSource.FieldDoubleIDirectSumSource);
                yield return new TestCaseData(new Complex(5, 58), new ComplexRing(), MockDirectSumTestDataSource.RingComplexIDirectSumSource);
            }
        }

        #endregion

        /// <summary>
        /// Tests the InverseElement Method.
        /// </summary>
        [Test]
        [Category("DirectSumTest")]
        [TestCaseSource("DirectSumInverseElementTestDataSource")]
        public void InverseElement<T, TGroup>(T hackForGenericParameter, TGroup underlyingGroup, 
                                              IDirectSum<T, TGroup> tuple)
            where TGroup : IGroup<T>, new()
        {
            var inverseElement = tuple.InverseElement();

            Assert.IsNotNull(inverseElement);

            Assert.AreEqual(tuple.Dimension, inverseElement.Dimension);

            for (UInt32 i = 0; i < tuple.Dimension; i++)
            {
                var expectedInverse = underlyingGroup.Inverse(tuple[i]);
                Assert.AreEqual(expectedInverse, inverseElement[i]);
            }
        }
    }
}