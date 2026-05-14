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

namespace BH.Adapter.Miro
{
    public partial class MiroAdapter : BHoMAdapter
    {
        /***************************************************/
        /**** Private Methods - Read                    ****/
        /***************************************************/

        private List<MiroBoard> ReadBoards(MiroConfig config = null)
        {
            int limit = config?.Limit > 0 ? System.Math.Min(config.Limit, 50) : 50;

            var queryParams = new Dictionary<string, string>
            {
                ["limit"] = limit.ToString()
            };

            if (!string.IsNullOrEmpty(config?.TeamId))
                queryParams["team_id"] = config.TeamId;

            string response = BH.Engine.Adapters.Miro.Compute.Get($"{m_BaseUrl}/boards", m_Token, queryParams);

            if (response == null)
                return new List<MiroBoard>();

            return response.BoardsFromMiro();
        }

        /***************************************************/
    }
}
