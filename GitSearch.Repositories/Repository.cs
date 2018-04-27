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
            var jsonEntity = await GetResponseString(uri);
            return JsonConvert.DeserializeObject<TEntity>(jsonEntity);
        }

        protected static async Task<string> GetResponseString(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
                try
                {
                    return await httpClient.GetStringAsync(uri);
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine(e);
                }

                return "";
            }
        }

        protected string BuildUri(string appendables, Dictionary<string, string> queryParameters = null)
        {
            var builder = new UriBuilder($"{ApiUri}/{appendables}") {Port = -1};
            if (queryParameters == null) return builder.ToString();

            var query = HttpUtility.ParseQueryString(builder.Query);
            foreach (var entry in queryParameters)
            {
                query[entry.Key] = entry.Value;
            }
            builder.Query = query.ToString();

            return builder.ToString();
        }
    }
}
