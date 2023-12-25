﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IWindowProvider.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Chapter.Net.WPF.Navigation.Windows;

/// <summary>
///     Provides possibilities to create and display windows and user controls.
/// </summary>
public interface IWindowProvider
{
    /// <summary>
    ///     Creates a new window by the key.
    /// </summary>
    /// <param name="windowKey">The key of the window to create.</param>
    /// <returns>The newly created window.</returns>
    Window GetNewWindow(object windowKey);

    /// <summary>
    ///     Returns the open window by the key.
    /// </summary>
    /// <param name="windowKey">The key of the window to return.</param>
    /// <returns>The open window know by the key.</returns>
    Window GetOpenWindow(object windowKey);

    /// <summary>
    ///     Returns the open window by the key.
    /// </summary>
    /// <param name="windowKey">The key of the window to return.</param>
    /// <returns>The open window know by the key if exist; otherwise null.</returns>
    Window TryGetOpenWindow(object windowKey);

    /// <summary>
    ///     Returns the main window.
    /// </summary>
    /// <returns>The main window if registered and open; otherwise null.</returns>
    Window GetMainWindow();

    /// <summary>
    ///     Creates a new user control by the key.
    /// </summary>
    /// <param name="controlKey">The key of the user control to create.</param>
    /// <returns>The newly created user control.</returns>
    UserControl GetNewControl(object controlKey);
}