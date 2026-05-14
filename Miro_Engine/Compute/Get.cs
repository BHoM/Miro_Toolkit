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

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BH.Engine.Adapters.Miro
{
    public static partial class Compute
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static string Get(string url, string token, Dictionary<string, string> queryParams = null)
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

            string fullUrl = BuildUrl(url, queryParams);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(fullUrl).GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                {
                    BH.Engine.Base.Compute.RecordError($"Miro GET request failed. Status: {(int)response.StatusCode} {response.ReasonPhrase}. URL: {fullUrl}");
                    return null;
                }

                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static string BuildUrl(string baseUrl, Dictionary<string, string> queryParams)
        {
            if (queryParams == null || queryParams.Count == 0)
                return baseUrl;

            var query = new System.Text.StringBuilder();
            foreach (var kvp in queryParams)
            {
                if (string.IsNullOrEmpty(kvp.Value))
                    continue;

                if (query.Length > 0)
                    query.Append("&");

                query.Append(System.Uri.EscapeDataString(kvp.Key));
                query.Append("=");
                query.Append(System.Uri.EscapeDataString(kvp.Value));
            }

            return query.Length > 0 ? $"{baseUrl}?{query}" : baseUrl;
        }

        /***************************************************/
    }
}
