using System;
using System.Collections.Generic;
using NewsAppTask.Models;

namespace NewsAppTask.Communication.Response
{
    public class ArticlesResponseModel
    {
        public string status { get; set; }
        public string source { get; set; }
        public string sortBy { get; set; }
        public List<Article> articles { get; set; }
    }
}
