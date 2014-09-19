//  *************************************************************
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
    /// <typeparam></typeparam>
    public interface IModule<TR, TRing, TG, TGroup> 
        where TRing : IRing<TR>
        where TGroup : IGroup<TG>
    {
        /// <summary>
        /// Scalarmultiplication of the group element with the scalar from the ring.
        /// </summary>
        /// <returns>The multiply.</returns>
        /// <param name="scalar">Scalar.</param>
        /// <param name="groupElement">Group element.</param>
        TG ScalarMultiply(TRing scalar, TGroup groupElement);
    }
}