using System;
using System.Collections.Generic;
using NewsAppTask.ViewModel;
using Xamarin.Forms;

namespace NewsAppTask.Views
{
    public partial class MainMenuPage : ContentPage
    {
        public Action HideFlyout;
        public MainMenuPage(Action<Page> openPageAsRoot)
        {
            InitializeComponent();
            var viewModel = new MainMenuViewModel(Navigation, openPageAsRoot);
            // Hiding the flyout can only be done from the RootMasterDetailPage.cs, so we use Invokes to communicate as soon as a Menu item is selected
            viewModel.SelectedMenuOption = () =>
            {
                HideFlyout?.Invoke();
                sampleListView.SelectedItem = null;
            };
            BindingContext = viewModel;
        }
    }
}
