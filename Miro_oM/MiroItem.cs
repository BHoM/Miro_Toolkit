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

using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Adapters.Miro
{
    [Description("Abstract base class for all items that can be placed on a Miro board, \n" +
        "such as sticky notes, shapes, and text elements.")]
    public abstract class MiroItem : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Unique identifier assigned by Miro when the item is created. \n" +
            "Required for item deletion. Leave empty when creating a new item.")]
        public virtual string MiroItemId { get; set; } = "";

        [Description("Identifier of the Miro board on which this item is placed. \n" +
            "Must be set before pushing the item to the adapter.")]
        public virtual string BoardId { get; set; } = "";

        [Description("Position of the item on the board canvas.")]
        public virtual MiroPosition Position { get; set; } = new MiroPosition();

        [Description("Geometry (size and rotation) of the item.")]
        public virtual MiroGeometry Geometry { get; set; } = new MiroGeometry();

        [Description("Identifier of the parent frame if this item is nested inside a Miro frame. \n" +
            "Leave empty to place the item directly on the canvas.")]
        public virtual string ParentId { get; set; } = "";

        /***************************************************/
    }
}
