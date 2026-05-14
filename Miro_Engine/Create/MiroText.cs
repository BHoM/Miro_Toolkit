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

        [Description("Creates a MiroText object representing a free-standing text item on a Miro board. \n" +
            "Push this object via the MiroAdapter to add the text element to a board.")]
        [Input("boardId", "Identifier of the target Miro board. Obtain this from a created or pulled MiroBoard.")]
        [Input("content", "Text content to display. Miro wraps plain strings in a <p> tag automatically.")]
        [Input("x", "Horizontal position on the board canvas in dp. Defaults to 0 (canvas centre).")]
        [Input("y", "Vertical position on the board canvas in dp. Defaults to 0 (canvas centre).")]
        [Input("width", "Width of the text box in dp.")]
        [Input("style", "Optional style controlling text colour, font size, and alignment. Uses defaults when null.")]
        [Output("text", "A MiroText object ready to be pushed via the MiroAdapter.")]
        public static MiroText MiroText(
            string boardId,
            string content = "",
            double x = 0,
            double y = 0,
            double width = 200,
            MiroTextStyle style = null)
        {
            return new MiroText
            {
                BoardId = boardId,
                Content = content,
                Style = style ?? new MiroTextStyle(),
                Position = new MiroPosition { X = x, Y = y },
                Geometry = new MiroGeometry { Width = width }
            };
        }

        /***************************************************/
    }
}
