using System;
using System.Net.Http;
using System.Threading.Tasks;
using NewsAppTask.Communication.Response;
using NewsAppTask.Helper;
using Refit;

namespace NewsAppTask.Communication.Service
{
    public class ArticlesService
    {
        public ArticlesService()
        {
        }
        public async Task<ArticlesResponseModel> GetArticles()
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new System.Uri(Constants.ApiKey1) };
            var api = RestService.For<INewsAppApi>(httpClient);
            var response = await api.GetArticles();
            return response;
        }
        public async Task<ArticlesResponseModel> GetMoreArticles()
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new System.Uri(Constants.ApiKey2) };
            var api = RestService.For<INewsAppApi>(httpClient);
            var response = await api.GetMoreArticles();
            return response;
        }
    }
}
