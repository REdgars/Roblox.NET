using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RobloxNET
{
    /// <summary>
    /// A class which is used to get ownership information.
    /// </summary>
    class RobloxOwnerhsip : IDisposable
    {
        private HttpClient httpClient;

        /// <summary>
        /// Initializes a new Instance of the <see cref="RobloxOwnerhsip"/> class.
        /// </summary>
        public RobloxOwnerhsip()
        {
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Disposes of the managed resources used by the <see cref="HttpClient"/>.
        /// </summary>
        public void Dispose()
        {
            httpClient.Dispose();
        }

        /// <summary>
        /// Returns whether the specified user owns the specified asset as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>. 
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="assetId">The ID of the asset.</param>
        /// <returns><see cref="bool"/></returns>
        public async Task<bool> GetUserHasAssetAsync(long userId, long assetId)
        {
            string apiUrl = $"http://api.roblox.com/ownership/hasasset?userId={userId.ToString()}&assetId={assetId.ToString()}";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        if (responseString.Contains("true"))
                            return true;
                        else if (responseString.Contains("false"))
                            return false;
                        else
                            throw new Exception("Request didn't return true nor false.");
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");
            }
        }
    }
}

