using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RobloxNET.JSON;

namespace RobloxNET
{
    /// <summary>
    /// A class which is used for getting Roblox group information.
    /// </summary>
    public class RobloxGroups : IDisposable
    {
        private HttpClient httpClient;

        /// <summary>
        /// Initializes a new Instance of the <see cref="RobloxGroups"/> class.
        /// </summary>
        public RobloxGroups()
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
        /// Retrieves the list of groups of the specified user as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>. 
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns><see cref="RGroupUser"/></returns>
        public async Task<RGroupUser[]> GetUsersGroupsAsync(long userId)
        {
            RGroupUser[] rGroups;
            string apiUrl = $"http://api.roblox.com/users/{userId.ToString()}/groups";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        rGroups = JsonConvert.DeserializeObject<RGroupUser[]>(responseString);
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rGroups;
            }
        }

        /// <summary>
        /// Retrieves information for the specified group id as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>. 
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <returns><see cref="RGroup"/></returns>
        public async Task<RGroup> GetGroupInfoAsync(long groupId)
        {
            RGroup rGroup;
            string apiUrl = $"https://api.roblox.com/groups/{groupId.ToString()}";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        rGroup = JsonConvert.DeserializeObject<RGroup>(responseString);
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rGroup;
            }
        }

        /// <summary>
        /// Retrieves a paged list of allied groups for the specified group id as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>. 
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <returns><see cref="RGroup[]"/></returns>
        public async Task<RGroup[]> GetGroupAlliesAsync(long groupId)
        {
            RGroup[] rGroups;
            GroupAlliesEnemiesJSON groupAlliesJSON;

            string apiUrl = $"https://api.roblox.com/groups/{groupId.ToString()}/allies";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        groupAlliesJSON = JsonConvert.DeserializeObject<GroupAlliesEnemiesJSON>(responseString);
                        rGroups = groupAlliesJSON.Groups;
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rGroups;
            }
        }

        /// <summary>
        /// Retrieves a specified page of allied groups for the specified group id as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>. 
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <returns><see cref="RGroup[]"/></returns>
        public async Task<RGroup[]> GetGroupAlliesAsync(long groupId, int page)
        {
            RGroup[] rGroups;
            GroupAlliesEnemiesJSON groupAlliesJSON;

            string apiUrl = $"https://api.roblox.com/groups/{groupId.ToString()}/allies?page={page.ToString()}";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        groupAlliesJSON = JsonConvert.DeserializeObject<GroupAlliesEnemiesJSON>(responseString);
                        rGroups = groupAlliesJSON.Groups;
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rGroups;
            }
        }

        /// <summary>
        /// Retrieves a paged list of enemy groups for the specified group id as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>. 
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <returns><see cref="RGroup[]"/></returns>
        public async Task<RGroup[]> GetGroupEnemiesAsync(long groupId)
        {
            RGroup[] rGroups;
            GroupAlliesEnemiesJSON groupAlliesJSON;

            string apiUrl = $"https://api.roblox.com/groups/{groupId.ToString()}/enemies";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        groupAlliesJSON = JsonConvert.DeserializeObject<GroupAlliesEnemiesJSON>(responseString);
                        rGroups = groupAlliesJSON.Groups;
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rGroups;
            }
        }

        /// <summary>
        /// Retrieves a specified page of enemy groups for the specified group id as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>. 
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <returns><see cref="RGroup[]"/></returns>
        public async Task<RGroup[]> GetGroupEnemiesAsync(long groupId, int page)
        {
            RGroup[] rGroups;
            GroupAlliesEnemiesJSON groupAlliesJSON;

            string apiUrl = $"https://api.roblox.com/groups/{groupId.ToString()}/enemies?page={page.ToString()}";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        groupAlliesJSON = JsonConvert.DeserializeObject<GroupAlliesEnemiesJSON>(responseString);
                        rGroups = groupAlliesJSON.Groups;
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rGroups;
            }
        }
    }

    /// <summary>
    /// A class which is used for getting an users group information.
    /// </summary>
    public class RGroupUser
    {
        /// <summary>
        /// The id of the group.
        /// </summary>
        [JsonProperty("Id")]
        public long Id { get; set; }

        /// <summary>
        /// The name of the group.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The emblem id of the group.
        /// </summary>
        [JsonProperty("EmblemId")]
        public long EmblemId { get; set; }

        /// <summary>
        /// The emblem url of the group.
        /// </summary>
        [JsonProperty("EmblemUrl")]
        public string EmblemUrl { get; set; }

        /// <summary>
        /// The rank which the specified user has at the group.
        /// </summary>
        [JsonProperty("Rank")]
        public int Rank { get; set; }

        /// <summary>
        /// The role which the specified user has at the group.
        /// </summary>
        [JsonProperty("Role")]
        public string Role { get; set; }

        /// <summary>
        /// Whether the specified user is in the groups clan.
        /// </summary>
        [JsonProperty("IsInClan")]
        public bool IsInClan { get; set; }

        /// <summary>
        /// Whether the specified user set this group as his primary.
        /// </summary>
        [JsonProperty("IsPrimary")]
        public bool IsPrimary { get; set; }
    }

    /// <summary>
    /// A class which is used for getting a groups information.
    /// </summary>
    public class RGroup
    {
        /// <summary>
        /// The name of the group.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The id of the group.
        /// </summary>
        [JsonProperty("Id")]
        public long Id { get; set; }

        /// <summary>
        /// The owner of the group.
        /// </summary>
        [JsonProperty("Owner")]
        public RGroupOwner Owner { get; set; }

        /// <summary>
        /// The emblem url of the group. 
        /// </summary>
        [JsonProperty("EmblemUrl")]
        public string EmblemUrl { get; set; }

        /// <summary>
        /// The description of the group.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The roles of the group.
        /// </summary>
        [JsonProperty("Roles")]
        public RGroupRole[] Roles { get; set; }
    }

    /// <summary>
    /// A class which is used for getting the groups owner information.
    /// </summary>
    public class RGroupOwner
    {
        /// <summary>
        /// The username of the groups owner.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The id of the groups owner.
        /// </summary>
        [JsonProperty("Id")]
        public long Id { get; set; }
    }

    /// <summary>
    /// A class which is used for getting the groups role information.
    /// </summary>
    public class RGroupRole
    {
        /// <summary>
        /// The name of the group role.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The rank which the role has.
        /// </summary>
        [JsonProperty("Rank")]
        public int Rank { get; set; }
    }

}
