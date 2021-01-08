// <copyright file="IResourceHelper.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Drastic.Common.Interfaces
{
    /// <summary>
    /// Resource Helper.
    /// </summary>
    public interface IResourceHelper
    {
        /// <summary>
        /// Set a dynamic resource.
        /// </summary>
        /// <param name="targetResourceName">Target Resource.</param>
        /// <param name="sourceResourceName">Value to change to.</param>
        public void SetDynamicResource(string targetResourceName, string sourceResourceName);

        /// <summary>
        /// Set a dynamic resource.
        /// </summary>
        /// <typeparam name="T">Type Value.</typeparam>
        /// <param name="targetResourceName">Target Resource.</param>
        /// <param name="value">Value to change to.</param>
        public void SetDynamicResource<T>(string targetResourceName, T value);

        /// <summary>
        /// Get Dynamic Resource.
        /// </summary>
        /// <param name="sourceResourceName">Resource Name.</param>
        /// <returns>Resource.</returns>
        public object GetDynamicResource(string sourceResourceName);

        /// <summary>
        /// Sets application to dark mode.
        /// </summary>
        public void SetDarkMode();

        /// <summary>
        /// Sets application to light mode.
        /// </summary>
        public void SetLightMode();

        /// <summary>
        /// Sets application to custom theme.
        /// </summary>
        /// <param name="customTheme">The custom theme enum.</param>
        public void SetCustomTheme(object customTheme);
    }
}
