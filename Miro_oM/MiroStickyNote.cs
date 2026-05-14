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
    [Description("A sticky note item on a Miro board. Sticky notes are the primary medium for capturing \n" +
        "ideas during brainstorming sessions and can be positioned freely on the board canvas.")]
    public class MiroStickyNote : MiroItem
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Text content of the sticky note. Supports plain text; HTML tags are stripped by Miro.")]
        public virtual string Content { get; set; } = "";

        [Description("Shape of the sticky note canvas area.")]
        public virtual MiroStickyNoteShape Shape { get; set; } = MiroStickyNoteShape.Square;

        [Description("Visual style properties controlling the colour and text alignment of the sticky note.")]
        public virtual MiroStickyNoteStyle Style { get; set; } = new MiroStickyNoteStyle();

        /***************************************************/
    }
}
