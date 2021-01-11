// <copyright file="ImageSourceHelper.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Drastic.Common.Forms.Tools
{
    /// <summary>
    /// Image Source Helper.
    /// </summary>
    public static class ImageSourceHelper
    {
        /// <summary>
        /// Generate Font Image Source.
        /// </summary>
        /// <param name="fontFamily">Font Family.</param>
        /// <param name="glyph">Glyph.</param>
        /// <param name="size">Size.</param>
        /// <returns>FontImageSource.</returns>
        public static FontImageSource GenerateFontImageSource(string fontFamily, string glyph, int size = 24)
        {
            var fontImageSource = new FontImageSource() { FontFamily = fontFamily, Size = size, Glyph = glyph };
            fontImageSource.SetDynamicResource(FontImageSource.ColorProperty, ResourceHelper.DynamicTextColor);
            return fontImageSource;
        }
    }
}
