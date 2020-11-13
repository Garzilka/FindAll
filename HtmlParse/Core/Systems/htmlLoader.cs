using System.Net.Http;
using System.Net;
using System.Threading.Tasks;



namespace HtmlParse.Core
{
    class htmlLoader
    {
        readonly HttpClient Client;
        readonly string url;

        public htmlLoader(IParserSettings settings)
        {
            Client = new HttpClient();
            url = $"{settings.BaseURL}/{settings.Prefix}/";
        }

        public async Task<string> GetSourceByPageId(int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await Client.GetAsync(currentUrl);

            string source = null;
            if(response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
