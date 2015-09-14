using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleConnector.BindingModel
{
    public abstract class BindingModel : IBindingModel
    {
        public string SearchText { get; set ; }
    }
}
