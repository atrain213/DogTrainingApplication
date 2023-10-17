using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class BehaviorViewModel : BaseView
    {
        public ObservableCollection<string> Behaviors { get; set; }

        public ObservableCollection<BehaviorInfo> BehaviorDetails { get; set; }

        private ViewDogDetail _dog = new();
        public ViewDogDetail Dog
        {
            get { return _dog; }
            set
            {
                if (_dog != value)
                {
                    _dog = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public BehaviorViewModel() {

            BehaviorDetails = new ObservableCollection<BehaviorInfo>
            {
                new BehaviorInfo{SkillName = "Sit", SkillTrainer = "Emily Johnson", SkillDate = "8/29/23", SkillLevel = "skill_level_bar_5.png"},
                new BehaviorInfo{SkillName = "Play Dead", SkillTrainer = "Christopher Davis", SkillDate = "8/02/23", SkillLevel = "skill_level_bar_2.png"},
                new BehaviorInfo{SkillName = "Lay Down", SkillTrainer = "Sarah Martinez", SkillDate = "7/15/23", SkillLevel = "skill_level_bar_4.png"},
                new BehaviorInfo{SkillName = "Stay", SkillTrainer = "Michael Thompson", SkillDate = "6/22/23", SkillLevel = "skill_level_bar_1.png"}

            };
            Behaviors = new ObservableCollection<string>
            {
                "Test 1",
                "Test 2",
                "Test 3",
                "Test 4",
                "Test 5",
                "Test 6",
                "Test 7",
                "Test 8"
            };
            
        }
        public async Task Refresh(int id)
        {
            await Dog.loadAPI(id);
            if (Dog.ID > 0) { }
        }
    }
}
