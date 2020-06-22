using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
 

namespace Rejestracja.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged 
    {
         
        public event PropertyChangedEventHandler PropertyChanged;
      

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

 
    }
}
