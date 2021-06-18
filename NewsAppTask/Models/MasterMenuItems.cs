using System;
using NewsAppTask.ViewModel;

namespace NewsAppTask.Models
{
    public class MasterMenuItems : BaseViewModel
    {
        public string Text { get; set; }
        public string Detail { get; set; }
        public string ImagePath { get; set; }
        public Type TargetPage { get; set; }
    }
}
