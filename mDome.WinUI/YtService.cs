using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using mDome.Model;

namespace mDome.WinUI
{
    public class YtService
    {
        private string _postfix = "&key=AIzaSyBomgSG4USkNPuQKD1lUlH_kBc0v8fDbpI";
        private string _prefix = "https://www.googleapis.com/youtube/v3/search?part=snippet&q=";
        public YtService()
        {

        }
        public async Task<T> Get<T>(string searchQuery)
        {
            searchQuery = searchQuery.Replace(" ", "%20");
            string url = _prefix + searchQuery + _postfix;
            var result = await url.GetJsonAsync<T>();
            return result;
        }
    }
}
