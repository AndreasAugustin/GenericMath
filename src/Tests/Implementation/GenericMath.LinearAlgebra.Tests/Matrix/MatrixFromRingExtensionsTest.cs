//  *************************************************************
// <copyright file="IMatrixFromRingExtensionsTest.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using GenericMath.Base;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the extension methods for IMatrix with underlying Ring as structure.
    /// </summary>
    [TestFixture]
    public class IMatrixFromRingExtensionsTest
    {
        #region fields

        private FakeMatrixTestDataSource _mockDataSource;

        #endregion

        #region properties

        private FakeMatrixTestDataSource MockDataSource
        {
            get
            {
                return this._mockDataSource ?? (this._mockDataSource = new FakeMatrixTestDataSource());
            }
        }

        #endregion

        #region methods

        #endregion
    }
}