// <copyright file="IPopup.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace ImageUpload.Mobile.Interfaces
{
    /// <summary>
    /// Popup.
    /// </summary>
    public interface IPopup
    {
        /// <summary>
        /// Set popup to appear.
        /// </summary>
        /// <param name="isVisible">Set is visible.</param>
        /// <param name="parameter">Optional parameter to be called on callback.</param>
        public void SetIsVisible(bool isVisible, object parameter = default);

        /// <summary>
        /// Set popups internal content.
        /// </summary>
        /// <param name="view">A view.</param>
        /// <param name="launchModal">Launch the modal after setting the content.</param>
        /// <param name="callback">Callback after modal is closed.</param>
        public void SetContent(object view, bool launchModal = false, Action callback = default);

        /// <summary>
        /// Set popups internal content.
        /// </summary>
        /// <param name="view">A view.</param>
        /// <param name="launchModal">Launch the modal after setting the content.</param>
        /// <param name="callback">Callback after modal is closed.</param>
        public void SetContentWithParameter(object view, bool launchModal = false, Action<object> callback = default);
    }
}