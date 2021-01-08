// <copyright file="ImageUploadContainerBuilder.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Drastic.Common.Forms.Tools;
using Drastic.Common.Interfaces;
using ImageUpload.Mobile.Database;
using ImageUpload.Mobile.Helpers;
using ImageUpload.Mobile.Interfaces;
using ImageUpload.Mobile.ViewModels;
using Imgur.API.Authentication;

namespace ImageUpload.Mobile
{
    /// <summary>
    /// Image Upload Container Builder.
    /// </summary>
    public static class ImageUploadContainerBuilder
    {
        /// <summary>
        /// Builds SocialMediaApp Container.
        /// </summary>
        /// <param name="builder">Platform Specific Container.</param>
        /// <returns>IContainer.</returns>
        public static IContainer BuildContainer(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.RegisterType<AppDatabase>().As<IDatabase>().SingleInstance();
            builder.RegisterType<NavigationHandler>().As<INavigationHandler>().SingleInstance();
            builder.RegisterType<ErrorHandler>().As<IErrorHandler>().SingleInstance();
            builder.RegisterType<ResourceHelper>().As<IResourceHelper>().SingleInstance();
            builder.RegisterType<SettingsViewModel>();
            builder.RegisterType<UploadViewModel>();
            builder.RegisterInstance(new ApiClient(Secrets.ImgurApiClientKey)).SingleInstance();
            return builder.Build();
        }
    }
}
