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

    public class ViewDogEdits:BaseView
    {
        private ObservableCollection<APIDogBreeds> _breeds = new();
        public ObservableCollection<APIDogBreeds> Breeds
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
        private string _sex = "Male";
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

        private DateTime _dateofbirth;
        public DateTime DateofBirth
        {
            get { return _dateofbirth; }
            set
            {
                if (_dateofbirth != value)
                {
                    _dateofbirth = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _bio = string.Empty;
        public string Bio
        {
            get { return _bio; }
            set
            {
                if (_bio != value)
                {
                    _bio = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private APIDogBreeds? _breed;
        public APIDogBreeds? Breed
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

        private double _weight;
        public double Weight
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

        private int _photoid;
        public int PhotoID
        {
            get { return _photoid; }
            set
            {
                if (_photoid != value)
                {
                    _photoid = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public async Task loadAPI(int id)
        {
            APIDogDetail dog = await WebConnect.DogAsync(id);
            Breeds.Clear();
            List<APIDogBreeds> api = await WebConnect.BreedListAsync();
            foreach (APIDogBreeds apiItem in api)
            {
                Breeds.Add(apiItem);
            }
            Name = dog.Name;
            Sex = dog.Sex;
            Weight = (double)dog.Weight;
            Bio = dog.Bio;
            Breed = Breeds.FirstOrDefault(f => f.Name == dog.Breed);
        }

        public async Task<bool> saveData()
        {
            if (string.IsNullOrEmpty(Name) || _weight < 5 || _breed == null)
            {
                return false;
            }
            DTODog dto = new DTODog()
            {
                Name = Name,
                ID = ID,
                Weight = (int)Weight,
                Bio = Bio,
                IsMale = Sex == "Male",
                Birthday = DateofBirth,
                PhotoID = PhotoID,
                BreedID = _breed.ID
            };
            int retval = await WebConnect.SaveDog(dto);
            return retval > 0;

        }
    }

    

    public class ViewDog:BaseView
    {
        private Uri _picture = MyBlob.ImageFile(Guid.Empty,1);
        public Uri Picture
        {
            get { return _picture; }
            set
            {
                if (_picture != value)
                {
                    _picture = value;
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

    public class ViewDogEdit : BaseView
    {
        private ObservableCollection<BaseView> _breedList = new();

        public ObservableCollection<BaseView> BreedList
        {
            get { return _breedList; }
            set { if (_breedList != value)
                    {
                    _breedList = value;
                    NotifyPropertyChanged();
                    }      
                }
        }

    }

    public class ViewTrainer: BaseView
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
        private ViewDog _lastdog = new();
        public ViewDog LastDog
        {
            get { return _lastdog; }
            set
            {
                if (_lastdog != value)
                {
                    _lastdog = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(LastDog));
                }
            }
        }
        public bool HasLastDog
        {
            get { return _lastdog.ID > 0; }
        }

        public async Task loadAPI(int id)
        {
            Dogs.Clear();
            List<APIDogDetail> api = await WebConnect.DogbyTrainerAsync(id);
            int lastdog = await WebConnect.LastDogforTrainerAsync(id);
            if(lastdog > 0)
            {
                APIDogDetail? ldog = api.FirstOrDefault(f => f.ID == lastdog);
                if (ldog != null)
                {
                    string? owners = ldog.Owners.Select(s => s.Name).FirstOrDefault();
                    if (owners == null)
                    {
                        owners = string.Empty;
                    }
                    LastDog = new ViewDog { ID = ldog.ID, Name = ldog.Name, Owner = owners, Picture = MyBlob.ImageFile(ldog.Photo) };
                }
            }

            foreach (APIDogDetail apiItem in api)
            {
                if (apiItem.ID != lastdog)
                {
                    string? owners = apiItem.Owners.Select(s => s.Name).FirstOrDefault();
                    if (owners == null)
                    {
                        owners = string.Empty;
                    }
                    Dogs.Add(new ViewDog { ID = apiItem.ID, Name = apiItem.Name, Owner = owners, Picture = MyBlob.ImageFile(apiItem.Photo) });
                }
            }
        }
    }
}
