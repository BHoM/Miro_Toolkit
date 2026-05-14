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
using System.Text;

namespace BH.Engine.Adapters.Miro
{
    public static partial class Compute
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static string Post(string url, string token, string jsonBody)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                BH.Engine.Base.Compute.RecordError("URL must not be empty.");
                return null;
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                BH.Engine.Base.Compute.RecordError("A Bearer token is required to authenticate with the Miro API.");
                return null;
            }

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(jsonBody ?? "{}", Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                {
                    string body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    BH.Engine.Base.Compute.RecordError($"Miro POST request failed. Status: {(int)response.StatusCode} {response.ReasonPhrase}. URL: {url}. Response: {body}");
                    return null;
                }

                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }

        /***************************************************/
    }
}
