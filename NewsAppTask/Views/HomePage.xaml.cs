using System;
using System.Collections.Generic;
using NewsAppTask.ViewModel;
using Xamarin.Forms;

namespace NewsAppTask.Views
{
    public partial class HomePage : MasterDetailPage
    {
        HomeViewModel homeViewModel;
        public HomePage()
        {
            InitializeComponent();
            StartPage();

        }
        private void StartPage()
        {
            var mainPage = new MainMenuPage(LaunchPageInDetail);
            mainPage.HideFlyout += () => this.IsPresented = false;
            this.Master = mainPage;

        }
        private void LaunchPageInDetail(Page page)
        {
            Detail = page;
            IsPresented = false;
        }
    }
}