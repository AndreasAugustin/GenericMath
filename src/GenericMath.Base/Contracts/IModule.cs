//  *************************************************************
// <copyright file="IModule.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base
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