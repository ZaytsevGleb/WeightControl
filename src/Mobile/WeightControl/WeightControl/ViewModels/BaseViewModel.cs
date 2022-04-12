using System;
using System.ComponentModel;

namespace WeightControl.ViewModels
{
    public abstract class BaseViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}
