using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RobloxNET
{
    /// <summary>
    /// A class which is used to get marketplace products information.
    /// </summary>
    public class RobloxMarketplace : IDisposable
    {
        private HttpClient httpClient;

        /// <summary>
        /// Initializes a new Instance of the <see cref="RobloxMarketplace"/> class.
        /// </summary>
        public RobloxMarketplace()
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
        /// Returns the product info for the specified asset as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>. 
        /// </summary>
        /// <param name="assetId">The ID of the asset.</param>
        /// <returns><see cref="RProductInfo"/></returns>
        public async Task<RProductInfo> GetProductInfoAsync(long assetId)
        {
            RProductInfo rProductInfo;
            string apiUrl = $"http://api.roblox.com/marketplace/productinfo?assetId={assetId.ToString()}";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content)
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        rProductInfo = JsonConvert.DeserializeObject<RProductInfo>(responseString);
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rProductInfo;
            }
        }

        /// <summary>
        /// Returns the product info for the specified game pass as an asynchronus operation. Throws a <see cref="HttpRequestException"/> if the <see cref="HttpStatusCode"/> isn't <see cref="HttpStatusCode.OK"/>. 
        /// </summary>
        /// <param name="assetId">The ID of the game pass.</param>
        /// <returns><see cref="RProductInfo"/></returns>
        public async Task<RProductInfo> GetGamePassProductInfoAsync(long assetId)
        {
            RProductInfo rProductInfo;
            string apiUrl = $"http://api.roblox.com/marketplace/game-pass-product-info?assetId={assetId.ToString()}";

            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl))
            {
                HttpStatusCode responseCode = responseMessage.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    using (HttpContent responseContent = responseMessage.Content) {
                        string responseString = await responseContent.ReadAsStringAsync();

                        rProductInfo = JsonConvert.DeserializeObject<RProductInfo>(responseString);
                    }
                }
                else
                    throw new HttpRequestException($"HttpResponseStatusCode did not return OK (200), instead it returned {responseCode.ToString()}");

                return rProductInfo;
            }
        }
    }

    /// <summary>
    /// Marketplace product information
    /// </summary>
    public class RProductInfo
    {
        [JsonProperty("TargetId")]
        public long TargetId { get; set; }

        [JsonProperty("ProductType")]
        public string ProductType { get; set; }

        [JsonProperty("AssetId")]
        public long AssetId { get; set; }

        [JsonProperty("ProductId")]
        public long ProductId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("AssetTypeId")]
        public int AssetTypeId { get; set; }

        [JsonProperty("Creator")]
        public RProductCreator Creator { get; set; }

        [JsonProperty("IconImageAssetId")]
        public int IconImageAssetId { get; set; }

        [JsonProperty("Created")]
        public string Created { get; set; }

        [JsonProperty("Updated")]
        public string Updated { get; set; }

        [JsonProperty("PriceInRobux")]
        public int PriceInRobux { get; set; }

        [JsonProperty("Sales")]
        public int Sales { get; set; }

        [JsonProperty("IsNew")]
        public bool IsNew { get; set; }

        [JsonProperty("IsForSale")]
        public bool IsForSale { get; set; }

        [JsonProperty("IsPublicDomain")]
        public bool IsPublicDomain { get; set; }

        [JsonProperty("IsLimited")]
        public bool IsLimited { get; set; }

        [JsonProperty("IsLimitedUnique")]
        public bool IsLimitedUnique { get; set; }

        [JsonProperty("Remaining")]
        public int Remaining { get; set; }

        [JsonProperty("MinimumMembershipLevel")]
        public int MinimumMembershipLevel { get; set; }

        [JsonProperty("ContentRatingTypeId")]
        public int ContentRatingTypeId { get; set; }
    }

    /// <summary>
    /// The product creator.
    /// </summary>
    public class RProductCreator
    {
        /// <summary>
        ///  The id of the creator.
        /// </summary>
        [JsonProperty("Id")]
        public long Id { get; set; }

        /// <summary>
        /// The name of the creator.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
