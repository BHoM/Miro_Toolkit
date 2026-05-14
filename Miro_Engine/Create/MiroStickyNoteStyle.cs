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

        [Description("Creates a MiroStickyNoteStyle object defining the visual appearance of a sticky note.")]
        [Input("fillColour", "Background colour of the sticky note chosen from the named colour list.")]
        [Input("textAlign", "Horizontal alignment of the text within the sticky note.")]
        [Input("textAlignVertical", "Vertical alignment of the text within the sticky note.")]
        [Output("style", "A MiroStickyNoteStyle object to pass to the MiroStickyNote Create component.")]
        public static MiroStickyNoteStyle MiroStickyNoteStyle(
            MiroStickyNoteColour fillColour = MiroStickyNoteColour.LightYellow,
            MiroTextAlign textAlign = MiroTextAlign.Center,
            MiroTextAlignVertical textAlignVertical = MiroTextAlignVertical.Top)
        {
            return new MiroStickyNoteStyle
            {
                FillColour = fillColour,
                TextAlign = textAlign,
                TextAlignVertical = textAlignVertical
            };
        }

        /***************************************************/
    }
}
