namespace UwpSamples.Wikipedia.Service
{
    #region Namespace Imports

    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    #endregion

    public class WikipediaService : IWikipediaService
    {
        #region Public Methods

        public async Task<List<WikipediaPage>> SearchAsync(string pageTitle)
        {
            var client = new HttpClient();

            pageTitle = WebUtility.UrlEncode(pageTitle);

            string requestUri =
                $"https://en.wikipedia.org//w/api.php?action=query&list=search&format=json&srsearch={pageTitle}";

            string json = await client.GetStringAsync(requestUri).ConfigureAwait(false);

            JsonSerializer serializer = JsonSerializer.CreateDefault();

            using (JsonReader jsonReader = new JsonTextReader(new StringReader(json)))
            {
                var response = serializer.Deserialize<WikipediaSearchResponse>(jsonReader);

                return response.Results.Pages;
            }
        }

        #endregion
    }
}