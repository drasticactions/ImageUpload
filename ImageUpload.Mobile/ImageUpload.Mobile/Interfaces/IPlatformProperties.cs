// <copyright file="IPlatformProperties.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Drastic.Common.Interfaces
{
    /// <summary>
    /// Platform Properties.
    /// </summary>
    public interface IPlatformProperties
    {
        /// <summary>
        /// Gets a value indicating whether the current platform is running a system level dark theme.
        /// </summary>
        bool IsDarkTheme { get; }

        /// <summary>
        /// Gets the path to where the local app area path is stored.
        /// </summary>
        string LocalAppAreaPath { get; }

        /// <summary>
        /// Gets an image from the system.
        /// </summary>
        /// <returns>Stream.</returns>
        Task<Stream> PickImageAsync();
    }
}
