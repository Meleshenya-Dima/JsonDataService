using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Service.Model
{
    public class ToolkPoints : INotifyPropertyChanged
    {
        public int _day;
        public long _value;

        public int Day
        {
            get => _day;
            set
            {
                _day = value;
                OnPropertyChanged("Day");
            }
        }
        public long Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}
