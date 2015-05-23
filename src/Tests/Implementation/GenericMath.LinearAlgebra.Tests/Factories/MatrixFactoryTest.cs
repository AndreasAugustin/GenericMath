// *************************************************************
// <copyright file="MatrixFactoryTest.cs" company="None">
//      Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>AndreasAugustin</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************


namespace GenericMath.LinearAlgebra.Tests
{
    using System;

    using GenericMath.Base;
    using GenericMath.LinearAlgebra.Contracts;
    using NUnit.Framework;

    /// <summary>
    /// Test for the <see cref="MatrixFactory"/> class.
    /// </summary>
    [TestFixture]
    public class MatrixFactoryTest
    {
        #region properties

        private IMatrixFactory Factory
        {
            get
            {
                var fact = new MatrixFactory();
                fact.Register<double, DoubleField, Matrix<double,DoubleField>>((row, col) => new Matrix<double, DoubleField>(row, col));


                return fact;
            }
        }

        #endregion

        #region methods

        [Test]
        public void Ctor_CreateInstance_IsNotNull ()
        {
            var obj = new MatrixFactory();

            Assert.That(obj, Is.Not.Null);
        }

        [Test]
        public void Register_RegisterFunc_DoewNotThrow ()
        {
            var fact = new MatrixFactory();
            fact.Register<double, DoubleField, Matrix<double,DoubleField>>((row, col) => new Matrix<double, DoubleField>(row, col));
        }

        [Test]
        public void GetNewInstance ()
        {
            var fact = this.Factory;
            var inst = fact.GetNewInstance<double, DoubleField, Matrix<double,DoubleField>>(1, 2);

            Assert.That(inst, Is.InstanceOf<Matrix<double,DoubleField>>());
            Assert.That(inst.RowDimension, Is.EqualTo(1));
            Assert.That(inst.ColumnDimension, Is.EqualTo(2));
        }

        #endregion
    }
}
