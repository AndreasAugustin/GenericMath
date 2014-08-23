//  *************************************************************
// <copyright file="GroupFactoryTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  15 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base.Tests
{
    using System;
    using System.Numerics;
    using System.Reflection;

    using NUnit.Framework;

    /// <summary>
    /// Group factory test.
    /// </summary>
    [TestFixture]
    public class GroupFactoryTest
    {
        #region fields

        GroupFactory _groupFactory;

        #endregion

        #region properties

        GroupFactory GroupFactory
        {
            get
            {
                return _groupFactory ?? (_groupFactory = new GroupFactory());
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Gets the double group.
        /// </summary>
        /// <param name="genericForMethodCall">The generic type for the method call.</param>
        /// <param name="expectedGroup">The expected group.</param>      
        [Category("GroupTest")]
        [Test]
        [TestCase(typeof(Double), typeof(DoubleGroup))]
        [TestCase(typeof(Complex), typeof(ComplexGroup))]
        [TestCase(typeof(Int32), typeof(Int32Group))]
        public void SelectGroup_IsInstanceOf(Type genericForMethodCall, Type expectedGroup)
        {
            var methodInfo = typeof(GroupFactory).GetMethod("SelectGroup").MakeGenericMethod(genericForMethodCall);
            var group = methodInfo.Invoke(GroupFactory, null);

            Assert.IsInstanceOf(expectedGroup, group);
        }

        /// <summary>
        /// Tests what happens if the type is not registered in the factory.
        /// </summary>
        /// <exception cref="NotSupportedException">This exception should be thrown.</exception>
        [Test]
        [Category("GroupTest")]
        public void SelectGroup_NotSupported_ThrowsNotSupportedException()
        {
            var message = String.Format("The struct type {0} is not supported (yet)", typeof(Object));
            var ex = Assert.Catch<NotSupportedException>(() => GroupFactory.SelectGroup<Object>());

            StringAssert.Contains(message, ex.Message);
        }

        #endregion
    }
}