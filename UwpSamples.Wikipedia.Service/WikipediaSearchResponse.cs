namespace UwpSamples.Wikipedia.Service
{
    #region Namespace Imports

    using Newtonsoft.Json;

    #endregion

    public class WikipediaSearchResponse
    {
        #region Properties

        [JsonProperty("query")]
        public WikipediaSearchResults Results { get; set; }

        #endregion
    }
}