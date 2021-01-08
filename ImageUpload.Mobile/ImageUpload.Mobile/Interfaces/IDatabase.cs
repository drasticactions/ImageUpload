// <copyright file="IDatabase.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using ImageUpload.Mobile.Entities.Settings;

namespace ImageUpload.Mobile.Interfaces
{
    /// <summary>
    /// IDatabase.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Gets app settings.
        /// </summary>
        /// <returns>App Settings.</returns>
        AppSettings GetAppSettings();

        /// <summary>
        /// Save App Settings.
        /// </summary>
        /// <param name="appSettings">App Settings.</param>
        /// <returns>Bool if saved.</returns>
        bool SaveAppSettings(AppSettings appSettings);
    }
}
