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
using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.oM.Adapters.Miro
{
    [Description("Represents a Miro board. A board is the primary collaborative canvas on which items are placed. \n" +
        "Boards can be created, retrieved, and deleted via the Miro adapter.")]
    public class MiroBoard : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Unique identifier assigned by Miro when the board is created. \n" +
            "Required for item operations and board deletion. Leave empty when creating a new board.")]
        public virtual string MiroBoardId { get; set; } = "";

        [Description("Human-readable description of the board (0-300 characters).")]
        public virtual string Description { get; set; } = "";

        [Description("Identifier of the Miro team that owns this board. \n" +
            "When supplied, the board is created within that team's workspace.")]
        public virtual string TeamId { get; set; } = "";

        [Description("Identifier of the Miro project to which this board belongs.")]
        public virtual string ProjectId { get; set; } = "";

        [Description("URL link to open the board directly in the Miro web application. Populated on read; ignored on create.")]
        public virtual string ViewLink { get; set; } = "";

        /***************************************************/
    }
}
