namespace UwpSamples.Wikipedia.Service
{
    #region Namespace Imports

    using System.Net;

    using Newtonsoft.Json;

    #endregion

    public class WikipediaPage
    {
        #region Properties

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        public string Uri => $"https://en.wikipedia.org/wiki/{WebUtility.UrlEncode(Title.Replace(' ', '_'))}";

        #endregion
    }
}