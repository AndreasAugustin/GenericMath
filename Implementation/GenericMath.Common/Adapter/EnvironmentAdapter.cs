﻿//  *************************************************************
// <copyright file="EnvironmentAdapter.cs" company="None">
//     Copyright (c) 2014 andy. All rights reserved.
// </copyright>
// <license>MIT Licence</license>
// <author>andy</author>
// <email>andy.augustin@t-online.de</email>
// *************************************************************
using GenericMath.Common.Contracts;

namespace GenericMath.Common
{
	using System;

	/// <summary>
	/// Adapter for the <see cref="Environment"/> class.
	/// </summary>
	public class EnvironmentAdapter : IEnvironment
	{
		#region IEnvironment implementation

		/// <summary>
		/// Gets the new line.
		/// </summary>
		/// <value>The new line.</value>
		public String NewLine
		{
			get
			{
				return Environment.NewLine;
			}
		}

		#endregion
	}
}