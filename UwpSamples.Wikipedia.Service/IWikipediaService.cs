namespace UwpSamples.Wikipedia.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWikipediaService
    {
        Task<List<WikipediaPage>> SearchAsync(string pageTitle);
    }
}