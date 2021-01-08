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
using Xamarin.Forms;

namespace ImageUpload.Mobile.ViewModels
{
    public class UploadViewModel : BaseViewModel
    {
        private AsyncCommand uploadImageCommand;
        private ApiClient client;
        private HttpClient httpClient;

        public UploadViewModel(ApiClient client, IPlatformProperties properties, IResourceHelper resource, IDatabase database, IErrorHandler error, INavigationHandler navigation)
            : base(properties, resource, database, error, navigation)
        {
            this.client = client;
            this.httpClient = new HttpClient();
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
            var image = await this.PlatformProperties.PickImageAsync().ConfigureAwait(false);
            if (image == null)
            {
                return;
            }

            var imageEndpoint = new ImageEndpoint(this.client, this.httpClient);
            var imageUpload = await imageEndpoint.UploadImageAsync(image).ConfigureAwait(false);
            await this.Navigation.PushModalPageAsync(new ImgurPage(imageUpload)).ConfigureAwait(false);
        }
    }
}
