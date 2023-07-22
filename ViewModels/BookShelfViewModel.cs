using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
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


        private ObservableCollection<UserControl>? _bookShelvesItem;

        public ObservableCollection<UserControl>? BookShelvesItem
        {
            get { return _bookShelvesItem; }
            set
            {
                _bookShelvesItem = value;
                OnPropertyChanged(nameof(BookShelvesItem));
            }
        }


        public ICommand AddBookInfmaEventCommand { get; }
        private void AddBookInfmaEvent()
        {
            AddBookInformation addBookInformation = new AddBookInformation();
            addBookInformation.Show();
        }

        
    }
}
