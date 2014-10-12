//  *************************************************************
// <copyright file="FakeDirectSumTestDataSource.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
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

        private List<int> _int32List;
        private List<double> _doubleList;
        private List<Complex> _complexList;

        #endregion

        #region properties

        /// <summary>
        /// Gets the double list.
        /// </summary>
        /// <value>The double list.</value>
        public List<double> DoubleList
        {
            get
            {
                return this._doubleList ?? (this._doubleList = new List<Double>{ 3.678 });
            }
        }

        /// <summary>
        /// Gets the complex list.
        /// </summary>
        /// <value>The complex list.</value>
        public List<Complex> ComplexList
        {
            get
            {
                return this._complexList ?? (this._complexList = new List<Complex>
                { 
                    new Complex(1, 2),
                    new Complex(4, 56)
                });
            }
        }

        /// <summary>
        /// Gets the integer list.
        /// </summary>
        /// <value>The integer list.</value>
        public List<int> Int32List
        {
            get
            {
                return this._int32List ?? (this._int32List = new List<int>{ 2, -2 });
            }
        }

        /// <summary>
        /// Gets the group integer I direct sum source.
        /// </summary>
        /// <value>The group integer I direct sum source.</value>
        public IDirectSum<int, Int32Group> GroupInt32IDirectSumSource
        {
            get
            {     
                var dimension = (uint)this.Int32List.Count;
                var tuple = new DirectSum<int, Int32Group>(dimension);

                for (uint i = 0; i < dimension; i++)
                {
                    tuple[i] = this.Int32List[(int)i];
                }

                return tuple;
            }
        }

        /// <summary>
        /// Gets the ring integer I direct sum source.
        /// </summary>
        /// <value>The ring integer I direct sum source.</value>
        public IDirectSum<int, Int32Ring> RingInt32IDirectSumSource
        {
            get
            {               
                var dimension = (uint)this.Int32List.Count;
                var tuple = new DirectSum<int, Int32Ring>(dimension);

                for (uint i = 0; i < dimension; i++)
                {
                    tuple[i] = this.Int32List[(int)i];
                }

                return tuple;
            }
        }

        /// <summary>
        /// Gets the ring complex I direct sum source.
        /// </summary>
        /// <value>The ring complex I direct sum source.</value>
        public IDirectSum<Complex, ComplexRing> RingComplexIDirectSumSource
        {
            get
            {
                var dimension = (uint)this.ComplexList.Count;
                var tuple = new DirectSum<Complex, ComplexRing>(dimension);

                for (uint i = 0; i < dimension; i++)
                {
                    tuple[i] = this.ComplexList[(int)i];
                }

                return tuple;
            }
        }

        /// <summary>
        /// Gets the field double I direct sum source.
        /// </summary>
        /// <value>The field double I direct sum source.</value>
        public IDirectSum<double, DoubleField> FieldDoubleIDirectSumSource
        {
            get
            {
                var dimension = (uint)this.DoubleList.Count;
                var tuple = new DirectSum<double, DoubleField>(dimension);

                for (uint i = 0; i < dimension; i++)
                {
                    tuple[i] = this.DoubleList[(int)i];
                }

                return tuple;
            }
        }

        #endregion
    }
}