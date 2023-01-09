using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Service.Model
{
    internal class Users : INotifyPropertyChanged
    {
        private bool _difference;
        private int _rankUser;
        private string _nameUser;
        private string _statusUser;
        private long _stepsUser;
        private long _averageResult;
        private long _bestResult;
        private int _worstResult;

        public bool Difference
        {
            get => _difference;
            set
            {
                _difference = value;
                OnPropertyChanged("Difference");
            }
        }

        public int Rank
        {
            get => _rankUser;
            set
            {
                _rankUser = value;
                OnPropertyChanged("Rank");
            }
        }
        public string User
        {
            get => _nameUser;
            set
            {
                _nameUser = value;
                OnPropertyChanged("User");
            }
        }

        public string Status
        {
            get => _statusUser;
            set
            {
                _statusUser = value;
                OnPropertyChanged("Status");
            }
        }
        public long Steps
        {
            get => _stepsUser;
            set
            {
                _stepsUser = value;
                OnPropertyChanged("Steps");
            }
        }
        public long AverageResult
        {
            get => _averageResult;
            set
            {
                _averageResult = value;
                OnPropertyChanged("AverageResult");
            }
        }

        public long BestResult
        {
            get => _bestResult;
            set
            {
                _bestResult = value;
                OnPropertyChanged("BestResult");
            }
        }

        public int WorstResult
        {
            get => _worstResult;
            set
            {
                _worstResult = value;
                OnPropertyChanged("WorstResult");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
