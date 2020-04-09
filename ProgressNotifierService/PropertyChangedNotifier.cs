using System.ComponentModel;

namespace ProgressNotifierService
{
    public class PropertyChangedNotifier : INotifyPropertyChanged
    {
        internal PropertyChangedNotifier()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}
