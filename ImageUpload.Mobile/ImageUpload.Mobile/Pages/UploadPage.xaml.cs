// <copyright file="UploadPage.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ImageUpload.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageUpload.Mobile.Pages
{
    /// <summary>
    /// Upload Page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadPage"/> class.
        /// </summary>
        public UploadPage()
        {
            this.InitializeComponent();
            this.BindingContext = App.Container.Resolve<UploadViewModel>();
        }
    }
}