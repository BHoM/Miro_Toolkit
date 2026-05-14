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
using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.Engine.Adapters.Miro
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Creates a MiroBoard object representing a Miro collaborative canvas. \n" +
            "Push this object via the MiroAdapter to create the board on the Miro platform.")]
        [Input("name", "Name of the board (1-60 characters). Defaults to 'Untitled' if left empty.")]
        [Input("description", "Optional description of the board (0-300 characters).")]
        [Input("teamId", "Optional Miro team identifier. When provided the board is created within that team's workspace.")]
        [Input("projectId", "Optional Miro project identifier to associate the board with a project.")]
        [Output("board", "A MiroBoard object ready to be pushed via the MiroAdapter.")]
        public static MiroBoard MiroBoard(string name = "Untitled", string description = "", string teamId = "", string projectId = "")
        {
            return new MiroBoard
            {
                Name = name,
                Description = description,
                TeamId = teamId,
                ProjectId = projectId
            };
        }

        /***************************************************/
    }
}
