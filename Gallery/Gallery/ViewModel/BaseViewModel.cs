using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.ViewModel
{
    using GoogleConnector.BindingModel;

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IBindingModel bindingModel;

        public BaseViewModel(IBindingModel bindingModel)
        {
            this.BindingModel = bindingModel;
        }

        public IBindingModel BindingModel { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
