using System;
using System.Collections.Generic;
using NewsAppTask.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NewsAppTask.ViewModel
{
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly Action<Page> _openPageAsRoot;
        private List<MenuEntry> _mainMenuEntries;
        private MenuEntry _selectedMainMenuEntry;

        public MainMenuViewModel(INavigation navigation, Action<Page> openPageAsRoot)

        {
            _navigation = navigation;
            _openPageAsRoot = openPageAsRoot;

            LoadData();

            var firstEntry = _mainMenuEntries[0];
            if (firstEntry.IsModal)
            {
                openPageAsRoot(new NavigationPage(CreateDetailDefaultBackgroundPage()));
            }
            else
            {
                MainMenuSelectedItem = firstEntry;
            }
        }

        public List<MenuEntry> MainMenuEntries
        {
            get { return _mainMenuEntries; }
            set { SetProperty(ref _mainMenuEntries, value); }
        }

        public Action SelectedMenuOption;

        public MenuEntry MainMenuSelectedItem
        {
            get { return _selectedMainMenuEntry; }
            set
            {
                if (SetProperty(ref _selectedMainMenuEntry, value) && value != null)
                {
                    // Hiding the flyout can only be done from the RootMasterDetailPage.cs, so we use Invokes to communicate as soon as a Menu item is selected
                    SelectedMenuOption?.Invoke();
                    if (value.IsPrivacyPolicy == true)
                    {
                        Launcher.OpenAsync(new Uri("https://www.signalcortex.com/app-privacy"));
                        return;
                    }
                    Page page;

                    if (value.PageType != null)
                    {
                        page = CreatePage(value.PageType);
                    }
                    else
                    {
                        page = value.CreatePage();
                    }

                    NavigationPage navigationPage;

                    if (value.NavigationPageType == null)
                    {
                        navigationPage = new NavigationPage(page);
                    }
                    else
                    {
                        navigationPage = (NavigationPage)Activator.CreateInstance(value.NavigationPageType, page);
                    }

                    if (value.UseTransparentNavBar)
                    {
                        // GrialNavigationPage.SetIsBarTransparent(navigationPage, true);
                    }

                    if (_selectedMainMenuEntry.IsModal)
                    {
                        _navigation.PushModalAsync(navigationPage);
                    }
                    else
                    {
                        _openPageAsRoot(navigationPage);
                    }

                    _selectedMainMenuEntry = null;
                    NotifyPropertyChanged(nameof(MainMenuSelectedItem));
                }
            }
        }

        //protected override void OnCultureChanged(CultureInfo culture)
        //{
        //    LoadData();
        //}

        private static ContentPage CreateDetailDefaultBackgroundPage()
        {
            var content = new Grid();
            var logo = new Label
            {
                Text = "",
                FontSize = 100,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            logo.SetDynamicResource(Label.TextColorProperty, "ComplementColor");
            content.Children.Add(logo);
            return new ContentPage { Content = content };
        }

        private void LoadData()
        {
            MainMenuEntries = new List<MenuEntry>();

            MainMenuEntries.Add(new MenuEntry
            {
                Name = "Articles",
                Icon = "explore.png",
                CreatePage = () =>
                {
                    return new ArticlesPage();
                }
            });

            MainMenuEntries.Add(new MenuEntry
            {
                Name = "Live Chat",
                Icon = "live.png",
                CreatePage = () =>
                {
                    return new LiveChatPage();
                },

            });

            MainMenuEntries.Add(new MenuEntry
            {
                Name = "Gallery",
                Icon = "gallery",
                CreatePage = () =>
                {
                    return new GalleryPage();
                },

            });
            MainMenuEntries.Add(new MenuEntry
            {
                Name = "Wish List",
                Icon = "wishlist",
                CreatePage = () =>
                {
                    return new WishListPage();
                },

            });
            MainMenuEntries.Add(new MenuEntry
            {
                Name = "Explore Online News",
                Icon = "onlineNews.png",
                CreatePage = () =>
                {
                    return new ExploreNewsOnlinePage();
                },

            });
        }

        private Page CreatePage(Type pageType)
        {
            return Activator.CreateInstance(pageType) as Page;
        }

        public class MenuEntry
        {
            public string Name { get; set; }
            public string Icon { get; set; }
            public bool UseTransparentNavBar { get; set; }
            public Type PageType { get; set; }
            public Func<Page> CreatePage { get; set; }
            public Type NavigationPageType { get; set; }
            public bool IsModal { get; set; }
            public bool IsPrivacyPolicy { get; set; }
        }
    }
}
