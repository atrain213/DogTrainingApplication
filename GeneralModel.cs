//using Android.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class GeneralModel
    {
        public ObservableCollection<string> GenSettings { get; set; }
     
        public GeneralModel()
        {
            GenSettings = new ObservableCollection<string>
            {
                "Account > ",
                "Find a Trainer! > ",
                "Location Services > ",
                "Notifications > ",
                "Settings > ",
                "Export Data > ",
                "Logout > "
            };
        }
    }
}
