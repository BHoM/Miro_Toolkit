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
    [Description("Shape type for Miro shape items.")]
    public enum MiroShapeType
    {
        [Description("Rectangle shape.")]
        Rectangle,
        [Description("Rectangle with rounded corners.")]
        RoundRectangle,
        [Description("Circle or ellipse shape.")]
        Circle,
        [Description("Triangle shape.")]
        Triangle,
        [Description("Rhombus (diamond) shape.")]
        Rhombus,
        [Description("Parallelogram shape.")]
        Parallelogram,
        [Description("Trapezoid shape.")]
        Trapezoid,
        [Description("Pentagon shape.")]
        Pentagon,
        [Description("Hexagon shape.")]
        Hexagon,
        [Description("Octagon shape.")]
        Octagon,
        [Description("Star shape.")]
        Star,
        [Description("Cross shape.")]
        Cross,
        [Description("Arrow shape.")]
        Arrow,
        [Description("Callout (speech bubble) shape.")]
        Callout
    }
}
