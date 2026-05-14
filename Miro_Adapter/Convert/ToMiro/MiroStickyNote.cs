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

        public static string ToMiro(this MiroStickyNote note)
        {
            var body = new JObject
            {
                ["data"] = new JObject
                {
                    ["content"] = note.Content,
                    ["shape"] = StickyNoteShapeToString(note.Shape)
                },
                ["style"] = new JObject
                {
                    ["fillColor"] = StickyNoteColourToString(note.Style?.FillColour ?? MiroStickyNoteColour.LightYellow),
                    ["textAlign"] = TextAlignToString(note.Style?.TextAlign ?? MiroTextAlign.Center),
                    ["textAlignVertical"] = TextAlignVerticalToString(note.Style?.TextAlignVertical ?? MiroTextAlignVertical.Top)
                },
                ["position"] = new JObject
                {
                    ["x"] = note.Position?.X ?? 0,
                    ["y"] = note.Position?.Y ?? 0,
                    ["origin"] = "center",
                    ["relativeTo"] = "canvas_center"
                },
                ["geometry"] = new JObject
                {
                    ["width"] = note.Geometry?.Width ?? 200
                }
            };

            if (!string.IsNullOrEmpty(note.ParentId))
                body["parent"] = new JObject { ["id"] = note.ParentId };

            return body.ToString(Newtonsoft.Json.Formatting.None);
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static string StickyNoteColourToString(MiroStickyNoteColour colour)
        {
            switch (colour)
            {
                case MiroStickyNoteColour.LightYellow:  return "light_yellow";
                case MiroStickyNoteColour.Yellow:       return "yellow";
                case MiroStickyNoteColour.Orange:       return "orange";
                case MiroStickyNoteColour.LightGreen:   return "light_green";
                case MiroStickyNoteColour.Green:        return "green";
                case MiroStickyNoteColour.DarkGreen:    return "dark_green";
                case MiroStickyNoteColour.Cyan:         return "cyan";
                case MiroStickyNoteColour.LightPink:    return "light_pink";
                case MiroStickyNoteColour.Pink:         return "pink";
                case MiroStickyNoteColour.Violet:       return "violet";
                case MiroStickyNoteColour.Red:          return "red";
                case MiroStickyNoteColour.LightBlue:    return "light_blue";
                case MiroStickyNoteColour.Blue:         return "blue";
                case MiroStickyNoteColour.DarkBlue:     return "dark_blue";
                case MiroStickyNoteColour.Gray:         return "gray";
                case MiroStickyNoteColour.Black:        return "black";
                default:                                return "light_yellow";
            }
        }

        private static string StickyNoteShapeToString(MiroStickyNoteShape shape)
        {
            return shape == MiroStickyNoteShape.Rectangle ? "rectangle" : "square";
        }

        /***************************************************/
    }
}
