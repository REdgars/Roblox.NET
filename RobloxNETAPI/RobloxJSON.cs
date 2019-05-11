using Newtonsoft.Json;

namespace RobloxNET.JSON
{

    /// <summary>
    /// The class used to deserialize friendship count JSON
    /// </summary>
    public class FriendShipCountJSON
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

    /// <summary>
    /// The class used to deserialize following exists JSON
    /// </summary>
    public class FollowingExistsJSON
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("isFollowing")]
        public bool IsFollowing { get; set; }
    }

    /// <summary>
    /// The class used to deserialize group allies and enemies JSON
    /// </summary>
    public class GroupAlliesEnemiesJSON
    {
        [JsonProperty("Groups")]
        public RGroup[] Groups { get; set; }

        [JsonProperty("FinalPage")]
        public bool FinalPage { get; set; }
    }
}
