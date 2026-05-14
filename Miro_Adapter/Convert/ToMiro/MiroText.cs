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

namespace BH.Adapter.Miro
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods - ToMiro                   ****/
        /***************************************************/

        public static string ToMiro(this MiroText text)
        {
            MiroTextStyle style = text.Style ?? new MiroTextStyle();

            var body = new JObject
            {
                ["data"] = new JObject
                {
                    ["content"] = text.Content ?? ""
                },
                ["style"] = new JObject
                {
                    ["color"] = style.Colour,
                    ["fontSize"] = style.FontSize.ToString(),
                    ["textAlign"] = TextAlignToString(style.TextAlign),
                    ["fillColor"] = style.FillColour
                },
                ["position"] = new JObject
                {
                    ["x"] = text.Position?.X ?? 0,
                    ["y"] = text.Position?.Y ?? 0,
                    ["origin"] = "center",
                    ["relativeTo"] = "canvas_center"
                },
                ["geometry"] = new JObject
                {
                    ["width"] = text.Geometry?.Width ?? 200,
                    ["rotation"] = text.Geometry?.Rotation ?? 0
                }
            };

            if (!string.IsNullOrEmpty(text.ParentId))
                body["parent"] = new JObject { ["id"] = text.ParentId };

            return body.ToString(Newtonsoft.Json.Formatting.None);
        }

        /***************************************************/
    }
}
