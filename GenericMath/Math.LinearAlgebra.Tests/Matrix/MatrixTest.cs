//  *************************************************************
// <copyright file="MatrixTest.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  11 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Matrix test.
    /// </summary>
    [TestFixture]
    public class MatrixTest
    {
        #region METHODS

        /// <summary>
        /// Tests the double matrix.
        /// </summary>
        [Test]
        public void TestDoubleMatrix()
        {
            var mat = CreateDoubleMatrix();
            Assert.AreEqual(0.2, mat[0, 1]);

            var scalarMat = mat.ScalarMultiply(2.0);
            Assert.AreEqual(2.4, scalarMat[0, 0]);

            var oneMat = new SpecialMatrices().OneMatrix<Double>(2);
            Assert.AreEqual(2, oneMat.Trace());

            var transMatrix = mat.Transpose();
            Assert.AreEqual(mat[1, 0], transMatrix[0, 1]);
            Assert.AreEqual(mat[0, 1], transMatrix[1, 0]);

            // test vector multiplication
            var zeroVect = new SpecialVectors().ZeroVector<Double>(3);
            var zeroMat = new SpecialMatrices().ZeroMatrix<Double>(2, 1);
            Assert.AreEqual(zeroMat[0], mat.MultiplyVector(zeroVect));

            // test matrix multiplication
            var zeroMat2 = new SpecialMatrices().ZeroMatrix<Double>(3, 1);
            var res = mat.MultiplyMatrix(zeroMat2);
            Assert.AreEqual(zeroMat, res);
        }

        /// <summary>
        /// Tests the integer matrix.
        /// </summary>
        [Test]
        public void TestIntegerMatrix()
        {
            var mat = CreateIntegerMatrix();
            Assert.AreEqual(2, mat[0, 1]);

            Assert.AreEqual(21, mat.SumElements());
        }

        #endregion

        #region HELPER METHODS

        Matrix<Double> CreateDoubleMatrix()
        {
            var mat = new Matrix<Double>(2, 3);
            mat[0, 0] = 1.2;
            mat[0, 1] = 0.2;
            mat[0, 2] = 0.1;
            mat[1, 0] = 4.2;
            mat[1, 1] = 3.2;
            mat[1, 2] = 3.2;

            return mat;
        }

        Matrix<Int32> CreateIntegerMatrix()
        {
            var mat = new Matrix<Int32>(2, 3);
            mat[0, 0] = 1;
            mat[0, 1] = 2;
            mat[0, 2] = 3;
            mat[1, 0] = 4;
            mat[1, 1] = 5;
            mat[1, 2] = 6;

            return mat;
        }

        VectorFromEuclidianRing<Int32> CreateIntVector()
        {
            var vec = new VectorFromEuclidianRing<Int32>(2);
            vec[0] = 1;
            vec[1] = 4;

            return vec;
        }

        #endregion
    }
}