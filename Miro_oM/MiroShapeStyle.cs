/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *
 *
 * The BHoM is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3.0 of the License, or
 * (at your option) any later version.
 *
 * The BHoM is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.
 */

using System.ComponentModel;

namespace BH.oM.Adapters.Miro
{
    [Description("Visual style properties for a Miro shape item.")]
    public class MiroShapeStyle
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Background fill colour as a hexadecimal colour code (e.g. '#ffffff').")]
        public virtual string FillColour { get; set; } = "#ffffff";

        [Description("Fill opacity as a value between 0 (transparent) and 1 (fully opaque).")]
        public virtual double FillOpacity { get; set; } = 1.0;

        [Description("Border colour as a hexadecimal colour code (e.g. '#1a1a1a').")]
        public virtual string BorderColour { get; set; } = "#1a1a1a";

        [Description("Border width in dp.")]
        public virtual double BorderWidth { get; set; } = 2.0;

        [Description("Border line style.")]
        public virtual MiroBorderStyle BorderStyle { get; set; } = MiroBorderStyle.Normal;

        [Description("Border opacity as a value between 0 (transparent) and 1 (fully opaque).")]
        public virtual double BorderOpacity { get; set; } = 1.0;

        [Description("Text colour as a hexadecimal colour code (e.g. '#1a1a1a').")]
        public virtual string Colour { get; set; } = "#1a1a1a";

        [Description("Font size of the shape text content in dp.")]
        public virtual int FontSize { get; set; } = 14;

        [Description("Horizontal alignment of text content within the shape.")]
        public virtual MiroTextAlign TextAlign { get; set; } = MiroTextAlign.Center;

        [Description("Vertical alignment of text content within the shape.")]
        public virtual MiroTextAlignVertical TextAlignVertical { get; set; } = MiroTextAlignVertical.Middle;

        /***************************************************/
    }
}
