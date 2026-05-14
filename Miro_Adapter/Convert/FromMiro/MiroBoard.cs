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
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace BH.Adapter.Miro
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods - FromMiro                 ****/
        /***************************************************/

        public static MiroBoard BoardFromMiro(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;

            JObject j = JObject.Parse(json);
            return ParseBoard(j);
        }

        public static List<MiroBoard> BoardsFromMiro(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return new List<MiroBoard>();

            JObject root = JObject.Parse(json);
            JArray data = root["data"] as JArray;

            if (data == null)
                return new List<MiroBoard>();

            return data
                .OfType<JObject>()
                .Select(ParseBoard)
                .Where(b => b != null)
                .ToList();
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static MiroBoard ParseBoard(JObject j)
        {
            if (j == null)
                return null;

            return new MiroBoard
            {
                MiroBoardId = j["id"]?.ToString() ?? "",
                Name = j["name"]?.ToString() ?? "",
                Description = j["description"]?.ToString() ?? "",
                TeamId = j["team"]?["id"]?.ToString() ?? "",
                ProjectId = j["project"]?["id"]?.ToString() ?? "",
                ViewLink = j["viewLink"]?.ToString() ?? ""
            };
        }

        /***************************************************/
    }
}
