using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using GitSearch.Domain.Models;
using GitSearch.Repositories.Interfaces;
using Newtonsoft.Json;

namespace GitSearch.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected const string ApiUri = "https://api.github.com";

        public async Task<TEntity> GetByName(string action, string name)
        {
            var uri =  BuildUri($"{action}/{name}");
            var response = await GetResponseString(uri);
            return JsonConvert.DeserializeObject<TEntity>(await response.Content.ReadAsStringAsync());
        }

        protected static async Task<HttpResponseMessage> GetResponseString(Uri uri)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
                try
                {
                    var response = await httpClient.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    return response;
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        protected Uri BuildUri(string appendables, Dictionary<string, string> queryParameters = null)
        {
            var builder = new UriBuilder($"{ApiUri}/{appendables}") {Port = -1};
            if (queryParameters == null) return builder.Uri;

            var query = HttpUtility.ParseQueryString(builder.Query);
            foreach (var entry in queryParameters)
            {
                query[entry.Key] = entry.Value;
            }
            builder.Query = query.ToString();

            return builder.Uri;
        }
    }
}
