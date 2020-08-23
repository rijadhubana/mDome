using Flurl.Http;
using mDome.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mDome.WinUI
{
    public class LyricsOvhService
    {
        private readonly string _route = "https://api.lyrics.ovh/v1/";
        public LyricsOvhService()
        {

        }
        public async Task<T> Get<T>(string artistName, string trackName)
        {
            artistName = artistName.Replace(" ", "%20");
            trackName = trackName.Replace(" ", "%20");
            string url = _route + artistName + "/" + trackName;
            var result = await url.GetJsonAsync<T>();
            return result;
        }
    }
}
