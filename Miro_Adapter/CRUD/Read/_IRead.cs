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

using BH.Adapter;
using BH.oM.Adapter;
using BH.oM.Adapters.Miro;
using BH.oM.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BH.Adapter.Miro
{
    public partial class MiroAdapter : BHoMAdapter
    {
        /***************************************************/
        /**** Adapter overload method                   ****/
        /***************************************************/

        protected override IEnumerable<IBHoMObject> IRead(Type type, IList ids, ActionConfig actionConfig = null)
        {
            MiroConfig config = actionConfig as MiroConfig ?? new MiroConfig();

            if (type == typeof(MiroBoard))
                return ReadBoards(config);

            if (type == typeof(MiroItem)
                || type == typeof(MiroStickyNote)
                || type == typeof(MiroShape)
                || type == typeof(MiroText))
            {
                if (ids != null && ids.Count > 0)
                    return ReadSpecificItems(config.BoardId, ids.Cast<object>().Select(id => id?.ToString()).ToList());

                return ReadItems(config);
            }

            BH.Engine.Base.Compute.RecordError($"Pull is not implemented in the Miro adapter for type '{type?.Name}'. \n" +
                "Supported types are: MiroBoard, MiroItem, MiroStickyNote, MiroShape, MiroText.");
            return new List<IBHoMObject>();
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private IEnumerable<IBHoMObject> ReadSpecificItems(string boardId, List<string> itemIds)
        {
            if (string.IsNullOrWhiteSpace(boardId))
            {
                BH.Engine.Base.Compute.RecordError("A BoardId must be provided in the MiroConfig to pull specific items from a board.");
                return new List<IBHoMObject>();
            }

            var results = new List<IBHoMObject>();
            foreach (string itemId in itemIds)
            {
                MiroItem item = ReadItem(boardId, itemId);
                if (item != null)
                    results.Add(item);
            }
            return results;
        }

        /***************************************************/
    }
}
