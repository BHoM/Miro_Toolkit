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

namespace BH.Adapter.Miro
{
    public partial class MiroAdapter : BHoMAdapter
    {
        /***************************************************/
        /**** Private Methods - Create                  ****/
        /***************************************************/

        private bool Create(MiroShape shape)
        {
            if (shape == null)
            {
                BH.Engine.Base.Compute.RecordError("Cannot create a null MiroShape.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(shape.BoardId))
            {
                BH.Engine.Base.Compute.RecordError("MiroShape.BoardId must be set before pushing to the Miro adapter.");
                return false;
            }

            string json = shape.ToMiro();
            string response = BH.Engine.Adapters.Miro.Compute.Post(
                $"{m_BaseUrl}/boards/{shape.BoardId}/shapes", m_Token, json);

            if (response == null)
                return false;

            MiroItem created = response.ItemFromMiro();
            if (created != null)
                shape.MiroItemId = created.MiroItemId;

            return created != null;
        }

        /***************************************************/
    }
}
