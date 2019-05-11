using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RobloxNET
{
    public class RobloxUsers : IDisposable
    {
        private HttpClient httpClient;

        /// <summary>
        /// Initializes a new Instance of the <see cref="RobloxUsers"/> class.
        /// </summary>
        public RobloxUsers()
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
        /// Retrieves user information for the specified user ID as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>. 
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns><see cref="RUser"/></returns>
        public async Task<RUser> GetUserAsync(long userId)
        {
            RUser rUser;
            string apiUrl = $"http://api.roblox.com/users/{userId.ToString()}";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        rUser = JsonConvert.DeserializeObject<RUser>(responseString);
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rUser;
            }
        }

        /// <summary>
        /// Retrieves user information for the specified user username as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>. 
        /// </summary>
        /// <param name="userId">The name of the user.</param>
        /// <returns><see cref="RUser"/></returns>
        public async Task<RUser> GetUserAsync(string username)
        {
            RUser rUser;
            string apiUrl = $"http://api.roblox.com/users/get-by-username?username={username}";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        rUser = JsonConvert.DeserializeObject<RUser>(responseString);
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rUser;
            }
        }
    }

    public class RUser
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }
    }
}
