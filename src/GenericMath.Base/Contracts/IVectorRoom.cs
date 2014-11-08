//  *************************************************************
// <copyright file="IVectorRoom.cs" company="None">
//     Copyright (c) 2014 andy.  All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base
{
    /// <summary>
    /// Interface for vector rooms.
    /// </summary>
    /// <typeparam name="TF">The underlying set of the field.</typeparam>
    /// <typeparam name="TField">The underlying structure of the field.</typeparam>
    /// <typeparam name="TG">The underlying set of the group.</typeparam>
    /// <typeparam name="TGroup">The underlying structure of the group.</typeparam>
    public interface IVectorRoom<TF, TField, TG, TGroup> : IModule<TF, TField, TG, TGroup>
        where TField : IField<TF>
        where TGroup : IGroup<TG>
    {
        // TODO implement
    }
}