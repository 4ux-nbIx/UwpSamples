namespace UwpSamples.Wikipedia.Service
{
    #region Namespace Imports

    using Newtonsoft.Json;

    #endregion

    public class WikipediaPage
    {
        #region Properties

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        #endregion
    }
}