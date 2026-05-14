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

        public static string ToMiro(this MiroShape shape)
        {
            MiroShapeStyle style = shape.Style ?? new MiroShapeStyle();

            var body = new JObject
            {
                ["data"] = new JObject
                {
                    ["shape"] = ShapeTypeToString(shape.ShapeType),
                    ["content"] = shape.Content ?? ""
                },
                ["style"] = new JObject
                {
                    ["fillColor"] = style.FillColour,
                    ["fillOpacity"] = style.FillOpacity.ToString("F2"),
                    ["borderColor"] = style.BorderColour,
                    ["borderWidth"] = style.BorderWidth.ToString("F0"),
                    ["borderStyle"] = BorderStyleToString(style.BorderStyle),
                    ["borderOpacity"] = style.BorderOpacity.ToString("F2"),
                    ["color"] = style.Colour,
                    ["fontSize"] = style.FontSize.ToString(),
                    ["textAlign"] = TextAlignToString(style.TextAlign),
                    ["textAlignVertical"] = TextAlignVerticalToString(style.TextAlignVertical)
                },
                ["position"] = new JObject
                {
                    ["x"] = shape.Position?.X ?? 0,
                    ["y"] = shape.Position?.Y ?? 0,
                    ["origin"] = "center",
                    ["relativeTo"] = "canvas_center"
                },
                ["geometry"] = new JObject
                {
                    ["width"] = shape.Geometry?.Width ?? 200,
                    ["height"] = shape.Geometry?.Height ?? 200,
                    ["rotation"] = shape.Geometry?.Rotation ?? 0
                }
            };

            if (!string.IsNullOrEmpty(shape.ParentId))
                body["parent"] = new JObject { ["id"] = shape.ParentId };

            return body.ToString(Newtonsoft.Json.Formatting.None);
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static string ShapeTypeToString(MiroShapeType shapeType)
        {
            switch (shapeType)
            {
                case MiroShapeType.Rectangle:       return "rectangle";
                case MiroShapeType.RoundRectangle:  return "round_rectangle";
                case MiroShapeType.Circle:          return "circle";
                case MiroShapeType.Triangle:        return "triangle";
                case MiroShapeType.Rhombus:         return "rhombus";
                case MiroShapeType.Parallelogram:   return "parallelogram";
                case MiroShapeType.Trapezoid:       return "trapezoid";
                case MiroShapeType.Pentagon:        return "pentagon";
                case MiroShapeType.Hexagon:         return "hexagon";
                case MiroShapeType.Octagon:         return "octagon";
                case MiroShapeType.Star:            return "star";
                case MiroShapeType.Cross:           return "cross";
                case MiroShapeType.Arrow:           return "arrow";
                case MiroShapeType.Callout:         return "callout";
                default:                            return "rectangle";
            }
        }

        private static string BorderStyleToString(MiroBorderStyle borderStyle)
        {
            switch (borderStyle)
            {
                case MiroBorderStyle.Dotted: return "dotted";
                case MiroBorderStyle.Dashed: return "dashed";
                default:                     return "normal";
            }
        }

        private static string TextAlignToString(MiroTextAlign align)
        {
            switch (align)
            {
                case MiroTextAlign.Left:  return "left";
                case MiroTextAlign.Right: return "right";
                default:                  return "center";
            }
        }

        private static string TextAlignVerticalToString(MiroTextAlignVertical align)
        {
            switch (align)
            {
                case MiroTextAlignVertical.Top:    return "top";
                case MiroTextAlignVertical.Bottom: return "bottom";
                default:                           return "middle";
            }
        }

        /***************************************************/
    }
}
