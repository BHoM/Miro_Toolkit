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

        public static MiroItem ItemFromMiro(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;

            JObject j = JObject.Parse(json);
            return ParseItem(j);
        }

        public static List<MiroItem> ItemsFromMiro(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return new List<MiroItem>();

            JObject root = JObject.Parse(json);
            JArray data = root["data"] as JArray;

            if (data == null)
                return new List<MiroItem>();

            return data
                .OfType<JObject>()
                .Select(ParseItem)
                .Where(item => item != null)
                .ToList();
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static MiroItem ParseItem(JObject j)
        {
            if (j == null)
                return null;

            string type = j["type"]?.ToString() ?? "";

            MiroItem item;
            switch (type)
            {
                case "sticky_note":
                    item = ParseStickyNote(j);
                    break;
                case "shape":
                    item = ParseShape(j);
                    break;
                case "text":
                    item = ParseText(j);
                    break;
                default:
                    BH.Engine.Base.Compute.RecordNote($"Miro item of type '{type}' was returned but is not fully modelled in the BHoM oM. \n" +
                        "Only sticky_note, shape, and text items are converted to typed objects.");
                    return null;
            }

            if (item != null)
            {
                item.MiroItemId = j["id"]?.ToString() ?? "";
                item.Position = ParsePosition(j["position"] as JObject);
                item.Geometry = ParseGeometry(j["geometry"] as JObject);
                item.ParentId = j["parent"]?["id"]?.ToString() ?? "";
            }

            return item;
        }

        private static MiroStickyNote ParseStickyNote(JObject j)
        {
            JObject data = j["data"] as JObject;
            JObject style = j["style"] as JObject;

            return new MiroStickyNote
            {
                Content = data?["content"]?.ToString() ?? "",
                Shape = ParseStickyNoteShape(data?["shape"]?.ToString()),
                Style = new MiroStickyNoteStyle
                {
                    FillColour = ParseStickyNoteColour(style?["fillColor"]?.ToString()),
                    TextAlign = ParseTextAlign(style?["textAlign"]?.ToString()),
                    TextAlignVertical = ParseTextAlignVertical(style?["textAlignVertical"]?.ToString())
                }
            };
        }

        private static MiroShape ParseShape(JObject j)
        {
            JObject data = j["data"] as JObject;
            JObject style = j["style"] as JObject;

            return new MiroShape
            {
                ShapeType = ParseShapeType(data?["shape"]?.ToString()),
                Content = data?["content"]?.ToString() ?? "",
                Style = new MiroShapeStyle
                {
                    FillColour = style?["fillColor"]?.ToString() ?? "#ffffff",
                    BorderColour = style?["borderColor"]?.ToString() ?? "#1a1a1a",
                    Colour = style?["color"]?.ToString() ?? "#1a1a1a",
                    TextAlign = ParseTextAlign(style?["textAlign"]?.ToString()),
                    TextAlignVertical = ParseTextAlignVertical(style?["textAlignVertical"]?.ToString()),
                    BorderStyle = ParseBorderStyle(style?["borderStyle"]?.ToString())
                }
            };
        }

        private static MiroText ParseText(JObject j)
        {
            JObject data = j["data"] as JObject;
            JObject style = j["style"] as JObject;

            return new MiroText
            {
                Content = data?["content"]?.ToString() ?? "",
                Style = new MiroTextStyle
                {
                    Colour = style?["color"]?.ToString() ?? "#1a1a1a",
                    TextAlign = ParseTextAlign(style?["textAlign"]?.ToString()),
                    FillColour = style?["fillColor"]?.ToString() ?? "transparent"
                }
            };
        }

        private static MiroPosition ParsePosition(JObject j)
        {
            if (j == null) return new MiroPosition();
            return new MiroPosition
            {
                X = j["x"]?.ToObject<double>() ?? 0,
                Y = j["y"]?.ToObject<double>() ?? 0
            };
        }

        private static MiroGeometry ParseGeometry(JObject j)
        {
            if (j == null) return new MiroGeometry();
            return new MiroGeometry
            {
                Width = j["width"]?.ToObject<double>() ?? 200,
                Height = j["height"]?.ToObject<double>() ?? 0,
                Rotation = j["rotation"]?.ToObject<double>() ?? 0
            };
        }

        private static MiroStickyNoteShape ParseStickyNoteShape(string value)
        {
            return value == "rectangle" ? MiroStickyNoteShape.Rectangle : MiroStickyNoteShape.Square;
        }

        private static MiroStickyNoteColour ParseStickyNoteColour(string value)
        {
            switch (value)
            {
                case "yellow":      return MiroStickyNoteColour.Yellow;
                case "orange":      return MiroStickyNoteColour.Orange;
                case "light_green": return MiroStickyNoteColour.LightGreen;
                case "green":       return MiroStickyNoteColour.Green;
                case "dark_green":  return MiroStickyNoteColour.DarkGreen;
                case "cyan":        return MiroStickyNoteColour.Cyan;
                case "light_pink":  return MiroStickyNoteColour.LightPink;
                case "pink":        return MiroStickyNoteColour.Pink;
                case "violet":      return MiroStickyNoteColour.Violet;
                case "red":         return MiroStickyNoteColour.Red;
                case "light_blue":  return MiroStickyNoteColour.LightBlue;
                case "blue":        return MiroStickyNoteColour.Blue;
                case "dark_blue":   return MiroStickyNoteColour.DarkBlue;
                case "gray":        return MiroStickyNoteColour.Gray;
                case "black":       return MiroStickyNoteColour.Black;
                default:            return MiroStickyNoteColour.LightYellow;
            }
        }

        private static MiroShapeType ParseShapeType(string value)
        {
            switch (value)
            {
                case "round_rectangle": return MiroShapeType.RoundRectangle;
                case "circle":          return MiroShapeType.Circle;
                case "triangle":        return MiroShapeType.Triangle;
                case "rhombus":         return MiroShapeType.Rhombus;
                case "parallelogram":   return MiroShapeType.Parallelogram;
                case "trapezoid":       return MiroShapeType.Trapezoid;
                case "pentagon":        return MiroShapeType.Pentagon;
                case "hexagon":         return MiroShapeType.Hexagon;
                case "octagon":         return MiroShapeType.Octagon;
                case "star":            return MiroShapeType.Star;
                case "cross":           return MiroShapeType.Cross;
                case "arrow":           return MiroShapeType.Arrow;
                case "callout":         return MiroShapeType.Callout;
                default:                return MiroShapeType.Rectangle;
            }
        }

        private static MiroTextAlign ParseTextAlign(string value)
        {
            switch (value)
            {
                case "left":  return MiroTextAlign.Left;
                case "right": return MiroTextAlign.Right;
                default:      return MiroTextAlign.Center;
            }
        }

        private static MiroTextAlignVertical ParseTextAlignVertical(string value)
        {
            switch (value)
            {
                case "top":    return MiroTextAlignVertical.Top;
                case "bottom": return MiroTextAlignVertical.Bottom;
                default:       return MiroTextAlignVertical.Middle;
            }
        }

        private static MiroBorderStyle ParseBorderStyle(string value)
        {
            switch (value)
            {
                case "dotted": return MiroBorderStyle.Dotted;
                case "dashed": return MiroBorderStyle.Dashed;
                default:       return MiroBorderStyle.Normal;
            }
        }

        /***************************************************/
    }
}
