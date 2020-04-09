using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_AsyncAwaitSample.FW
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region PropertyChanged インターフェース

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string pname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pname));
            }
        }

        #endregion
    }
}
