using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Countries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailCountryPage : ContentPage
    {
        public DetailCountryPage()
        {
            InitializeComponent();
            animateFlag();
        }

        private async void animateFlag()
        {
            await flag.ScaleTo(3, 100);
            await flag.ScaleTo(1, 1000, Easing.SpringOut);
        }
    }
}