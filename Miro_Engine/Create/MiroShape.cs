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

        [Description("Creates a MiroShape object representing a geometric shape item on a Miro board. \n" +
            "Push this object via the MiroAdapter to add the shape to a board.")]
        [Input("boardId", "Identifier of the target Miro board. Obtain this from a created or pulled MiroBoard.")]
        [Input("shapeType", "Geometric outline type of the shape.")]
        [Input("content", "Optional text label displayed inside the shape. Supports basic HTML formatting.")]
        [Input("x", "Horizontal position on the board canvas in dp. Defaults to 0 (canvas centre).")]
        [Input("y", "Vertical position on the board canvas in dp. Defaults to 0 (canvas centre).")]
        [Input("width", "Width of the shape in dp.")]
        [Input("height", "Height of the shape in dp.")]
        [Input("style", "Optional style controlling fill colour, border, and text appearance. Uses defaults when null.")]
        [Output("shape", "A MiroShape object ready to be pushed via the MiroAdapter.")]
        public static MiroShape MiroShape(
            string boardId,
            MiroShapeType shapeType = MiroShapeType.Rectangle,
            string content = "",
            double x = 0,
            double y = 0,
            double width = 200,
            double height = 200,
            MiroShapeStyle style = null)
        {
            return new MiroShape
            {
                BoardId = boardId,
                ShapeType = shapeType,
                Content = content,
                Style = style ?? new MiroShapeStyle(),
                Position = new MiroPosition { X = x, Y = y },
                Geometry = new MiroGeometry { Width = width, Height = height }
            };
        }

        /***************************************************/
    }
}
