//  *************************************************************
// <copyright file="RingFactoryTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  18 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using NUnit.Framework;

    /// <summary>
    /// Ring factory test.
    /// </summary>
    [TestFixture]
    public class RingFactoryTest
    {
        #region fields

        RingFactory _ringFactory;

        #endregion

        #region properties

        RingFactory RingFactory
        {
            get { return _ringFactory ?? (this._ringFactory = new RingFactory()); }
        }

        IEnumerable<TestCaseData> SelectTestDataSource
        {
            get
            {
                yield return new TestCaseData(new DoubleRing());
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Checks the ring.
        /// </summary>
        /// <param name="genericForMethodCall">The generic type for the method call.</param>
        /// <param name="expectedRing">The expected group.</param>      
        [Category("RingTest")]
        [Test]
        [TestCase(typeof(Double), typeof(DoubleRing))]
        [TestCase(typeof(Complex), typeof(ComplexRing))]
        [TestCase(typeof(Int32), typeof(Int32Ring))]
        public void SelectRing_IsInstanceOf(Type genericForMethodCall, Type expectedRing)
        {
            var methodInfo = typeof(RingFactory).GetMethod("SelectRing").MakeGenericMethod(genericForMethodCall);
            var ring = methodInfo.Invoke(RingFactory, null);

            Assert.IsInstanceOf(expectedRing, ring);
        }

        /// <summary>
        /// Tests what happens if the type is not registered in the factory.
        /// </summary>
        /// <exception cref="NotSupportedException">This exception should be thrown.</exception>
        [Test]
        [Category("RingTest")]
        public void SelectRing_NotSupported_ThrowsNotSupportedException()
        {
            var message = String.Format("The struct type {0} is not supported (yet)", typeof(Object));
            var ex = Assert.Catch<NotSupportedException>(() => RingFactory.SelectRing<Object>());

            StringAssert.Contains(message, ex.Message);
        }

        #endregion
    }
}