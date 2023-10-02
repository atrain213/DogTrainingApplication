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
                new BookInfo{BookName = "Champ", BookDescription = "Emily Johnson", BookImage = "dog2.jpg", BookSkill = "skill_level_bar_0.png"},
                new BookInfo{BookName = "Bravo", BookDescription = "Christopher Davis", BookImage = "dog3.jpg", BookSkill = "skill_level_bar_1.png"},
                new BookInfo{BookName = "Bella", BookDescription = "Sarah Martinez", BookImage = "dog4.jpg", BookSkill = "skill_level_bar_2.png"},
                new BookInfo{BookName = "Max", BookDescription = "Michael Thompson", BookImage = "dog5.jpg", BookSkill = "skill_level_bar_2.png"},
                new BookInfo{BookName = "Luna", BookDescription = "Jessica Lewis", BookImage = "dog2.jpg", BookSkill = "skill_level_bar_3.png"},
                new BookInfo{BookName = "Charlie", BookDescription = "Matthew Allen", BookImage = "dog1.jpg", BookSkill = "skill_level_bar_2.png"},
                new BookInfo{BookName = "Rocky", BookDescription = "Samantha Wilson", BookImage = "dog5.jpg", BookSkill = "skill_level_bar_1.png"},
                new BookInfo{BookName = "Lucy", BookDescription = "William Walker", BookImage = "dog3.jpg", BookSkill = "skill_level_bar_2.png"},
                new BookInfo{BookName = "Buddy", BookDescription = "Olivia Anderson", BookImage = "dog4.jpg", BookSkill = "skill_level_bar_5.png"},
                new BookInfo{BookName = "Sadie", BookDescription = "Daniel Scott", BookImage = "dog5.jpg", BookSkill = "skill_level_bar_3.png"},
                new BookInfo{BookName = "Bailie", BookDescription = "Elizabeth Turner", BookImage = "dog2.jpg", BookSkill = "skill_level_bar_2.png"},
                new BookInfo{BookName = "Duke", BookDescription = "Andrew Rodriguez", BookImage = "dog3.jpg", BookSkill = "skill_level_bar_5.png"},
                new BookInfo{BookName = "Daisy", BookDescription = "Sophia Hall", BookImage = "dog4.jpg", BookSkill = "skill_level_bar_0.png"}

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
