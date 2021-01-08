// <copyright file="SettingsViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drastic.Common.Interfaces;
using Drastic.Common.ViewModels;
using ImageUpload.Mobile.Entities.Settings;
using ImageUpload.Mobile.Interfaces;

namespace ImageUpload.Mobile.ViewModels
{
    /// <summary>
    /// Settings View Model.
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        private AppSettings appSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsViewModel"/> class.
        /// </summary>
        /// <param name="properties">Platform Properties.</param>
        /// <param name="resource">Resources.</param>
        /// <param name="database">Database.</param>
        /// <param name="error">Error Handler.</param>
        /// <param name="navigation">Navigation Handler.</param>
        public SettingsViewModel(IPlatformProperties properties, IResourceHelper resource, IDatabase database, IErrorHandler error, INavigationHandler navigation)
            : base(properties, resource, database, error, navigation)
        {
            this.appSettings = this.Database.GetAppSettings();
            this.Title = "Settings";
        }

        /// <summary>
        /// Gets the theme names.
        /// </summary>
        public List<string> CustomThemeNames
        {
            get
            {
                return Enum.GetNames(typeof(AppCustomTheme)).Select(b => b).ToList();
            }
        }

        /// <summary>
        /// Gets or sets the device color theme.
        /// </summary>
        public AppCustomTheme CustomTheme
        {
            get
            {
                return this.appSettings.CustomTheme;
            }

            set
            {
                this.appSettings.CustomTheme = value;
                this.OnPropertyChanged(nameof(this.CustomTheme));
                this.Database.SaveAppSettings(this.appSettings);
                this.SetTheme();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the system settings for themes,
        /// or let the user override them.
        /// </summary>
        public bool UseSystemThemeSettings
        {
            get
            {
                return this.appSettings.UseSystemThemeSettings;
            }

            set
            {
                this.appSettings.UseSystemThemeSettings = value;
                if (value)
                {
                    this.UseDarkMode = this.PlatformProperties.IsDarkTheme;
                    this.CustomTheme = AppCustomTheme.None;
                }

                this.OnPropertyChanged(nameof(this.UseSystemThemeSettings));
                this.OnPropertyChanged(nameof(this.CanOverrideThemeSettings));
                this.Database.SaveAppSettings(this.appSettings);
                this.SetTheme();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the system settings for themes,
        /// or let the user override them.
        /// </summary>
        public bool UseDarkMode
        {
            get
            {
                return this.appSettings.UseDarkMode;
            }

            set
            {
                this.appSettings.UseDarkMode = value;
                this.OnPropertyChanged(nameof(this.UseDarkMode));
                this.Database.SaveAppSettings(this.appSettings);
                this.SetTheme();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user can override theme settings.
        /// </summary>
        public bool CanOverrideThemeSettings => !this.UseSystemThemeSettings;

        private void SetTheme()
        {
            var darkMode = this.UseSystemThemeSettings ? this.PlatformProperties.IsDarkTheme : this.UseDarkMode;
            if (!this.UseSystemThemeSettings && this.appSettings.CustomTheme != AppCustomTheme.None)
            {
                this.Resources.SetCustomTheme(this.appSettings.CustomTheme);
                return;
            }

            if (darkMode)
            {
                this.Resources.SetDarkMode();
            }
            else
            {
                this.Resources.SetLightMode();
            }
        }
    }
}
