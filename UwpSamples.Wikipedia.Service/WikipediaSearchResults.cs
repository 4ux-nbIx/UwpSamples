namespace UwpSamples.Wikipedia.Service
{
    #region Namespace Imports

    using System.Collections.Generic;

    using Newtonsoft.Json;

    #endregion

    public class WikipediaSearchResults
    {
        #region Properties

        [JsonProperty("search")]
        public List<WikipediaPage> Pages { get; set; }

        [JsonProperty("searchinfo")]
        public WikipediaSearchInfo SearchInfo { get; set; }

        #endregion
    }
}