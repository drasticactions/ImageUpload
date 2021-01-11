// <copyright file="ImageGalleryViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Drastic.Common.Interfaces;
using Drastic.Common.Tools;
using Drastic.Common.ViewModels;
using ImageUpload.Mobile.Interfaces;
using ImageUpload.Mobile.Views;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Imgur.API.Models;
using Xamarin.Essentials;

namespace ImageUpload.Mobile.ViewModels
{
    /// <summary>
    /// Image Gallery View Model.
    /// </summary>
    public class ImageGalleryViewModel : BaseViewModel
    {
        private ImageEndpoint client;
        private ImageUpload.Mobile.Interfaces.IPopup popup;
        private AsyncCommand<IImage> viewImageCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageGalleryViewModel"/> class.
        /// </summary>
        /// <param name="popup">Popup.</param>
        /// <param name="client">API Client.</param>
        /// <param name="properties">Platform Properties.</param>
        /// <param name="resource">Resources.</param>
        /// <param name="database">Database.</param>
        /// <param name="error">Error Handler.</param>
        /// <param name="navigation">Navigation Handler.</param>
        public ImageGalleryViewModel(
            ImageUpload.Mobile.Interfaces.IPopup popup,
            ImageEndpoint client,
            IPlatformProperties properties,
            IResourceHelper resource,
            IDatabase database,
            IErrorHandler error,
            INavigationHandler navigation)
            : base(properties, resource, database, error, navigation)
        {
            this.popup = popup;
            this.client = client;
            this.Images = new ObservableCollection<IImage>();
        }

        /// <summary>
        /// Gets the collection of images.
        /// </summary>
        public ObservableCollection<IImage> Images { get; private set; }

        /// <summary>
        /// Gets the view image command.
        /// </summary>
        public AsyncCommand<IImage> ViewImageCommand
        {
            get
            {
                return this.viewImageCommand ??= new AsyncCommand<IImage>(this.ViewImageAsync, null, this.Error);
            }
        }

        /// <inheritdoc/>
        public override Task OnAppearingAsync()
        {
            if (this.Images.Any())
            {
                return base.OnAppearingAsync();
            }

            var images = this.Database.GetImages();
            foreach (var image in images)
            {
                this.Images.Add(image);
            }

            return base.OnAppearingAsync();
        }

        private Task ViewImageAsync(IImage image)
        {
            if (image != null)
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    this.popup.SetContent(new ImgurView(image, this.Navigation), true);
                });
            }

            return Task.CompletedTask;
        }
    }
}