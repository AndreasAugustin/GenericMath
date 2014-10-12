//  *************************************************************
// <copyright file="IVectorRoom.cs" company="SuperDevelop">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 8 / 2014 Created the Class
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