// <copyright file="FlyoutPageViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drastic.Common.Interfaces;
using Drastic.Common.Tools;
using Drastic.Common.ViewModels;
using ImageUpload.Mobile.Entities.Menu;
using ImageUpload.Mobile.Interfaces;
using Xamarin.Forms;

namespace ImageUpload.Mobile.ViewModels
{
    /// <summary>
    /// Flyout Page View Model.
    /// </summary>
    public class FlyoutPageViewModel : BaseViewModel
    {
        private MainMenuItem selectedItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlyoutPageViewModel"/> class.
        /// </summary>
        /// <param name="page">Flyout Page.</param>
        /// <param name="menuItems">Menu Items.</param>
        /// <param name="footerMenu">Optional button for the footer.</param>
        /// <param name="properties">Platform Properties.</param>
        /// <param name="resource">Resources.</param>
        /// <param name="database">Database.</param>
        /// <param name="error">Error Handler.</param>
        /// <param name="navigation">Navigation Handler.</param>
        public FlyoutPageViewModel(FlyoutPage page, List<MainMenuItem> menuItems, MainMenuItem footerMenu, IPlatformProperties properties, IResourceHelper resource, IDatabase database, IErrorHandler error, INavigationHandler navigation)
            : base(properties, resource, database, error, navigation)
        {
            this.FlyoutPage = page;
            this.MainMenuItems = menuItems;
            this.FooterMenu = footerMenu;
            if (!this.MainMenuItems.Any())
            {
                throw new ArgumentException($"{nameof(menuItems)} is empty.");
            }

            this.Title = "Drastic";
            this.SelectedItem = this.MainMenuItems.First();
        }

        /// <summary>
        /// Gets the select footer command.
        /// </summary>
        public AsyncCommand SelectFooterCommand
        {
            get
            {
                return new AsyncCommand(
                    () =>
                    {
                        this.SelectedItem = this.FooterMenu;
                        return Task.CompletedTask;
                    }, null, this.Error);
            }
        }

        /// <summary>
        /// Gets the main menu items.
        /// </summary>
        public List<MainMenuItem> MainMenuItems { get; private set; }

        /// <summary>
        /// Gets the main menu item for the footer.
        /// </summary>
        public MainMenuItem FooterMenu { get; private set; }

        /// <summary>
        /// Gets a value indicating whether to show the footer menu.
        /// </summary>
        public bool IsFooterVisible => this.FooterMenu != null;

        /// <summary>
        /// Gets or sets the selected main menu item.
        /// </summary>
        public MainMenuItem SelectedItem
        {
            get
            {
                return this.selectedItem;
            }

            set
            {
                if (this.selectedItem != value && value != null)
                {
                    this.selectedItem = value;
                    if (this.FlyoutPage != null)
                    {
                        this.FlyoutPage.Detail = this.selectedItem.Page;
                        this.FlyoutPage.IsPresented = false;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the base flyout page.
        /// </summary>
        protected FlyoutPage FlyoutPage { get; private set; }
    }
}
