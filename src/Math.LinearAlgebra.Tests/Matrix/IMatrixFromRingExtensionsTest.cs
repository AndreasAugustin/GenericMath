//  *************************************************************
// <copyright file="IMatrixFromRingExtensionsTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  19 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the extension methods for IMatrix with underlying Ring as structure.
    /// </summary>
    [TestFixture]
    public class IMatrixFromRingExtensionsTest
    {
        #region fields

        FakeMatrixTestDataSource _mockDataSource;

        #endregion

        #region properties

        FakeMatrixTestDataSource MockDataSource
        {
            get
            {
                return _mockDataSource ?? (_mockDataSource = new FakeMatrixTestDataSource());
            }
        }

        #endregion

        #region methods

        #endregion
    }
}