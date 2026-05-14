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
using BH.oM.Adapters.Miro;
using System.Collections.Generic;
using System.Linq;

namespace BH.Adapter.Miro
{
    public partial class MiroAdapter : BHoMAdapter
    {
        /***************************************************/
        /**** Private Methods - Read                    ****/
        /***************************************************/

        private List<MiroItem> ReadItems(MiroConfig config = null)
        {
            if (string.IsNullOrWhiteSpace(config?.BoardId))
            {
                BH.Engine.Base.Compute.RecordError("A BoardId must be provided in the MiroConfig to pull items from a board.");
                return new List<MiroItem>();
            }

            int limit = config.Limit > 0 ? System.Math.Min(config.Limit, 50) : 50;

            var queryParams = new Dictionary<string, string>
            {
                ["limit"] = limit.ToString()
            };

            if (config.ItemType != MiroItemType.All)
                queryParams["type"] = ItemTypeToString(config.ItemType);

            string url = $"{m_BaseUrl}/boards/{config.BoardId}/items";
            string response = BH.Engine.Adapters.Miro.Compute.Get(url, m_Token, queryParams);

            if (response == null)
                return new List<MiroItem>();

            List<MiroItem> items = response.ItemsFromMiro();

            foreach (MiroItem item in items)
                item.BoardId = config.BoardId;

            return items;
        }

        private MiroItem ReadItem(string boardId, string itemId)
        {
            if (string.IsNullOrWhiteSpace(boardId) || string.IsNullOrWhiteSpace(itemId))
            {
                BH.Engine.Base.Compute.RecordError("Both boardId and itemId are required to retrieve a specific Miro item.");
                return null;
            }

            string url = $"{m_BaseUrl}/boards/{boardId}/items/{itemId}";
            string response = BH.Engine.Adapters.Miro.Compute.Get(url, m_Token);

            if (response == null)
                return null;

            MiroItem item = response.ItemFromMiro();
            if (item != null)
                item.BoardId = boardId;

            return item;
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static string ItemTypeToString(MiroItemType type)
        {
            switch (type)
            {
                case MiroItemType.Text:       return "text";
                case MiroItemType.Shape:      return "shape";
                case MiroItemType.StickyNote: return "sticky_note";
                case MiroItemType.Image:      return "image";
                case MiroItemType.Document:   return "document";
                case MiroItemType.Card:       return "card";
                case MiroItemType.AppCard:    return "app_card";
                case MiroItemType.Preview:    return "preview";
                case MiroItemType.Frame:      return "frame";
                case MiroItemType.Embed:      return "embed";
                default:                      return "";
            }
        }

        /***************************************************/
    }
}
