// <copyright file="INavigationHandler.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Drastic.Common.Interfaces
{
    /// <summary>
    /// Navigation Handler.
    /// </summary>
    public interface INavigationHandler
    {
        /// <summary>
        /// Display Alert to User.
        /// </summary>
        /// <param name="title">Title of message.</param>
        /// <param name="message">Message to user.</param>
        /// <param name="closeButton">Close button.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DisplayAlertAsync(string title, string message, string closeButton);

        /// <summary>
        /// Push Page to current navigation stack.
        /// </summary>
        /// <param name="currentPage">Current Page.</param>
        /// <param name="page">Page to navigate to.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task PushPageAsync(object currentPage, object page);

        /// <summary>
        /// Push modal page to top.
        /// </summary>
        /// <param name="page">Page.</param>
        /// <returns>Task.</returns>
        Task PushModalPageAsync(object page);

        /// <summary>
        /// Sets the main page of the application.
        /// </summary>
        /// <param name="page">Page to set as top level.</param>
        void SetMainAppPage(object page);
    }
}
