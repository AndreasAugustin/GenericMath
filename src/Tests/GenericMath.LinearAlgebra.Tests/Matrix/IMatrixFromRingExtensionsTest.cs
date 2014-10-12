//  *************************************************************
// <copyright file="IMatrixFromRingExtensionsTest.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author>andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  19 / 9 / 2014 Created the Class
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