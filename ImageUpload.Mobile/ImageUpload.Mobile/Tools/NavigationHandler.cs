// <copyright file="NavigationHandler.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Drastic.Common.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Drastic.Common.Forms.Tools
{
    /// <summary>
    /// Navigation Handler.
    /// </summary>
    public class NavigationHandler : INavigationHandler
    {
        /// <inheritdoc/>
        public Task DisplayAlertAsync(string title, string message, string closeButton)
        {
            MainThread.BeginInvokeOnMainThread(async () => await Application.Current.MainPage.DisplayAlert(title, message, closeButton).ConfigureAwait(false));
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task PushPageAsync(object currentPage, object page)
        {
            if (currentPage is Page formsPage)
            {
                MainThread.BeginInvokeOnMainThread(async () => await formsPage.Navigation.PushAsync((Page)page).ConfigureAwait(false));
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public void SetMainAppPage(object page)
        {
            MainThread.BeginInvokeOnMainThread(() => Application.Current.MainPage = (Page)page);
        }
    }
}
