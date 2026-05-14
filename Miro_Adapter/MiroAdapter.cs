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
using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.Adapter.Miro
{
    [Description("Adapter for the Miro collaborative whiteboard platform. \n" +
        "Enables creation and retrieval of Miro boards and board items (sticky notes, shapes, text) \n" +
        "via the Miro REST API v2. Boards provide a shared digital canvas for collaborative \n" +
        "diagramming, planning, and ideation workflows that can be linked to BHoM data.")]
    public partial class MiroAdapter : BHoMAdapter
    {
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        [Description("Creates a MiroAdapter configured to connect to the Miro REST API v2. \n" +
            "Generate your access token from the Miro developer portal at https://miro.com/app/settings/user-profile/apps.")]
        [Input("token", "Miro API access token (Bearer token). This credential is used to authenticate every request \n" +
            "and must be kept confidential. Pass it from a secure parameter source rather than hard-coding it.")]
        [Input("baseUrl", "Base URL of the Miro REST API. Defaults to 'https://api.miro.com/v2'. Override only if targeting a custom proxy.")]
        [Output("adapter", "A MiroAdapter ready to push boards and items, or pull and remove existing ones.")]
        public MiroAdapter(string token, string baseUrl = "https://api.miro.com/v2")
        {
            m_AdapterSettings.DefaultPushType = oM.Adapter.PushType.CreateOnly;
            m_Token = token;
            m_BaseUrl = baseUrl.TrimEnd('/');
        }

        /***************************************************/
        /**** Private Fields                            ****/
        /***************************************************/

        private readonly string m_Token;
        private readonly string m_BaseUrl;

        /***************************************************/
    }
}
