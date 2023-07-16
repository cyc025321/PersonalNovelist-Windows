using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PersonalNovelist_Windows.ViewModels
{
    public partial class BookShelfViewModel : ObservableObject, INotifyPropertyChanged
    {

        public BookShelfViewModel()
        {
            IncrementCounterCommand = new RelayCommand(IncrementCounter);

            Title = "cyc";
        }

        private string? _title;
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ICommand IncrementCounterCommand { get; }
        private void IncrementCounter()
        {
            Title = "tot";
        }


        
    }
}
