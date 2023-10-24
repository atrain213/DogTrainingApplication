using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class BookViewModel
    {
        public ObservableCollection<string> Books { get; set; }

        public ObservableCollection<BookInfo> BookDetails { get; set; }

        public BookViewModel() {

            BookDetails = new ObservableCollection<BookInfo>
            {
                new BookInfo{BookName = "Champ", BookDescription = "Emily Johnson", BookImage = "dog2.jpg", BookSkill = "skill_level_bar_0.png", ID = 1, Color=Color.FromRgb(255,0,0), Scale = new Point(0,1)},
                new BookInfo{BookName = "Conley", BookDescription = "Christopher Davis", BookImage = "dog3.jpg", BookSkill = "skill_level_bar_1.png", ID = 2, Color=Color.FromRgb(255,0,0), Scale =new Point(0,3)},
                new BookInfo{BookName = "Bella", BookDescription = "Sarah Martinez", BookImage = "dog4.jpg", BookSkill = "skill_level_bar_2.png", ID = 1, Color=Color.FromRgb(255,0,0), Scale = new Point(0,3)},
                new BookInfo{BookName = "Max", BookDescription = "Michael Thompson", BookImage = "dog5.jpg", BookSkill = "skill_level_bar_2.png", ID = 1, Color=Color.FromRgb(255, 0, 0), Scale = new Point(0,.25)},
                new BookInfo{BookName = "Luna", BookDescription = "Jessica Lewis", BookImage = "dog2.jpg", BookSkill = "skill_level_bar_3.png", ID = 1, Color=Color.FromRgb(0, 255, 0), Scale = new Point(0, .5)},
                new BookInfo{BookName = "Charlie", BookDescription = "Matthew Allen", BookImage = "dog1.jpg", BookSkill = "skill_level_bar_2.png", ID = 1, Color=Color.FromRgb(0, 255, 0), Scale = new Point(0, .75)},
                new BookInfo{BookName = "Rocky", BookDescription = "Samantha Wilson", BookImage = "dog5.jpg", BookSkill = "skill_level_bar_1.png", ID = 1, Color=Color.FromRgb(0, 255, 0), Scale = new Point(0, 0)},
                new BookInfo{BookName = "Lucy", BookDescription = "William Walker", BookImage = "dog3.jpg", BookSkill = "skill_level_bar_2.png", ID = 1, Color=Color.FromRgb(0, 0, 255), Scale = new Point(0, .25)},
                new BookInfo{BookName = "Buddy", BookDescription = "Olivia Anderson", BookImage = "dog4.jpg", BookSkill = "skill_level_bar_5.png", ID = 1, Color=Color.FromRgb(0, 0, 255), Scale = new Point(0, 1)},
                new BookInfo{BookName = "Sadie", BookDescription = "Daniel Scott", BookImage = "dog5.jpg", BookSkill = "skill_level_bar_3.png", ID = 1, Color=Color.FromRgb(0, 0, 255), Scale = new Point(0, 2)},
                new BookInfo{BookName = "Bailie", BookDescription = "Elizabeth Turner", BookImage = "dog2.jpg", BookSkill = "skill_level_bar_2.png", ID = 1, Color=Color.FromRgb(128, 128, 0), Scale = new Point(0, 1.5)},
                new BookInfo{BookName = "Duke", BookDescription = "Andrew Rodriguez", BookImage = "dog3.jpg", BookSkill = "skill_level_bar_5.png", ID = 1, Color=Color.FromRgb(128, 128, 0), Scale =new Point(0, .75)},
                new BookInfo{BookName = "Daisy", BookDescription = "Sophia Hall", BookImage = "dog4.jpg", BookSkill = "skill_level_bar_0.png", ID = 1, Color=Color.FromRgb(0, 128, 128), Scale = new Point(0, .5)}

            };
            Books = new ObservableCollection<string>
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
    }
}
