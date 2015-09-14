using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleConnector
{
    using System.ComponentModel;

    public enum Size
    {
        [Description("Icon")]
        icon,
        [Description("Small")]
        small,
        [Description("Medium")]
        medium,
        [Description("Large")]
        large,
        [Description("Extra Large")]
        xlarge,
        [Description("2xExtra Large")]
        xxlarge,
        [Description("Huge")]
        huge
    }
}
