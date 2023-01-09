using Service.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Linq;

namespace Service.ApplicationViewModel
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Users = SelectUsers();
        }

        private const string FILE_DIRECTORY = @"C:\Users\meles\Desktop\Service\Data";
        public ObservableCollection<Users> Users { get; set; }
        private Users _user;
        public Users SelectedUser
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        private ObservableCollection<ObservableCollection<Users>> _userDay;
        private ObservableCollection<Users> SelectUsers()
        {
            ObservableCollection<Users> users = new();
            _userDay = new ObservableCollection<ObservableCollection<Users>>();
            foreach (FileInfo Files in new DirectoryInfo(FILE_DIRECTORY).GetFiles())
            {
                string fileContents;
                using (StreamReader reader = new(Files.FullName))
                {
                    fileContents = reader.ReadToEnd();
                }
                _userDay.Add(JsonSerializer.Deserialize<ObservableCollection<Users>>(fileContents));
            }
            // живем
            bool isHave = true;
            for (int i = 0; i < _userDay.Count; i++)
            {
                for (int j = 0; j < _userDay[i].Count; j++)
                {
                    _userDay[i][j].WorstResult = (int)_userDay[i][j].Steps;
                    for (int k = 0; k < users.Count; k++)
                    {
                        if (users[k].User == _userDay[i][j].User)
                        {
                            users[k].AverageResult += _userDay[i][j].Steps;
                            if (users[k].BestResult < _userDay[i][j].Steps) users[k].BestResult = _userDay[i][j].Steps;
                            else if (users[k].WorstResult > _userDay[i][j].Steps) users[k].WorstResult = (int)_userDay[i][j].Steps;
                            isHave = false;
                        }
                    }
                    if (isHave)
                    {
                        users.Add(_userDay[i][j]);
                    }
                }
            }
            for (int i = 0; i < users.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < _userDay.Count; j++)
                {
                    for (int k = 0; k < _userDay[j].Count; k++)
                    {
                        if (users[i].User == _userDay[j][k].User)
                        {
                            count++;
                        }
                    }
                }
                users[i].AverageResult /= count;
                if (users[i].BestResult > users[i].AverageResult * 1.2f && users[i].WorstResult < users[i].AverageResult / 1.2f)
                {
                    users[i].Difference = true;
                }
            }
            //
            return users;
        }

        private Command _saveCommand;
        public Command SaveCommand => _saveCommand ??= new Command(obj =>
        {
            if (obj is Users user)
            {
                XDocument xDoc = new(
                    new XElement("User",
                    new XElement("Name", user.User),
                    new XElement("AverageResult", user.AverageResult),
                    new XElement("BestResult", user.BestResult),
                    new XElement("WorstResult", user.WorstResult),
                    new XElement("Rank", user.Rank),
                    new XElement("Status", user.Status)));
                xDoc.Save(user.User + ".xml");
            }
        });
        private ObservableCollection<ToolkPoints> _selectedUserDay;
        public ObservableCollection<ToolkPoints> SelectedUserDay
        {
            get => _selectedUserDay;
            set
            {
                _selectedUserDay = value;
                OnPropertyChanged("SelectedUserDay");
            }
        }
        private Command _graficValue;
        public Command GraficValue => _graficValue ??= new Command(obj =>
        {
            if (obj is Users user)
            {
                ObservableCollection<ToolkPoints> value = new ();
                for (int i = 0; i < _userDay.Count; i++)
                {
                    for (int j = 0; j < _userDay[i].Count; j++)
                    {
                        if (user.User == _userDay[i][j].User)
                        {
                            value.Add(new ToolkPoints { Day = i, Value = _userDay[i][j].Steps });
                            break;
                        }
                    }
                }
                SelectedUserDay = value;
            }
        });


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
