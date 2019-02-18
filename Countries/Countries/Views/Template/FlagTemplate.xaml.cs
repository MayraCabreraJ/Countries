using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Countries.Views.Template
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlagTemplate : ContentView
    {
        public FlagTemplate()
        {
            InitializeComponent();
        }
    }
}