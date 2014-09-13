//  *************************************************************
// <copyright file="FakeTestDataSource.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  13 / 9 / 2014 Created the Class
// *************************************************************

namespace Math.LinearAlgebra.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    using Math.Base;

    /// <summary>
    /// Contains data source for the direct sum tests.
    /// </summary>
    public class FakeDirectSumTestDataSource
    {
        #region fields

        List<Int32> _int32List;
        List<Double> _doubleList;
        List<Complex> _complexList;

        #endregion

        #region properties

        public List<Double> DoubleList
        {
            get
            {
                return _doubleList ?? (_doubleList = new List<Double>{ 3.678 });
            }
        }

        public List<Complex> ComplexList
        {
            get
            {
                return _complexList ?? (_complexList = new List<Complex>{ new Complex(1, 2), new Complex(4, 56) });
            }
        }

        public List<Int32> Int32List
        {
            get
            {
                return _int32List ?? (_int32List = new List<int>{ 2, -2 });
            }

        }

        public IDirectSum<Int32, Int32Group> GroupInt32IDirectSumSource
        {
            get
            {               
                var dimension = (UInt32)Int32List.Count;
                var vector = new DirectSum<Int32, Int32Group>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = Int32List[(Int32)i];
                }

                return vector;
            }
        }

        public IDirectSum<Complex, ComplexRing> RingComplexIDirectSumSource
        {
            get
            {
                var dimension = (UInt32)ComplexList.Count;
                var vector = new DirectSum<Complex, ComplexRing>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = ComplexList[(Int32)i];
                }

                return vector;
            }
        }

        public IDirectSum<Double, DoubleField> FieldDoubleIDirectSumSource
        {
            get
            {
                var dimension = (UInt32)DoubleList.Count;
                var vector = new DirectSum<Double, DoubleField>(dimension);

                for (UInt32 i = 0; i < dimension; i++)
                {
                    vector[i] = DoubleList[(Int32)i];
                }

                return vector;
            }
        }

        #endregion
    }
}