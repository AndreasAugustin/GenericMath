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
    using System.Collections.Generic;

    using GenericMath.Base;
    using GenericMath.Base.Contracts;
    using GenericMath.LinearAlgebra.Contracts;
    using NUnit.Framework;

    /// <summary>
    /// Test for the <see cref="MatrixFactory"/> class.
    /// </summary>
    [TestFixture(typeof(double), typeof(DoubleField), typeof(Matrix<double, DoubleField>))]
    public class MatrixFactoryTest<TSet, TStructure, TMatrix>
        where TStructure : IStructure, new()
        where TMatrix: Matrix<TSet, TStructure>
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

        #region test sources

        private IEnumerable<TestCaseData> RegisterTestSource
        {
            get
            {
                yield return new TestCaseData((Func<uint, uint, Matrix<double, DoubleField>>)((row, col) => new Matrix<double, DoubleField>(row, col)));
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
        [TestCaseSource("RegisterTestSource")]
        public void Register_RegisterFunc_DoesNotThrow (Func<uint, uint, Matrix<double, DoubleField>> exp)
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
