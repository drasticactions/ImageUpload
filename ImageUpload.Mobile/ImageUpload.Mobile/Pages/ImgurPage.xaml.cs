// <copyright file="ImgurPage.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.API.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageUpload.Mobile.Pages
{
    /// <summary>
    /// Imgur Page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImgurPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImgurPage"/> class.
        /// </summary>
        /// <param name="image">Imgur Image.</param>
        public ImgurPage(IImage image)
        {
            this.InitializeComponent();
            this.BindingContext = image;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync().ConfigureAwait(false);
        }
    }
}