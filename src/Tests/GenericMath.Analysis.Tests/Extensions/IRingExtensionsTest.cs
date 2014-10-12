//  *************************************************************
// <copyright file="IRingExtensionsTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  11 / 8 / 2014 Created the Class
// *************************************************************

namespace GenericMath.Analysis.Tests
{
    using System;

    using GenericMath.Base;
    using NUnit.Framework;

    /// <summary>
    /// Test for the IRing extensions.
    /// </summary>
    [TestFixture]
    public class IRingExtensionsTest
    {
        /// <summary>
        /// Tests the addition extension.
        /// </summary>
        [Test]
        public void Multiplication()
        {
            var ring = new Int32Ring();
            Func<Int32, Int32, Int32> func1 = ring.Multiplication; 
            Func<Int32, Int32, Int32> func2 = ring.Multiplication;
         
            var calc = ring.Multiplication(func1, func2);

            Assert.NotNull(calc);
            Assert.AreEqual(1, calc(1, 1));
        }
    }
}