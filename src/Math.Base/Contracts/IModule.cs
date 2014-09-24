﻿//  *************************************************************
// <copyright file="IModule.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    /// <summary>
    /// Interface for the module structure.
    /// </summary>
    /// <typeparam name="TR">the set of the underlying ring.</typeparam>
    /// <typeparam name="TRing">The ring structure.</typeparam>
    /// <typeparam name="TG">The set of the underlying group.</typeparam>
    /// <typeparam name="TGroup">The group structure</typeparam>
    public interface IModule<TR, TRing, TG, TGroup> 
        where TRing : IRing<TR>
        where TGroup : IGroup<TG>
    {
        /// <summary>
        /// Scalar multiplication of the group element with the scalar from the ring.
        /// </summary>
        /// <returns>The multiply.</returns>
        /// <param name="scalar">The scalar.</param>
        /// <param name="groupElement">Group element.</param>
        TG ScalarMultiply(TRing scalar, TGroup groupElement);
    }
}