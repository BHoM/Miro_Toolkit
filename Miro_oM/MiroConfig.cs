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

using BH.oM.Adapter;
using System.ComponentModel;

namespace BH.oM.Adapters.Miro
{
    [Description("Configuration options for Miro adapter Pull and Remove operations.")]
    public class MiroConfig : ActionConfig
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Identifier of the Miro board to target for item operations (Pull items, Delete item). \n" +
            "Required when pulling items from a specific board.")]
        public virtual string BoardId { get; set; } = "";

        [Description("Filter boards by team identifier when pulling boards.")]
        public virtual string TeamId { get; set; } = "";

        [Description("Maximum number of results to return per request (1-50 for boards, 10-50 for items).")]
        public virtual int Limit { get; set; } = 50;

        [Description("Filter items by type when pulling items from a board. Use All to retrieve every item type.")]
        public virtual MiroItemType ItemType { get; set; } = MiroItemType.All;

        /***************************************************/
    }
}
