﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DialogProvider.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Chapter.Net.WPF.Navigation.Dialogs;

/// <summary>
///     Provides way how to show system dialogs for files and folders.
/// </summary>
public sealed class DialogProvider : IDialogProvider
{
    /// <summary>
    ///     Shows the open file dialog.
    /// </summary>
    /// <param name="openFileData">The open file dialog data.</param>
    /// <returns>True of the dialog was closed with OK; otherwise false.</returns>
    /// <exception cref="ArgumentNullException">openFileData is null.</exception>
    public Task<bool> Show(IOpenFileData openFileData)
    {
        if (openFileData == null)
            throw new ArgumentNullException(nameof(openFileData));

        return ShowImpl(null, openFileData);
    }

    /// <summary>
    ///     Shows the open file dialog.
    /// </summary>
    /// <param name="owner">The owner window of the dialog.</param>
    /// <param name="openFileData">The open file dialog data.</param>
    /// <returns>True of the dialog was closed with OK; otherwise false.</returns>
    /// <exception cref="ArgumentNullException">owner is null.</exception>
    /// <exception cref="ArgumentNullException">openFileData is null.</exception>
    public Task<bool> Show(Window owner, IOpenFileData openFileData)
    {
        if (owner == null)
            throw new ArgumentNullException(nameof(owner));
        if (openFileData == null)
            throw new ArgumentNullException(nameof(openFileData));

        return ShowImpl(owner, openFileData);
    }

    /// <summary>
    ///     Shows the save file dialog.
    /// </summary>
    /// <param name="saveFileData">The save file dialog data.</param>
    /// <returns>True of the dialog was closed with OK; otherwise false.</returns>
    /// <exception cref="ArgumentNullException">saveFileData is null.</exception>
    public Task<bool> Show(ISaveFileData saveFileData)
    {
        if (saveFileData == null)
            throw new ArgumentNullException(nameof(saveFileData));

        return ShowImpl(null, saveFileData);
    }

    /// <summary>
    ///     Shows the save file dialog.
    /// </summary>
    /// <param name="owner">The owner window of the dialog.</param>
    /// <param name="saveFileData">The save file dialog data.</param>
    /// <returns>True of the dialog was closed with OK; otherwise false.</returns>
    /// <exception cref="ArgumentNullException">owner is null.</exception>
    /// <exception cref="ArgumentNullException">saveFileData is null.</exception>
    public Task<bool> Show(Window owner, ISaveFileData saveFileData)
    {
        if (owner == null)
            throw new ArgumentNullException(nameof(owner));
        if (saveFileData == null)
            throw new ArgumentNullException(nameof(saveFileData));

        return ShowImpl(owner, saveFileData);
    }

    /// <summary>
    ///     Shows the browse folder dialog.
    /// </summary>
    /// <param name="browseFolderData">The browse folder dialog data.</param>
    /// <returns>True of the dialog was closed with OK; otherwise false.</returns>
    /// <exception cref="ArgumentNullException">browseFolderData is null.</exception>
    public Task<bool> Show(IBrowseFolderData browseFolderData)
    {
        if (browseFolderData == null)
            throw new ArgumentNullException(nameof(browseFolderData));

        return ShowImpl(null, browseFolderData);
    }

    /// <summary>
    ///     Shows the browse folder dialog.
    /// </summary>
    /// <param name="owner">The owner window of the dialog.</param>
    /// <param name="browseFolderData">The browse folder dialog data.</param>
    /// <returns>True of the dialog was closed with OK; otherwise false.</returns>
    /// <exception cref="ArgumentNullException">owner is null.</exception>
    /// <exception cref="ArgumentNullException">browseFolderData is null.</exception>
    public Task<bool> Show(Window owner, IBrowseFolderData browseFolderData)
    {
        if (owner == null)
            throw new ArgumentNullException(nameof(owner));
        if (browseFolderData == null)
            throw new ArgumentNullException(nameof(browseFolderData));

        return ShowImpl(owner, browseFolderData);
    }

    /// <summary>
    ///     Shows the color picker dialog.
    /// </summary>
    /// <param name="colorPickerData">The color picker dialog data.</param>
    /// <returns>True of the dialog was closed with OK; otherwise false.</returns>
    /// <exception cref="ArgumentNullException">colorPickerData is null.</exception>
    public Task<bool> Show(IColorPickerData colorPickerData)
    {
        if (colorPickerData == null)
            throw new ArgumentNullException(nameof(colorPickerData));

        return ShowImpl(null, colorPickerData);
    }

    /// <summary>
    ///     Shows the color picker dialog.
    /// </summary>
    /// <param name="owner">The owner window of the dialog.</param>
    /// <param name="colorPickerData">The color picker dialog data.</param>
    /// <returns>True of the dialog was closed with OK; otherwise false.</returns>
    /// <exception cref="ArgumentNullException">owner is null.</exception>
    /// <exception cref="ArgumentNullException">colorPickerData is null.</exception>
    public Task<bool> Show(Window owner, IColorPickerData colorPickerData)
    {
        if (owner == null)
            throw new ArgumentNullException(nameof(owner));
        if (colorPickerData == null)
            throw new ArgumentNullException(nameof(colorPickerData));

        return ShowImpl(owner, colorPickerData);
    }

    /// <summary>
    ///     Shows the font picker dialog.
    /// </summary>
    /// <param name="fontPickerData">The font picker dialog data.</param>
    /// <returns>True of the dialog was closed with OK; otherwise false.</returns>
    /// <exception cref="ArgumentNullException">fontPickerData is null.</exception>
    public Task<bool> Show(IFontPickerData fontPickerData)
    {
        if (fontPickerData == null)
            throw new ArgumentNullException(nameof(fontPickerData));

        return ShowImpl(null, fontPickerData);
    }

