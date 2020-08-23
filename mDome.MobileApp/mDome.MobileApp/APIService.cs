using mDome.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Xamarin.Forms;

namespace mDome.MobileApp
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static Model.UserProfile loggedProfile { get; set; } = null;

        private string _route = null;
        private string _apiUrl = "http://localhost:61090/api";
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> Get<T>(object search)
        {
            try
            {
                var url = $"{_apiUrl}/{ _route}";
                if (search != null)
                {
                    url += '?';
                    url += await search.ToQueryString();
                }
                var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Not authenticated", "OK");
                }
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                throw;
            }

        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{ _route}/{id}";
            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
           // return await url.GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{ _route}";
            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";
                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<T> Delete<T>(object id)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";
                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();

            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
    }
}
