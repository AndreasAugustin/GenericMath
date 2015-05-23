// *************************************************************
// <copyright file="StructureFactoryTest.cs" company="None">
//      Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>AndreasAugustin</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base.Tests
{
    using System;
    using GenericMath.Base.Contracts;
    using System.Collections.Generic;

    using NUnit.Framework;

    /// <summary>
    /// Test for the <see cref="StructureFactory"/> class.
    /// </summary>
    [TestFixture]
    public class StructureFactoryTest
    {
        #region fields

        DoubleField _doubleField = new DoubleField();
        ComplexGroup _complexGroup = new ComplexGroup();

        #endregion

        #region properties

        private IStructureFactory StructureFactory
        {
            get
            {
                var fact = new StructureFactory();

                fact.RegisterInstance(this._doubleField);
                fact.RegisterInstance(this._complexGroup);

                return fact;
            }
        }

        #endregion

        #region testCaseSources

        private IEnumerable<TestCaseData> UnregisteredTestSource
        {
            get
            {
                yield return new TestCaseData(new DoubleField()).Throws(typeof(UnregisteredException));
                yield return new TestCaseData(new ComplexRing()).Throws(typeof(UnregisteredException));
            }
        }

        private IEnumerable<TestCaseData> RegisterTestSource
        {
            get
            {
                yield return new TestCaseData(new DoubleField());
                yield return new TestCaseData(new ComplexRing());
            }
        }

        private IEnumerable<TestCaseData> GetInstanceTestSource
        {
            get
            {
                yield return new TestCaseData(new DoubleField()).Returns(typeof(DoubleField));
                yield return new TestCaseData(new ComplexGroup()).Returns(typeof(ComplexGroup));
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Tests the object creation.
        /// </summary>
        [Test]
        public void Ctor_CreateInstance_IsNotNull ()
        {
            var obj = new StructureFactory();
            Assert.That(obj, Is.Not.Null);
        }

        /// <summary>
        /// Checks if the right exception is thrown when the type is not registered yet.
        /// </summary>
        /// <param name="hackForGeneric">Hack to be able to run a generic test.</param>
        /// <typeparam name="TStruct">The structure.</typeparam>
        [Test]
        [TestCaseSource("UnregisteredTestSource")]
        public void GetInstance_InstanceNotRegistered_GetUnregisteredException<TStruct> (TStruct hackForGeneric)
            where TStruct : IStructure
        {
            var fact = new StructureFactory();
            fact.GetInstance<TStruct>();
        }

        /// <summary>
        /// Registers an instance and does not throw an exception.
        /// </summary>
        /// <param name="structure">Structure.</param>
        /// <typeparam name="TStruct">The 1st type parameter.</typeparam>
        [Test]
        [TestCaseSource("RegisterTestSource")]
        public void RegisterInstance_DoesNotThrow<TStruct> (TStruct structure)
            where TStruct : IStructure, new()
        {
            var fact = new StructureFactory();
            Assert.That(() => fact.RegisterInstance<TStruct>(structure), Throws.Nothing);
        }

        /// <summary>
        /// Gets the instance gets registered isntance equals expected.
        /// </summary>
        /// <param name="hackForGeneric">Hack for generic.</param>
        /// <typeparam name="TStruct">The 1st type parameter.</typeparam>
        [Test]
        [TestCaseSource("GetInstanceTestSource")]
        public Type GetInstance_GetsRegisteredIsntance_EqualsExpected<TStruct> (TStruct hackForGeneric)
            where TStruct : IStructure, new()
        {
            var result = this.StructureFactory.GetInstance<TStruct>();

            return result.GetType();
        }

        #endregion
    }
}
