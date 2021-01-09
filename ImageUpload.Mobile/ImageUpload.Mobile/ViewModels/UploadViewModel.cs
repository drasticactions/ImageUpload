// <copyright file="UploadViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Drastic.Common.Interfaces;
using Drastic.Common.Tools;
using Drastic.Common.ViewModels;
using ImageUpload.Mobile.Interfaces;
using ImageUpload.Mobile.Pages;
using ImageUpload.Mobile.Views;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Imgur.API.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ImageUpload.Mobile.ViewModels
{
    public class UploadViewModel : BaseViewModel
    {
        private AsyncCommand uploadImageCommand;
        private ImageEndpoint client;
        private ImageUpload.Mobile.Interfaces.IPopup popup;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadViewModel"/> class.
        /// </summary>
        /// <param name="popup">Popup.</param>
        /// <param name="client">API Client.</param>
        /// <param name="properties">Platform Properties.</param>
        /// <param name="resource">Resources.</param>
        /// <param name="database">Database.</param>
        /// <param name="error">Error Handler.</param>
        /// <param name="navigation">Navigation Handler.</param>
        public UploadViewModel(ImageUpload.Mobile.Interfaces.IPopup popup, ImageEndpoint client, IPlatformProperties properties, IResourceHelper resource, IDatabase database, IErrorHandler error, INavigationHandler navigation)
            : base(properties, resource, database, error, navigation)
        {
            this.popup = popup;
            this.client = client;
        }

        /// <summary>
        /// Gets the login command.
        /// </summary>
        public AsyncCommand UploadImageCommand
        {
            get
            {
                return this.uploadImageCommand ??= new AsyncCommand(this.UploadImageAsync, null, this.Error);
            }
        }

        private async Task UploadImageAsync()
        {
            IImage imageUpload;
            var image = await this.PlatformProperties.PickImageAsync().ConfigureAwait(false);
            if (image == null)
            {
                return;
            }

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                using (Forms9Patch.ActivityIndicatorPopup.Create())
                {
                    imageUpload = await this.client.UploadImageAsync(image).ConfigureAwait(false);
                    this.Database.SaveImage(imageUpload);
                }

                if (imageUpload == null)
                {
                    return;
                }

                this.popup.SetContent(new ImgurView(imageUpload, this.Navigation), true);
            });
        }
    }
}
