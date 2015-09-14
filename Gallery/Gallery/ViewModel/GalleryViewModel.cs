namespace Gallery.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    using GalaSoft.MvvmLight.Command;

    using GoogleConnector;
    using GoogleConnector.BindingModel;

    using Size = GoogleConnector;

    public class GalleryViewModel : BaseViewModel
    {
        private const string googleLogoImagePath =
            "http://4.bp.blogspot.com/-JOqxgp-ZWe0/U3BtyEQlEiI/AAAAAAAAOfg/Doq6Q2MwIKA/s1600/google-logo-874x288.png";

        private IBindingModel googleImageSearch;
        
        private ICommand clickImage;

        private ICommand nextCommand;

        private ICommand previousCommand;

        private RelayCommand googleSearch;

        private Uri imagePath;

        private int imgIndex;
        
        public GalleryViewModel() 
            : base(new GoogleImageSearch())
        {
            this.ImagesPath = new ObservableCollection<string>();
            this.ImagePath = new Uri(googleLogoImagePath);
            this.GoogleImageSearch = this.BindingModel;
        }

        public IBindingModel GoogleImageSearch
        {
            get
            {
                return this.googleImageSearch;
            }
            set
            {
                this.googleImageSearch = value;
                this.OnPropertyChanged("GoogleImageSearch");
            }
        }

        public ICommand IconImageCommand
        {
            get
            {
                return this.clickImage ?? (this.clickImage = new RelayCommand<object>(this.ChangeImageBasedOnIconImageClick));
            }
        }

        public ICommand NextButtonCommand
        {
            get
            {
                return this.nextCommand ?? (this.nextCommand = new RelayCommand(this.NextImage));
            }
        }

        public ICommand PreviousButtonCommand
        {
            get
            {
                return this.previousCommand ?? (this.previousCommand = new RelayCommand(this.PreviousImage));
            }
        }

        public RelayCommand GoogleSearch
        {
            get
            {
                if (this.googleSearch == null)
                {
                    this.googleSearch = new RelayCommand(this.ExecuteGoogleSearch);
                }

                return this.googleSearch;
            }
        }
        
        public Uri ImagePath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                this.imagePath = value;
                this.OnPropertyChanged("ImagePath");
            }
        }

        private int ImageIndex
        {
            get
            {
                return this.imgIndex;
            }
            set
            {
                if (value < 0)
                {
                    this.imgIndex = this.ImagesPath.Count() - 1;
                }
                else if (value >= this.ImagesPath.Count())
                {
                    this.imgIndex = 0;
                }
                else
                {
                    this.imgIndex = value;
                }
            }
        }

        public ObservableCollection<string> ImagesPath { get; set; }

        private Uri GetImagePath
        {
            get
            {
                if (!this.ImagesPath.Any())
                {
                    return new Uri(googleLogoImagePath);
                }

                return new Uri(this.ImagesPath[this.ImageIndex]);
            }
        }

        private void PreviousImage()
        {
            this.ImageIndex--;
            this.ImagePath = this.GetImagePath;
        }

        private void NextImage()
        {
            this.ImageIndex++;
            this.ImagePath = this.GetImagePath;
        }
        
        private void ChangeImageBasedOnIconImageClick(object sender)
        {
            this.ImagePath = new Uri(sender.ToString());
            this.ImageIndex = this.ImagesPath.IndexOf(sender.ToString());
        }

        private void ExecuteGoogleSearch()
        {
            var urls = DataPersister.GetImageUrls(this.GoogleImageSearch);
            if (urls.Any())
            {
                this.ImagesPath.Clear();
                foreach (var url in urls)
                {
                    this.ImagesPath.Add(url);
                }
            }
        }
    }
}