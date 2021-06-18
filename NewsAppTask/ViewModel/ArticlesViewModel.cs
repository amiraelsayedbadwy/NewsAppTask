using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using NewsAppTask.Communication.Service;
using NewsAppTask.Models;
using NewsAppTask.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NewsAppTask.ViewModel
{
    public class ArticlesViewModel : BaseViewModel
    {

        public Action<Page> OnPageChanged { get; set; }
        public ObservableCollection<Article> ArticleList { get; set; }
        public bool IsBusy { get; set; }
        public ICommand SelectedItemCommand { get; set; }
        public ArticlesViewModel()
        {
            SelectedItemCommand = new Command<Article>(SelectedItemCommandExute);
            GetArtticles();
        }

        private void SelectedItemCommandExute(Article selectedItem)
        {
            OnPageChanged?.Invoke(new ArticlesDetailsPage(selectedItem));
        }

        private async void GetArtticles()
        {
            try
            {
                ArticleList = new ObservableCollection<Article>();
                var service = new ArticlesService();
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    if (!IsBusy)
                    {
                        IsBusy = true;
                        var articleResponse = await service.GetArticles();
                        var moreRticlesResponse = await service.GetMoreArticles();
                        var articleList1 = articleResponse.articles;
                        var moreArticleList2 = moreRticlesResponse.articles;
                        articleList1.AddRange(moreArticleList2);
                        ArticleList = new ObservableCollection<Article>(articleList1);
                        IsBusy = false;
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("No Internet", "There is no internet connection , please check you internet connection", "Ok");
                }

            }
            catch (Exception ex)
            {
                IsBusy = false;
                Console.WriteLine("Api Exception :" + ex.Message);
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}