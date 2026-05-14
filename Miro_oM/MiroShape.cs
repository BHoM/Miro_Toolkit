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

using System.ComponentModel;

namespace BH.oM.Adapters.Miro
{
    [Description("A geometric shape item on a Miro board. Shapes can contain optional text labels \n" +
        "and support a wide range of outline types suitable for diagrams and flowcharts.")]
    public class MiroShape : MiroItem
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Geometric shape type that determines the outline of this item.")]
        public virtual MiroShapeType ShapeType { get; set; } = MiroShapeType.Rectangle;

        [Description("Optional text label displayed inside the shape. Supports basic HTML formatting.")]
        public virtual string Content { get; set; } = "";

        [Description("Visual style properties controlling fill, border, and text appearance of the shape.")]
        public virtual MiroShapeStyle Style { get; set; } = new MiroShapeStyle();

        /***************************************************/
    }
}
