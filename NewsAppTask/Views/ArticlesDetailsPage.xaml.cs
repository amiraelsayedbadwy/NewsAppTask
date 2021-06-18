using System;
using System.Collections.Generic;
using NewsAppTask.Models;
using NewsAppTask.ViewModel;
using Xamarin.Forms;

namespace NewsAppTask.Views
{
    public partial class ArticlesDetailsPage : ContentPage
    {
        public ArticlesDetailsPage(Article article)
        {
            InitializeComponent();
            BindingContext = new ArticleDetialViewModel(article);
        }
    }
}
