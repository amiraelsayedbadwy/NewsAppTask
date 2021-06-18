using System;
using System.Windows.Input;
using NewsAppTask.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NewsAppTask.ViewModel
{
    public class ArticleDetialViewModel : BaseViewModel
    {
        public Article GetArticle { get; set; }
        public ICommand OpenWebSiteCommand { get; set; }
        public ArticleDetialViewModel(Article article)
        {
            GetArticle = article;
            OpenWebSiteCommand = new Command(OpenWebSiteCommandExcute);
        }

        private async void OpenWebSiteCommandExcute(object obj)
        {

            try
            {
                await Browser.OpenAsync(GetArticle.Url, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
    }
}
