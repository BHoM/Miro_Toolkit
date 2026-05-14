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

using System.Net.Http;
using System.Net.Http.Headers;

namespace BH.Engine.Adapters.Miro
{
    public static partial class Compute
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static bool Delete(string url, string token)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                BH.Engine.Base.Compute.RecordError("URL must not be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                BH.Engine.Base.Compute.RecordError("A Bearer token is required to authenticate with the Miro API.");
                return false;
            }

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                {
                    BH.Engine.Base.Compute.RecordError($"Miro DELETE request failed. Status: {(int)response.StatusCode} {response.ReasonPhrase}. URL: {url}");
                    return false;
                }

                return true;
            }
        }

        /***************************************************/
    }
}
