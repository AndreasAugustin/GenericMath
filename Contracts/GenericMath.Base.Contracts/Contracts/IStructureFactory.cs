// *************************************************************
// <copyright file="IStructureFactory.cs" company="None">
//      Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>AndreasAugustin</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************

namespace GenericMath.Base.Contracts
{
    /// <summary>
    /// Interface for the structure factory.
    /// </summary>
    public interface IStructureFactory : IFactoryMarker
    {
        #region methods

        /// <summary>
        /// Gets the registered instance.
        /// </summary>
        /// <returns>The instance.</returns>
        /// <typeparam name="TStruct">The structure to register.</typeparam>
        /// <exception cref="UnregisteredException">Thrown when the instance 
        /// <typeparamref>TStruct</typeparamref> is not registered yet.
        /// </exception>
        TStruct GetInstance<TStruct> () where TStruct : IStructure;

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <param name="structure">Structure.</param>
        /// <typeparam name="TStruct">The 1st type parameter.</typeparam>
        void RegisterInstance<TStruct> (TStruct structure) where TStruct : IStructure, new();

        #endregion
    }
}

