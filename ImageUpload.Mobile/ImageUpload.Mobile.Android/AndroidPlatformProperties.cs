// <copyright file="AndroidPlatformProperties.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Drastic.Common.Interfaces;
using ImageUpload.Mobile.Droid;

namespace Drastic.Forms.Android
{
    /// <summary>
    /// Android Platform Properties.
    /// </summary>
    public class AndroidPlatformProperties : IPlatformProperties
    {
        /// <inheritdoc/>
        public bool IsDarkTheme
        {
            get
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Froyo)
                {
                    var uiModeFlags = Xamarin.Essentials.Platform.CurrentActivity.Resources.Configuration.UiMode & UiMode.NightMask;

                    switch (uiModeFlags)
                    {
                        case UiMode.NightYes:
                            return true;

                        case UiMode.NightNo:
                            return false;
                        default:
                            return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        /// <inheritdoc/>
        public string LocalAppAreaPath => System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData));

        public Task<Stream> PickImageAsync()
        {
            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            // Start the picture-picker activity (resumes in MainActivity.cs)
            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Picture"),
                MainActivity.PickImageId);

            // Save the TaskCompletionSource object as a MainActivity property
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

            // Return Task object
            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }
    }
}