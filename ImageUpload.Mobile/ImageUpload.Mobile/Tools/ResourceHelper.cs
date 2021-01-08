// <copyright file="ResourceHelper.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using Drastic.Common.Interfaces;
using ImageUpload.Mobile.Entities.Settings;
using Xamarin.Forms;

namespace Drastic.Common.Forms.Tools
{
    /// <summary>
    /// Resources Helper.
    /// </summary>
    public class ResourceHelper : IResourceHelper
    {
        /// <summary>
        /// Background color.
        /// </summary>
        public const string DynamicBackgroundColor = nameof(DynamicBackgroundColor);

        /// <summary>
        /// Text Color.
        /// </summary>
        public const string DynamicTextColor = nameof(DynamicTextColor);

        /// <summary>
        /// Header Text Bar Color.
        /// </summary>
        public const string DynamicHeaderBarTextColor = nameof(DynamicHeaderBarTextColor);

        /// <summary>
        /// Header Background Color.
        /// </summary>
        public const string DynamicHeaderBackgroundColor = nameof(DynamicHeaderBackgroundColor);

        /// <inheritdoc/>
        public object GetDynamicResource(string sourceResourceName)
        {
            return Application.Current.Resources[sourceResourceName];
        }

        /// <inheritdoc/>
        public void SetCustomTheme(object customTheme)
        {
            switch (customTheme)
            {
                case AppCustomTheme.None:
                    break;
                case AppCustomTheme.OLED:
                    this.SetDarkMode();
                    this.SetDynamicResource(DynamicBackgroundColor, "OLED_BackgroundColorDark");
                    this.SetDynamicResource(DynamicHeaderBackgroundColor, "OLED_BackgroundColorDark");
                    break;
                default:
                    break;
            }
        }

        /// <inheritdoc/>
        public void SetDarkMode()
        {
            Application.Current.UserAppTheme = OSAppTheme.Dark;
            this.SetDynamicResource(DynamicBackgroundColor, "BackgroundColorDark");
            this.SetDynamicResource(DynamicTextColor, "TextColorLight");

            this.SetDynamicResource(DynamicHeaderBackgroundColor, "HeaderBarBackgroundColorDark");
            this.SetDynamicResource(DynamicHeaderBarTextColor, "HeaderBarTextColorLight");
        }

        /// <inheritdoc/>
        public void SetDynamicResource(string targetResourceName, string sourceResourceName)
        {
            if (!Application.Current.Resources.TryGetValue(sourceResourceName, out var value))
            {
                throw new InvalidOperationException($"key {sourceResourceName} not found in the resource dictionary");
            }

            Application.Current.Resources[targetResourceName] = value;
        }

        /// <inheritdoc/>
        public void SetDynamicResource<T>(string targetResourceName, T value)
        {
            Application.Current.Resources[targetResourceName] = value;
        }

        /// <inheritdoc/>
        public void SetLightMode()
        {
            Application.Current.UserAppTheme = OSAppTheme.Light;
            this.SetDynamicResource(DynamicBackgroundColor, "BackgroundColorLight");
            this.SetDynamicResource(DynamicTextColor, "TextColorDark");

            this.SetDynamicResource(DynamicHeaderBackgroundColor, "HeaderBarBackgroundColorLight");
            this.SetDynamicResource(DynamicHeaderBarTextColor, "HeaderBarTextColorDark");
        }
    }
}
