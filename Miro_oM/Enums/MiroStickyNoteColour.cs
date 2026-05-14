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
    [Description("Background fill colour options for Miro sticky note items.")]
    public enum MiroStickyNoteColour
    {
        [Description("Light yellow background.")]
        LightYellow,
        [Description("Yellow background.")]
        Yellow,
        [Description("Orange background.")]
        Orange,
        [Description("Light green background.")]
        LightGreen,
        [Description("Green background.")]
        Green,
        [Description("Dark green background.")]
        DarkGreen,
        [Description("Cyan background.")]
        Cyan,
        [Description("Light pink background.")]
        LightPink,
        [Description("Pink background.")]
        Pink,
        [Description("Violet background.")]
        Violet,
        [Description("Red background.")]
        Red,
        [Description("Light blue background.")]
        LightBlue,
        [Description("Blue background.")]
        Blue,
        [Description("Dark blue background.")]
        DarkBlue,
        [Description("Gray background.")]
        Gray,
        [Description("Black background.")]
        Black
    }
}
