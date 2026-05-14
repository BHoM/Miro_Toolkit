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
    [Description("Visual style properties for a Miro text item.")]
    public class MiroTextStyle
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Text colour as a hexadecimal colour code (e.g. '#1a1a1a').")]
        public virtual string Colour { get; set; } = "#1a1a1a";

        [Description("Font size of the text content in dp.")]
        public virtual int FontSize { get; set; } = 14;

        [Description("Horizontal alignment of the text content.")]
        public virtual MiroTextAlign TextAlign { get; set; } = MiroTextAlign.Left;

        [Description("Background fill colour of the text box as a hexadecimal colour code, or 'transparent' for no background.")]
        public virtual string FillColour { get; set; } = "transparent";

        /***************************************************/
    }
}
