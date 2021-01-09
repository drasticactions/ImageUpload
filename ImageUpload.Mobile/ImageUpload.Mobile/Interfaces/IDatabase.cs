// <copyright file="IDatabase.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System.Collections.Generic;
using ImageUpload.Mobile.Entities.Settings;
using Imgur.API.Models;

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

        /// <summary>
        /// Saves Image.
        /// </summary>
        /// <param name="image">Image.</param>
        /// <returns>Bool if saved.</returns>
        bool SaveImage(IImage image);

        /// <summary>
        /// Saves Images.
        /// </summary>
        /// <param name="images">Images.</param>
        /// <returns>Number of rows changed.</returns>
        int SaveImages(List<IImage> images);

        /// <summary>
        /// Gets images.
        /// </summary>
        /// <returns>Images.</returns>
        IEnumerable<IImage> GetImages();
    }
}
