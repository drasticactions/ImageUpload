using System;
using Forms9Patch;
using IPopup = ImageUpload.Mobile.Interfaces.IPopup;

namespace ImageUpload.Mobile.Controls
{
    public class ImageUploadPopup : IPopup, IDisposable
    {
        private ModalPopup popup;
        private bool disposedValue;
        private Action callback;
        private Action<object> callbackWithParameter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageUploadPopup"/> class.
        /// </summary>
        public ImageUploadPopup()
        {
            this.popup = new Forms9Patch.ModalPopup()
            {
                Content = new Xamarin.Forms.ContentView(),
            };
        }

        /// <summary>
        /// Set popup to appear.
        /// </summary>
        /// <param name="isVisible">Set is visibile.</param>
        /// <param name="parameter">Optional parameter to be called on callback.</param>
        public void SetIsVisible(bool isVisible, object parameter = default)
        {
            this.popup.IsVisible = isVisible;
            if (!isVisible && this.callback != null)
            {
                this.callback.Invoke();
            }

            if (!isVisible && this.callbackWithParameter != null)
            {
                this.callbackWithParameter.Invoke(parameter);
            }
        }

        /// <summary>
        /// Set popups internal content.
        /// </summary>
        /// <param name="view"><see cref="Xamarin.Forms.ContentView"/>.</param>
        /// <param name="launchModal">Launch the modal after setting the content.</param>
        /// <param name="callback">Callback after modal is closed.</param>
        public void SetContent(object view, bool launchModal = false, Action callback = default)
        {
            this.popup.BackgroundColor = App.GetCurrentBackgroundColor();
            this.popup.Content = (Xamarin.Forms.ContentView)view;
            this.callback = callback;

            if (launchModal)
            {
                this.SetIsVisible(true);
            }
        }

        /// <summary>
        /// Set popups internal content.
        /// </summary>
        /// <param name="view"><see cref="Xamarin.Forms.ContentView"/>.</param>
        /// <param name="launchModal">Launch the modal after setting the content.</param>
        /// <param name="callback">Callback after modal is closed.</param>
        public void SetContentWithParameter(object view, bool launchModal = false, Action<object> callback = default)
        {
            this.popup.BackgroundColor = App.GetCurrentBackgroundColor();
            this.popup.Content = (Xamarin.Forms.ContentView)view;
            this.callbackWithParameter = callback;

            if (launchModal)
            {
                this.SetIsVisible(true);
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="disposing">Disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.popup.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                this.disposedValue = true;
            }
        }
    }
}