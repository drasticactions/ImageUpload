// <copyright file="MainFlyoutPage.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Drastic.Common.Interfaces;
using ImageUpload.Mobile.Entities.Menu;
using ImageUpload.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageUpload.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFlyoutPage : FlyoutPage
    {
        private FlyoutPageViewModel vm;

        public MainFlyoutPage(List<MainMenuItem> menuItems, MainMenuItem footerMenu = default)
        {
            this.InitializeComponent();
            this.Detail = new ContentPage();
            this.BindingContext = this.vm = App.Container.Resolve<FlyoutPageViewModel>(new NamedParameter("page", this), new NamedParameter("menuItems", menuItems), new NamedParameter("footerMenu", footerMenu));
            this.Flyout.BindingContext = this.vm;
        }
    }
}