using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using PersonalNovelist_Windows.Pages.Other;

namespace PersonalNovelist_Windows.ViewModels
{
    public partial class BookShelfViewModel : ObservableObject, INotifyPropertyChanged
    {

        public BookShelfViewModel()
        {
            AddBookInfmaEventCommand = new RelayCommand(AddBookInfmaEvent);

            
        }

        private string? _title;
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ICommand AddBookInfmaEventCommand { get; }
        private void AddBookInfmaEvent()
        {
            AddBookInformation addBookInformation = new AddBookInformation();
            addBookInformation.Show();
        }


        
    }
}
