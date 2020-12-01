using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;

namespace HtmlParse.Core
{
    class htmlLoader
    {
        readonly HttpClient Client;
        readonly string url;
        IParserSettings settings;

        public htmlLoader(IParserSettings settings)
        {
            this.settings = settings;
            Client = new HttpClient();
            if (settings.EndPoint > 0)
                url = $"{settings.BaseURL}/{settings.Prefix}/";
            else
                url = $"{settings.BaseURL}/";
        }
        public async Task<string> GetHTML(int id)
        {
            if (settings.EndPoint > 0)
                return await GetSourceByPageId(id);
            else
                return await GetSourceByHref(settings.BaseURL);


        }
        public async Task<string> GetSourceByPageId(int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await Client.GetAsync(currentUrl);
            Console.WriteLine(currentUrl);
            string source = null;
            if (response != null/*&& response.StatusCode == HttpStatusCode.OK*/)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            return source;
        }
        public async Task<string> GetSourceByHref(string href)
        {
            var response = await Client.GetAsync(href);
            string source = null;
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