    /// <summary>
    ///     Shows the font picker dialog.
    /// </summary>
    /// <param name="owner">The owner window of the dialog.</param>
    /// <param name="fontPickerData">The font picker dialog data.</param>
    /// <returns>True of the dialog was closed with OK; otherwise false.</returns>
    /// <exception cref="ArgumentNullException">owner is null.</exception>
    /// <exception cref="ArgumentNullException">fontPickerData is null.</exception>
    public Task<bool> Show(Window owner, IFontPickerData fontPickerData)
    {
        if (owner == null)
            throw new ArgumentNullException(nameof(owner));
        if (fontPickerData == null)
            throw new ArgumentNullException(nameof(fontPickerData));

        return ShowImpl(owner, fontPickerData);
    }

    private async Task<bool> ShowImpl(Window owner, IOpenFileData openFileData)
    {
        var dialog = new OpenFileDialog
        {
            CheckFileExists = openFileData.CheckFileExists,
            CheckPathExists = openFileData.CheckPathExists,
            DefaultExt = openFileData.DefaultExt,
            FileName = openFileData.FileName,
            Filter = openFileData.Filter,
            FilterIndex = openFileData.FilterIndex,
            InitialDirectory = openFileData.InitialDirectory,
            Multiselect = openFileData.MultiSelect,
            Title = openFileData.Title,
            ValidateNames = openFileData.ValidateNames
        };

        var result = await ShowDialog(owner, dialog);
        openFileData.FileName = dialog.FileName;
        openFileData.FileNames = dialog.FileNames;
        openFileData.SafeFileName = dialog.SafeFileName;
        openFileData.SafeFileNames = dialog.SafeFileNames;
        return result;
    }

    private async Task<bool> ShowImpl(Window owner, ISaveFileData saveFileData)
    {
        var dialog = new SaveFileDialog
        {
            CheckFileExists = saveFileData.CheckFileExists,
            CheckPathExists = saveFileData.CheckPathExists,
            CreatePrompt = saveFileData.CreatePrompt,
            DefaultExt = saveFileData.DefaultExt,
            FileName = saveFileData.FileName,
            Filter = saveFileData.Filter,
            FilterIndex = saveFileData.FilterIndex,
            InitialDirectory = saveFileData.InitialDirectory,
            OverwritePrompt = saveFileData.OverwritePrompt,
            Title = saveFileData.Title,
            ValidateNames = saveFileData.ValidateNames
        };

        var result = await ShowDialog(owner, dialog);
        saveFileData.FileName = dialog.FileName;
        saveFileData.FileNames = dialog.FileNames;
        return result;
    }

    private async Task<bool> ShowImpl(Window owner, IBrowseFolderData browseFolderData)
    {
        var dialog = new FolderBrowserDialog
        {
            ShowNewFolderButton = browseFolderData.ShowNewFolderButton
        };
        if (browseFolderData.RootFolder != null)
            dialog.RootFolder = browseFolderData.RootFolder.Value;
        if (!string.IsNullOrWhiteSpace(browseFolderData.Description))
            dialog.Description = browseFolderData.Description;
        if (!string.IsNullOrWhiteSpace(browseFolderData.SelectedPath))
            dialog.SelectedPath = browseFolderData.Description;

        var result = await ShowDialog(owner, dialog);
        browseFolderData.SelectedPath = dialog.SelectedPath;
        return result;
    }

    private async Task<bool> ShowImpl(Window owner, IColorPickerData colorPickerData)
    {
        var dialog = new ColorDialog
        {
            AllowFullOpen = colorPickerData.AllowFullOpen,
            AnyColor = colorPickerData.AnyColor,
            Color = colorPickerData.Color,
            CustomColors = colorPickerData.CustomColors,
            FullOpen = colorPickerData.FullOpen,
            SolidColorOnly = colorPickerData.SolidColorOnly
        };

        var result = await ShowDialog(owner, dialog);
        colorPickerData.Color = dialog.Color;
        return result;
    }

    private async Task<bool> ShowImpl(Window owner, IFontPickerData fontPickerData)
    {
        var dialog = new FontDialog
        {
            AllowScriptChange = fontPickerData.AllowScriptChange,
            AllowSimulations = fontPickerData.AllowSimulations,
            AllowVectorFonts = fontPickerData.AllowVectorFonts,
            AllowVerticalFonts = fontPickerData.AllowVerticalFonts,
            Color = fontPickerData.Color,
            FixedPitchOnly = fontPickerData.FixedPitchOnly,
            Font = fontPickerData.Font,
            FontMustExist = fontPickerData.FontMustExist,
            MaxSize = fontPickerData.MaxSize,
            MinSize = fontPickerData.MinSize,
            ScriptsOnly = fontPickerData.ScriptsOnly,
            ShowApply = fontPickerData.ShowApply,
            ShowColor = fontPickerData.ShowColor,
            ShowEffects = fontPickerData.ShowEffects
        };

        dialog.Apply += fontPickerData.OnApply;
        var result = await ShowDialog(owner, dialog);
        fontPickerData.Font = dialog.Font;
        fontPickerData.Color = dialog.Color;
        dialog.Apply -= fontPickerData.OnApply;
        return result;
    }

    private Task<bool> ShowDialog(Window owner, CommonDialog dialog)
    {
        if (owner == null)
            return Task.FromResult(dialog.ShowDialog() == DialogResult.OK);

        var window = new WindowWrapper(owner);
        return Task.FromResult(dialog.ShowDialog(window) == DialogResult.OK);
    }
}