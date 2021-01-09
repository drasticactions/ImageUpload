using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drastic.Common.Interfaces;
using Imgur.API.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageUpload.Mobile.Views
{
    /// <summary>
    /// Imgur View.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImgurView : ContentView
    {
        private readonly IImage image;
        private readonly INavigationHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImgurView"/> class.
        /// </summary>
        /// <param name="image">Image.</param>
        /// <param name="handler">Navigation Handler.</param>
        public ImgurView(IImage image, INavigationHandler handler)
        {
            InitializeComponent();
            this.handler = handler;
            this.BindingContext = this.image = image;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(this.image.Link).ConfigureAwait(false);
            await this.handler.DisplayAlertAsync("Image Link", "Image link copied to clipboard", "Close").ConfigureAwait(false);
        }
    }
}