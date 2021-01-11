// <copyright file="App.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Autofac;
using Drastic.Common.Forms.Tools;
using Drastic.Common.Interfaces;
using ImageUpload.Mobile.Entities.Menu;
using ImageUpload.Mobile.Entities.Settings;
using ImageUpload.Mobile.Interfaces;
using ImageUpload.Mobile.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageUpload.Mobile
{
    /// <summary>
    /// Xamarin Forms Application.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Autofac Container.
        /// </summary>
#pragma warning disable CA2211 // Non-constant fields should not be visible
#pragma warning disable SA1401 // Fields should be private
        public static IContainer Container;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="builder">Container Builder.</param>
        public App(ContainerBuilder builder)
        {
            Device.SetFlags(new string[] { "MediaElement_Experimental", "Shell_UWP_Experimental", "AppTheme_Experimental", "CollectionView_Experimental", "Shapes_Experimental" });
            this.InitializeComponent();
            Container = ImageUploadContainerBuilder.BuildContainer(builder);
            var database = Container.Resolve<IDatabase>();
            var platform = Container.Resolve<IPlatformProperties>();
            var navigation = Container.Resolve<INavigationHandler>();
            var resourceHelper = Container.Resolve<IResourceHelper>();
            var settings = database.GetAppSettings();

            // If we're using the default system settings.
            if (settings.UseSystemThemeSettings)
            {
                if (platform.IsDarkTheme)
                {
                    resourceHelper.SetDarkMode();
                }
                else
                {
                    resourceHelper.SetLightMode();
                }
            }
            else
            {
                if (settings.CustomTheme != AppCustomTheme.None)
                {
                    resourceHelper.SetCustomTheme(settings.CustomTheme);
                }
                else
                {
                    if (settings.UseDarkMode)
                    {
                        resourceHelper.SetDarkMode();
                    }
                    else
                    {
                        resourceHelper.SetLightMode();
                    }
                }
            }

            if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet)
            {
                this.MainPage = new MainFlyoutPage(GenerateMenuItems(), GenerateSettingsItem());
            }
            else
            {
                this.MainPage = new MainPage();
            }
        }

        /// <summary>
        /// Gets the current pages background color.
        /// </summary>
        /// <returns>Xamarin Forms Color.</returns>
        public static Xamarin.Forms.Color GetCurrentBackgroundColor()
        {
            return App.Current.MainPage.BackgroundColor;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private static List<MainMenuItem> GenerateMenuItems()
        {
            return new List<MainMenuItem>()
            {
                new MainMenuItem()
                {
                    Title = "Uploads",
                    Page = new UploadPage(),
                    IconImageSource = ImageSourceHelper.GenerateFontImageSource("FontAwesomeSolid", ""),
                },
                new MainMenuItem()
                {
                    Title = "Gallery",
                    Page = new ImageGalleryPage(),
                    IconImageSource = ImageSourceHelper.GenerateFontImageSource("FontAwesomeSolid", ""),
                },
            };
        }

        private static MainMenuItem GenerateSettingsItem()
        {
            return new MainMenuItem()
            {
                Title = "Settings",
                Page = new SettingsPage(),
                IconImageSource = ImageSourceHelper.GenerateFontImageSource("FontAwesomeSolid", ""),
            };
        }
    }
}
