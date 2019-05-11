using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using RobloxNET.JSON;

namespace RobloxNET
{
    /// <summary>
    /// A class which is used to get Roblox friends information.
    /// </summary>
    public class RobloxFriends : IDisposable
    {
        private HttpClient httpClient;

        /// <summary>
        /// Initializes a new Instance of the <see cref="RobloxFriends"/> class.
        /// </summary>
        public RobloxFriends()
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
        /// Retrieves a paged list of friends for the specified user as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns><see cref="RFriend"/></returns>
        public async Task<RFriend[]> GetRobloxFriendsAsync(long userId)
        {
            RFriend[] rFriends;
            string apiUrl = $"http://api.roblox.com/users/{userId.ToString()}/friends";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        rFriends = JsonConvert.DeserializeObject<RFriend[]>(responseString);
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rFriends;
            }
        }

        /// <summary>
        /// Retrieves a specified page list of friends for the specified user as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <returns><see cref="RFriend"/></returns>
        public async Task<RFriend[]> GetRobloxFriendsAsync(long userId, int page)
        {
            RFriend[] rFriends;
            string apiUrl = $"http://api.roblox.com/users/{userId.ToString()}/friends?page={page}";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        rFriends = JsonConvert.DeserializeObject<RFriend[]>(responseString);
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rFriends;
            }
        }

        /// <summary>
        /// Retrieves the number of friends for the specified user as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns<see cref="int"/>></returns>
        public async Task<int> GetFriendshipCountAsync(long userId)
        {
            int count;
            string apiUrl = $"http://api.roblox.com/user/request-friendship?userId={userId}";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        FriendShipCountJSON friendShipCountJSON = JsonConvert.DeserializeObject<FriendShipCountJSON>(responseString);
                        count = friendShipCountJSON.Count;
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return count;
            }
        }

        /// <summary>
        /// Retrieves whether followerUserId is following userId as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>.
        /// </summary>
        /// <param name="userId">The user potentially being followed.</param>
        /// <param name="followerUserId">The user potentially following the other user.</param>
        /// <returns><see cref="bool"/></returns>
        public async Task<bool> GetFollowerExistsAsync(long userId, long followerUserId)
        {
            bool isFollowing;
            string apiUrl = $"http://api.roblox.com/user/following-exists?userId={userId}&followerUserId={followerUserId}";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    HttpContent responseContent = responseMessage.Content;
                    string responseString = await responseContent.ReadAsStringAsync();

                    FollowingExistsJSON followingExistsJSON = JsonConvert.DeserializeObject<FollowingExistsJSON>(responseString);
                    isFollowing = followingExistsJSON.IsFollowing;
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return isFollowing;
            }
        }
    }

    /// <summary>
    /// A class which is used for getting an users friend information.
    /// </summary>
    public class RFriend
    {
        /// <summary>
        /// Id of the users friend.
        /// </summary>
        [JsonProperty("Id")]
        public long Id { get; set; }

        /// <summary>
        /// Username of the users friend.
        /// </summary>
        [JsonProperty("Username")]
        public string Username { get; set; }

        /// <summary>
        /// AvatarUri of the users friend.
        /// </summary>
        [JsonProperty("AvatarUri")]
        public string AvatarUri { get; set; }

        /// <summary>
        /// AvatarFinal of the users friend.
        /// </summary>
        [JsonProperty("AvatarFinal")]
        public bool AvatarFinal { get; set; }

        /// <summary>
        /// Whether the users friend is online.
        /// </summary>
        [JsonProperty("IsOnline")]
        public bool IsOnline { get; set; }
    }
}
