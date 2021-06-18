using System;
using System.Threading.Tasks;
using NewsAppTask.Communication.Response;
using Refit;

namespace NewsAppTask.Communication.Service
{
    [Headers("Content-Type: application/json")]
    public interface INewsAppApi
    {
        [Get("/articles?source=the-next-web&apiKey=1c0f731cca954a13875e6965f9c7e9de")]
        Task<ArticlesResponseModel> GetArticles();
        [Get("/articles?source=associated-press&apiKey=1c0f731cca954a13875e6965f9c7e9de")]
        Task<ArticlesResponseModel> GetMoreArticles();
    }
}
