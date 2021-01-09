// <copyright file="ImageGalleryPage.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Drastic.Common.Tools;
using Drastic.Common.ViewModels;
using ImageUpload.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageUpload.Mobile.Pages
{
    /// <summary>
    /// Image Gallery Page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageGalleryPage : ContentPage
    {
        private ImageGalleryViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageGalleryPage"/> class.
        /// </summary>
        public ImageGalleryPage()
        {
            this.InitializeComponent();
            this.BindingContext = this.vm = App.Container.Resolve<ImageGalleryViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (this.BindingContext is BaseViewModel baseVm)
            {
                baseVm.OnAppearingAsync().FireAndForgetSafeAsync();
            }
        }
    }
}