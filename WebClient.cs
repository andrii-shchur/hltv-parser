using System;
using HtmlAgilityPack;
using ScrapySharp.Network;

namespace CW
{
    public class WebClient
    {
        private static WebClient _client;
        private ScrapingBrowser _browser;
        
        private WebClient(){}

        public static WebClient GetInstance()
        {
            if (_client == null)
            {
                _client = new WebClient();
                _client._browser = new ScrapingBrowser();
            }

            return _client;
        }
        
        public HtmlNode GetPage(string url)
        {
            var pageResult = _browser.NavigateToPage(new Uri(url));
            var page = pageResult.Html;
            
            return page;
        }
    }
}