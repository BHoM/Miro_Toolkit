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

using BH.oM.Adapters.Miro;
using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.Engine.Adapters.Miro
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Creates a MiroShapeStyle object defining the visual appearance of a shape item.")]
        [Input("fillColour", "Background fill colour as a hex code (e.g. '#ffffff').")]
        [Input("fillOpacity", "Fill opacity between 0 (transparent) and 1 (fully opaque).")]
        [Input("borderColour", "Border colour as a hex code (e.g. '#1a1a1a').")]
        [Input("borderWidth", "Border width in dp.")]
        [Input("borderStyle", "Border line style: Normal, Dotted, or Dashed.")]
        [Input("borderOpacity", "Border opacity between 0 (transparent) and 1 (fully opaque).")]
        [Input("colour", "Text colour inside the shape as a hex code (e.g. '#1a1a1a').")]
        [Input("fontSize", "Font size of text inside the shape in dp.")]
        [Input("textAlign", "Horizontal alignment of text inside the shape.")]
        [Input("textAlignVertical", "Vertical alignment of text inside the shape.")]
        [Output("style", "A MiroShapeStyle object to pass to the MiroShape Create component.")]
        public static MiroShapeStyle MiroShapeStyle(
            string fillColour = "#ffffff",
            double fillOpacity = 1.0,
            string borderColour = "#1a1a1a",
            double borderWidth = 2.0,
            MiroBorderStyle borderStyle = MiroBorderStyle.Normal,
            double borderOpacity = 1.0,
            string colour = "#1a1a1a",
            int fontSize = 14,
            MiroTextAlign textAlign = MiroTextAlign.Center,
            MiroTextAlignVertical textAlignVertical = MiroTextAlignVertical.Middle)
        {
            return new MiroShapeStyle
            {
                FillColour = fillColour,
                FillOpacity = fillOpacity,
                BorderColour = borderColour,
                BorderWidth = borderWidth,
                BorderStyle = borderStyle,
                BorderOpacity = borderOpacity,
                Colour = colour,
                FontSize = fontSize,
                TextAlign = textAlign,
                TextAlignVertical = textAlignVertical
            };
        }

        /***************************************************/
    }
}
