using System;
using System.Collections.ObjectModel;
using NewsAppTask.Models;
using NewsAppTask.Views;

namespace NewsAppTask.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        #region --Properties--
        public ObservableCollection<MasterMenuItems> MenuListLitem { get; set; }
        #endregion
        #region --Command--

        #endregion
        public HomeViewModel()
        {
            LoadList();

        }
        #region --Looad ListData
        private void LoadList()
        {
            MenuListLitem = new ObservableCollection<MasterMenuItems>();
            MenuListLitem.Add(new MasterMenuItems
            {
                Text = "Articles",
                Detail = "Articles",
                ImagePath = "about.png",
                TargetPage = typeof(ArticlesPage)
            });
            MenuListLitem.Add(new MasterMenuItems
            {
                Text = "Live Chat",
                Detail = "Live Chat",
                ImagePath = "about.png",
                TargetPage = typeof(LiveChatPage)
            });
            MenuListLitem.Add(new MasterMenuItems
            {
                Text = "Gallery",
                Detail = "Gallery",
                ImagePath = "about.png",
                TargetPage = typeof(GalleryPage)
            });
            MenuListLitem.Add(new MasterMenuItems
            {
                Text = "Wish List",
                Detail = "Wish List",
                ImagePath = "about.png",
                TargetPage = typeof(WishListPage)
            });
            MenuListLitem.Add(new MasterMenuItems
            {
                Text = "Explore Online News",
                Detail = "Explore Online News",
                ImagePath = "about.png",
                TargetPage = typeof(ExploreNewsOnlinePage)
            });

        }
        #endregion
    }
}