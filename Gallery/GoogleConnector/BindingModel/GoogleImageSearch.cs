namespace GoogleConnector.BindingModel
{
    using System;
    using System.Collections.ObjectModel;

    public class GoogleImageSearch : BindingModel
    {
        private int maxImages = 4;

        public GoogleImageSearch()
        {
            this.Sizes = this.InitializeEnumeration();
        }

        public ObservableCollection<Size> Sizes { get; set; }

        public int MaxImages
        {
            get
            {
                return this.maxImages;
            }
            set
            {
                if (value <= 1 )
                {
                    this.maxImages = 1;
                }
                else if (value >= 8)
                {
                    this.maxImages = 8;
                }
                else
                {
                    this.maxImages = value;
                }

            }
        }

        private ObservableCollection<Size> InitializeEnumeration()
        {
            var result = new ObservableCollection<Size>();

            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                result.Add(size);
            }

            return result;
        }

        public Size ImageSize { get; set; }
    }
}
