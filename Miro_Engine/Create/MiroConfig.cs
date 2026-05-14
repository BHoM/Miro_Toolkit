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

        [Description("Creates a MiroConfig object used to supply optional parameters to Miro adapter Pull and Remove operations.")]
        [Input("boardId", "Board identifier to target when pulling items or deleting items from a board.")]
        [Input("teamId", "Team identifier used to filter boards when pulling boards.")]
        [Input("limit", "Maximum number of results per request (1-50 for boards, 10-50 for items).")]
        [Input("itemType", "Filter to restrict the item type returned when pulling items from a board.")]
        [Output("config", "A MiroConfig object to pass as the actionConfig parameter of Pull or Remove.")]
        public static MiroConfig MiroConfig(
            string boardId = "",
            string teamId = "",
            int limit = 50,
            MiroItemType itemType = MiroItemType.All)
        {
            return new MiroConfig
            {
                BoardId = boardId,
                TeamId = teamId,
                Limit = limit,
                ItemType = itemType
            };
        }

        /***************************************************/
    }
}
