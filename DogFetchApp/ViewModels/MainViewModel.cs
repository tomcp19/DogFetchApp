using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using DogFetchApp.Commands;
using ApiHelper;
using System.Collections.ObjectModel;


namespace DogFetchApp.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private int nbImg;
        private string selectedNb;
        private string selectedDogBreed;
        private string url;

        private ObservableCollection<string> nbImgCollection;
        private ObservableCollection<string> currentList = new ObservableCollection<string>();
        private ObservableCollection<string> dogBreedsListCollection = new ObservableCollection<string>();

        public DelegateCommand<string> ChangeLang_Command { get; private set; }

        public MainViewModel()
        {

            ChangeLang_Command = new DelegateCommand<string>(ChangeLang);

            LoadBreeds();
            nbImages();
        }


        private void ChangeLang(string arg)
        {
            Properties.Settings.Default.Language =arg;
            Properties.Settings.Default.Save();

            MessageBox.Show($"{Properties.Resources.msg_Restart}");

            var filename = Application.ResourceAssembly.Location;
            var newFile = Path.ChangeExtension(filename, ".exe");
            Process.Start(newFile);
            Application.Current.Shutdown();
        }

        public int NbImg
        {
            get => nbImg;
            set
            {
                nbImg = value;
                OnPropertyChanged();
            }
        }

        
        public ObservableCollection<string> NbImgCollection
        {
            get => nbImgCollection;
            set
            {
                nbImgCollection = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<string> CurrentList
        {
            get => currentList;
            set
            {
                currentList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> DogBreedsListCollection
        {
            get => dogBreedsListCollection;
            set
            {
                dogBreedsListCollection = value;
                OnPropertyChanged();
            }
        }

        public string SelectedNb
        {
            get => selectedNb;
            set
            {
                selectedNb = value;
                OnPropertyChanged();
            }
        }


        public string SelectedDogBreed
        {
            get => selectedDogBreed;
            set
            {
                selectedDogBreed = value;
                //url = "http" + value;
                OnPropertyChanged();
            }
        }

        private void nbImages()
        {
            NbImgCollection = new ObservableCollection<string> { "1", "3", "5", "10" };
        }

        private async void LoadBreeds()
        {
            List<string> list = await DogApiProcessor.LoadBreedList();
            foreach (string item in list)
            {
                dogBreedsListCollection.Add(item);
            }
        }


    }
}
