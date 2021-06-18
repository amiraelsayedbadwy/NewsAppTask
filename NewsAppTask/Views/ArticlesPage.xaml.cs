using System;
using System.Collections.Generic;
using NewsAppTask.ViewModel;
using Xamarin.Forms;

namespace NewsAppTask.Views
{
    public partial class ArticlesPage : ContentPage
    {
        ArticlesViewModel viewModel;
        public ArticlesPage()
        {
            viewModel = new ArticlesViewModel();
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.OnPageChanged = ((obj) =>
            {
                Navigation.PushAsync(obj);
            });
        }
    }
}
