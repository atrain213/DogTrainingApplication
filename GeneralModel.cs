//using Android.Database;
<<<<<<< HEAD
// using MauiApp1.Pages;
=======
//using MauiApp1.Pages;
using MauiApp1;
>>>>>>> b1e8977987c7892a313bc2c68677997315b26f01
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

       public ObservableCollection<GenInfo> GenDetails { get; set; }
        public GeneralModel()
        {
            GenDetails = new ObservableCollection<GenInfo>()
            {
                new GenInfo { GenName = "Profile", GenDescription = "Edit Profile" },
                new GenInfo { GenName = "Trainer Search", GenDescription = "Search for Trainers in your Area!" },
                new GenInfo { GenName = "Location Services", GenDescription = "Location Enabled" },
                new GenInfo { GenName = "Notifications", GenDescription = "Notifications Enabled" },
                new GenInfo { GenName = "Settings", GenDescription = "View and Change Settings" },
                new GenInfo { GenName = "Data Export", GenDescription = "Print or Export Data" },
                new GenInfo { GenName = "Logout", GenDescription = "Logout from johnsmith123" }
            };

            GenSettings = new ObservableCollection<string>
            {
                "Account > ",
                "Find a Trainer! > ",
                "Location Services > ",
                "Notifications > ",
                "Settings > ",
                "Data > ",
                "Logout X "
            };
        }
    }
}
