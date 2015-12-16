namespace UwpSamples.Wikipedia.Service
{
    #region Namespace Imports

    using Newtonsoft.Json;

    #endregion

    public class WikipediaSearchInfo
    {
        #region Properties

        [JsonProperty("totalhits")]
        public int TotalHits { get; set; }

        #endregion
    }
}