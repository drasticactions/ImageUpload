// <copyright file="WindowsPlatformProperties.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drastic.Common.Interfaces;
using ImageUpload.Mobile.Tools;
using Xamarin.Essentials;

namespace Drastic.Forms.UWP
{
    /// <summary>
    /// Windows Platform Properties.
    /// </summary>
    public class WindowsPlatformProperties : IPlatformProperties
    {
        /// <inheritdoc/>
        public bool IsDarkTheme
        {
            get
            {
                var uiSettings = new Windows.UI.ViewManagement.UISettings();
                var color = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Background).ToString(System.Globalization.CultureInfo.InvariantCulture);
                return color switch
                {
                    "#FF000000" => true,
                    "#FFFFFFFF" => false,
                    _ => false,
                };
            }
        }

        /// <inheritdoc/>
        public string LocalAppAreaPath => System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData));

        /// <inheritdoc/>
        public Task<Stream> PickImageAsync()
        {
            var tcs = new TaskCompletionSource<Stream>();
            MainThread.BeginInvokeOnMainThread(async () => {
                var picker = new Windows.Storage.Pickers.FileOpenPicker
                {
                    ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                    SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary,
                };

                foreach (var ext in ImageUploadFileExtensions.ImageExtensions)
                {
                    picker.FileTypeFilter.Add(ext);
                }

                Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
                if (file == null)
                {
                    tcs.SetResult(null);
                    return;
                }

                var token = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(file);
                var fileStream = await file.OpenStreamForReadAsync().ConfigureAwait(false);
                tcs.SetResult(fileStream);
            });
            return tcs.Task;
        }
    }
}
