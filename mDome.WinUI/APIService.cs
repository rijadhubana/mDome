using mDome.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using System.Windows.Forms;

namespace mDome.WinUI
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private string _route = null;
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> Get<T>(object search)
        {
            try
            {
                var url = $"{ Properties.Settings.Default.API}/{ _route}";
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
                    MessageBox.Show("Wrong username or password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }

        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{ Properties.Settings.Default.API}/{ _route}/{id}";
            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
           // return await url.GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{ Properties.Settings.Default.API}/{ _route}";
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

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.API}/{_route}/{id}";
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

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
        public async Task<T> Delete<T>(object id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.API}/{_route}/{id}";
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

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
    }
}
