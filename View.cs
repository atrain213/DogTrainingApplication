using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


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

        public override string ToString()
        {
            return _name;
        }
    }


    public class ViewContact:BaseView
    {
        private string _fname = string.Empty;
        public string FName
        {
            get { return _fname; }
            set
            {
                if (_fname != value)
                {
                    _fname = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _address1 = string.Empty;
        public string Address1
        {
            get { return _address1; }
            set
            {
                if (_address1 != value)
                {
                    _address1 = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _address2 = string.Empty;
        public string Address2
        {
            get { return _address2; }
            set
            {
                if (_address2 != value)
                {
                    _address2 = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(ShowAddress2));
                }
            }
        }
        public bool ShowAddress2 { get
            {
                return !string.IsNullOrEmpty(_address2);
            } }

        private string _csz = string.Empty;
        public string CSZ
        {
            get { return _csz; }
            set
            {
                if (_csz != value)
                {
                    _csz = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _phone = string.Empty;
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _isOwner;
        public bool IsOwner
        {
            get { return _isOwner; }
            set
            {
                if (_isOwner != value)
                {
                    _isOwner = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _isTrainer;
        public bool IsTrainer
        {
            get { return _isTrainer; }
            set
            {
                if (_isTrainer != value)
                {
                    _isTrainer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _ownerID;
        public int OwnerID
        {
            get { return _ownerID; }
            set
            {
                if (_ownerID != value)
                {
                    _ownerID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _trainerID;
        public int TrainerID
        {
            get { return _trainerID; }
            set
            {
                if (_trainerID != value)
                {
                    _trainerID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public async Task loadAPIAsync(int id)
        {
            APIContact contact = await WebConnect.ContactInfoAsync(id);
            ID = contact.ID;
            Name = contact.Name;
            FName = contact.FName;
            Address1 = contact.Address1;
            Address2 = contact.Address2;
            CSZ = contact.CSZ;
            Email = contact.Email;
            Phone = contact.Phone;
            IsOwner = contact.OwnerID > 0;
            IsTrainer = contact.TrainerID > 0;
            OwnerID = contact.OwnerID;
            TrainerID = contact.TrainerID;

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

        private DateTime _dateofbirth = new DateTime(2020,1,1);
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
            ID = dog.ID;
            Name = dog.Name;
            Sex = dog.Sex;
            Weight = (double)dog.Weight;
            Bio = dog.Bio;
            DateofBirth = dog.Birthday;
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

    public class ViewDogProfile:BaseView
    {
        private ViewDogDetail _dog= new();
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
        private ViewDogTricks _tricks = new();
        public ViewDogTricks Tricks
        {
            get { return _tricks; }
            set
            {
                if (_tricks != value)
                {
                    _tricks = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ViewHistory _history = new();
        public ViewHistory History
        {
            get { return _history; }
            set
            {
                if (_history != value)
                {
                    _history = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public async Task loadAPIAsync(int id)
        {
            await Dog.loadAPI(id);
            await Tricks.LoadDetailsByDogAsync(id);
            await History.LoadDetailsByDogAsync(id);
        }

    }

    public class ViewTrainingHistory:BaseView
    {
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _trainer = string.Empty;
        public string Trainer
        {
            get { return _trainer; }
            set
            {
                if (_trainer != value)
                {
                    _trainer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _duration;
        public int Duration
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(DurationTime));
                }
            }
        }

        public string DurationTime
        {
            get
            {
                string tm = string.Empty;
                int hours = (int)Math.Floor((decimal)_duration / 60);
                int minutes = _duration % 60;
                if (hours > 0)
                {
                    tm = hours.ToString() + " Hr " + minutes.ToString("00") + " Min";
                }
                else
                {
                    tm = minutes.ToString() + " Min";
                }
                return tm;
            }
        }
    }

    public class ViewHistory : BaseView
    {
        private ObservableCollection<ViewTrainingHistory> _sessions = new();
        public ObservableCollection<ViewTrainingHistory> Sessions
        {
            get { return _sessions; }
            set
            {
                if (_sessions != value)
                {
                    _sessions = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public async Task LoadDetailsByDogAsync(int id)
        {
            List<ApiDogTraingHistory> api = await WebConnect.HistoryByDogAsync(id);
            Sessions.Clear();
            foreach (ApiDogTraingHistory session in api)
            {
                Sessions.Add(new ViewTrainingHistory
                {
                    ID = session.ID,
                    Name = session.Name,
                    Date = session.Date,
                    Duration = session.Duration,
                    Trainer = session.Trainer
                });
            }

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

        private Uri _picture = MyBlob.ImageFile(Guid.Empty, 1);
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
        public async Task loadAPI(int id)
        {
            APIDogDetail api = await WebConnect.DogAsync(id);
            ID = api.ID;
            Name = api.Name;
            Age = (int)(DateTime.Now.Subtract(api.Birthday).TotalDays / 365.0);
            Weight = api.Weight;
            Breed = api.Breed;
            Sex = api.Sex;
            Picture = MyBlob.ImageFile(api.Photo);
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

    public class ViewOwner : BaseView
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
       
      

        public async Task loadAPI(int id)
        {
            Dogs.Clear();
            List<APIDogDetail> api = await WebConnect.DogbyOwnerAsync(id);
            
            foreach (APIDogDetail apiItem in api)
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

    public class ViewTrick:BaseView
    {
        private DateTime _lastTrained;
        public DateTime LastTrained
        {
            get { return _lastTrained; }
            set
            {
                if (_lastTrained != value)
                {
                    _lastTrained = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(ShowLastTrained));
                }
            }
        }

        public bool ShowLastTrained
        {
            get
            {
                return _lastTrained != DateTime.MinValue;
            }
        }

        private Color _color = Colors.Magenta;
        public Color Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Brush _brush = new SolidColorBrush(Colors.Turquoise);
        public Brush Brush
        {
            get { return _brush; }
            set
            {
                if (_brush != value)
                {
                    _brush = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Point _proficiency = new Point(0,1);
        public Point Proficiency
        {
            get { return _proficiency; }
            set
            {
                if (_proficiency != value)
                {
                    _proficiency = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _level;
        public int Level
        {
            get { return _level; }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    NotifyPropertyChanged();
                    SelectIcon();
                }
            }
        }

        private int _levelScale;
        public int LevelScale
        {
            get { return _levelScale; }
            set
            {
                if (_levelScale != value)
                {
                    _levelScale = value;
                    NotifyPropertyChanged();
                    SelectIcon();
                }
            }
        }


        private Uri _icon = MyBlob.NoPicture;
        public Uri Icon
        {
            get { return _icon; }
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _success;
        public int Success
        {
            get { return _success; }
            set
            {
                if (_success != value)
                {
                    _success = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(Accuracy));
                    NotifyPropertyChanged(nameof(Repetitions));
                }
            }
        }

        private int _failure;
        public int Failure
        {
            get { return _failure; }
            set
            {
                if (_failure != value)
                {
                    _failure = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(Accuracy));
                    NotifyPropertyChanged(nameof(Repetitions));
                }
            }
        }

        private bool _isSliderVis;
        public bool IsSliderVis
        {
            get { return _isSliderVis; }
            set
            {
                if (_isSliderVis != value)
                {
                    _isSliderVis = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _levelIcon = "skill_level_bar_0.png";
        public string LevelIcon
        {
            get { return _levelIcon; }
            set
            {
                if (_levelIcon != value)
                {
                    _levelIcon = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void SelectIcon()
        {
            int scale = LevelScale;
            double prof = (double)Level / (double)LevelScale;
            if(prof == 0)
            {
                LevelIcon = "skill_level_bar_0.png";
            }
            else if(prof == 1)
            {
                LevelIcon = "skill_level_bar_5.png";
            }
            else if(prof < 0.26) 
            {
                LevelIcon = "skill_level_bar_1.png";
            }
            else if (prof < 0.51)
            {
                LevelIcon = "skill_level_bar_2.png";
            }
            else if (prof < 0.76)
            {
                LevelIcon = "skill_level_bar_3.png";
            }
            else 
            {
                LevelIcon = "skill_level_bar_4.png";
            }
  
        }

        public double Accuracy
        {
            get
            {
                if(_success+_failure == 0) 
                {
                    return 0;
                }
                return (double)_success/ ((double)Repetitions);
            }
        }

        public int Repetitions
        {
            get
            {
                return _success + _failure;
            }
        }

   

        public void TrickGood()
        {
            Success++;
        }

        public void TrickBad()
        {
            Failure++;
        }
    }

    public class ViewDogTricks:BaseView
    {
        private ObservableCollection<ViewTrick> _tricks = new();
        public ObservableCollection<ViewTrick> Tricks
        {
            get { return _tricks; }
            set
            {
                if (_tricks != value)
                {
                    _tricks = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public async Task LoadAllTricks()
        {
            List<APITrick> api = await WebConnect.TricksAsync();
            ProcessApi(api);

        }
        public async Task LoadByDogTricks(int id)
        {
            List<APITrick> api = await WebConnect.TricksByDogAsync(id);
            ProcessApi(api);

        }


        public async Task LoadDetailsByDogAsync(int id)
        {
            List<APITrickDetail> api = await WebConnect.TrickDetailsByDogAsync(id);
            Tricks.Clear();
            foreach (APITrickDetail trick in api)
            {
                Tricks.Add(new ViewTrick
                {
                    ID = trick.ID,
                    Name = trick.Name,
                    LastTrained = trick.Trainings.OrderByDescending (s => s.Date).Select(s => s.Date).FirstOrDefault(),
                    Color = Color.FromArgb("#" + trick.Color),
                    Brush = new SolidColorBrush(Color.FromArgb("#" + trick.Color)),
                    Icon = MyBlob.ImageFile(trick.IconFileName),
                    Proficiency = new Point(0, (1.01 - ((double)trick.Level / (double)trick.Scale))),
                    Level = trick.Level,
                    LevelScale = trick.Scale
                });
            }


        }




        private void ProcessApi(List<APITrick> api)
        {
            Tricks.Clear();
            foreach (APITrick trick in api)
            {
                Tricks.Add(new ViewTrick
                {
                    ID = trick.ID,
                    Name = trick.Name,                  
                    Color = Color.FromArgb("#" + trick.Color),
                    Brush = new SolidColorBrush(Color.FromArgb("#"+trick.Color)),
                    Icon = MyBlob.ImageFile(trick.IconFileName),
                    Proficiency = new Point(0,(1.01-((double)trick.Level/(double)trick.Scale))),
                    Level = trick.Level,
                    LevelScale = trick.Scale
                });
            }
        }

    }

    public class ViewSession:ViewDogTricks
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

        private ViewDog? _currentDog;
        public ViewDog? CurrentDog
        {
            get { return _currentDog; }
            set
            {
                if (_currentDog != value)
                {
                    _currentDog = value;
                    NotifyPropertyChanged();
                    Refresh();
                }
            }
        }

        private ViewTrick? _selectedTrick;
        public ViewTrick? SelectedTrick
        {
            get { return _selectedTrick; }
            set
            {
                if (_selectedTrick != value)
                {
                    _selectedTrick = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<ViewTrick> _selectedTricks = new();
        public ObservableCollection<ViewTrick> SelectedTricks
        {
            get { return _selectedTricks; }
            set
            {
                if (_selectedTricks != value)
                {
                    _selectedTricks = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _mood = string.Empty;
        public string Mood
        {
            get { return _mood; }
            set
            {
                if (_mood != value)
                {
                    _mood = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime _startTime;
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime _endTime;
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private int _hours;
        public int Hours
        {
            get { return _hours; }
            set
            {
                if (_hours != value)
                {
                    _hours = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _minutes;
        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (_minutes != value)
                {
                    _minutes = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private string _weather = string.Empty;
        public string Weather
        {
            get { return _weather; }
            set
            {
                if (_weather != value)
                {
                    _weather = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _location = string.Empty;
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _comments = string.Empty;
        public string Comments
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public async void Refresh()
        {
            Tricks.Clear();
            if (_currentDog != null)
            {
                await LoadByDogTricks(_currentDog.ID);
            }
            
        }

        public async Task LoadAPIbyTrainer(int id)
        {
            Dogs.Clear();
            List<APIDogDetail> api = await WebConnect.DogbyTrainerAsync(id);
            foreach (APIDogDetail apiItem in api)
            {
                Dogs.Add(new ViewDog { ID = apiItem.ID, Name = apiItem.Name });
            }
            if (Dogs.Count > 0)
            {
                CurrentDog = Dogs.FirstOrDefault();
            }
        }

        public async Task LoadAPIbyOwner(int id)
        {
            Dogs.Clear();
            List<APIDogDetail> api = await WebConnect.DogbyOwnerAsync(id);
            foreach (APIDogDetail apiItem in api)
            {
                Dogs.Add(new ViewDog { ID = apiItem.ID, Name = apiItem.Name });
            }
            if (Dogs.Count > 0)
            {
                CurrentDog = Dogs.FirstOrDefault();
            }
        }

        public async Task LoadAPIbyDog(int id)
        {
            Dogs.Clear();
            APIData trainer = await WebConnect.TrainerbyDogAsync(id);
            List<APIDogDetail> api = await WebConnect.DogbyTrainerAsync(trainer.ID);
            foreach (APIDogDetail apiItem in api)
            {
                Dogs.Add(new ViewDog { ID = apiItem.ID, Name = apiItem.Name });
            }
            if (Dogs.Count > 0)
            {
                _currentDog = Dogs.FirstOrDefault(f => f.ID == id);
            }
        }

        public void SelectAllTricks()
        {
            foreach (var item in Tricks)
            {
                item.Selected = true;
            }
        }
        public void SelectNone()
        {
            foreach (var item in Tricks)
            {
                item.Selected = false;
            }
        }

        public void SetTricks()
        {
            SelectedTricks = new ObservableCollection<ViewTrick>(Tricks.Where(w => w.Selected).ToList());

        }

        public async Task<int> PostDTO()
        {
            if (_currentDog != null)
            {
                DTOSession session = new DTOSession()
                {
                    ID = 0,
                    Date = DateTime.Now,
                    DogId = _currentDog.ID,
                    TrainerID = MyAccount.Contact.TrainerID,
                    Duration = Hours * 60 + Minutes,
                    Comment = Comments,
                    Location = Location,
                    Mood = Mood,
                    Tricks = SelectedTricks.Select(s => new DTOTrainingTrick { ProficiencyCount = s.Success, Proficiency = s.Level, Repetitions = s.Repetitions, TrickID = s.ID }).ToList(),
                    Weather = Weather,
                };
                int retval = await WebConnect.SaveSession(session);
                return retval;
            }
            return -1;
       
        }
    }


}
