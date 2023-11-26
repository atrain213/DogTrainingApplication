using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class BaseNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler != null)
            {
                //Validate(propertyName);
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class BaseView: BaseNotify
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }

    public class ViewBreeds:BaseView
    {
        private ObservableCollection<ViewBreeds> _breeds = new();
        public ObservableCollection<ViewBreeds> Breeds
        {
            get { return _breeds; }
            set
            {
                if (_breeds != value)
                {
                    _breeds = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public async Task loadAPI()
        {
            Breeds.Clear();
            List<APIDogBreeds> api = await WebConnect.BreedListAsync();
            foreach (APIDogBreeds apiItem in api)
            {
                Breeds.Add(new ViewBreeds {Name = apiItem.Name });
            }
        }
    }

    

    public class ViewDog:BaseView
    {

    }

    public class ViewDogDetail:BaseView
    {
        private string _breed = string.Empty;
        public string Breed
        {
            get { return _breed; }
            set
            {
                if (_breed != value)
                {
                    _breed = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _sex = string.Empty;
        public string Sex
        {
            get { return _sex; }
            set
            {
                if (_sex != value)
                {
                    _sex = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _owner = string.Empty;
        public string Owner
        {
            get { return _owner; }
            set
            {
                if (_owner != value)
                {
                    _owner = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public async Task loadAPI(int id)
        {
            APIDogDetail api = await WebConnect.DogAsync(id);
            ID = api.ID;
            Name = api.Name;
            Age = (int)(DateTime.Now.Subtract(api.Birthday).TotalDays / 365.0);
            Weight = api.Weight;
            Breed = api.Breed;
            Sex = api.Sex;
            if(api.Owners.Count > 0)
            {
                Owner = api.Owners[0].Name;
            }
        }
    }

    public class ViewDogList : BaseView
    {
        private ObservableCollection<ViewDog> _dogs = new();
        public ObservableCollection<ViewDog> Dogs
        {
            get { return _dogs; }
            set
            {
                if (_dogs != value)
                {
                    _dogs = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public async Task loadAPI()
        {
            Dogs.Clear();
            List<APIDog> api = await WebConnect.DogListAsync();
            foreach (APIDog apiItem in api)
            {
                Dogs.Add(new ViewDog { ID = apiItem.ID, Name = apiItem.Name });
            }
        }

        

    }
}
