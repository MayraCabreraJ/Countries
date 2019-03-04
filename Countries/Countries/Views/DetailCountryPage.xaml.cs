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

            detailCountryPage.Opacity = 0;
            detailCountryPage.FadeTo(1, 250, Easing.BounceIn);
            animateFlag();
        }

        private async void animateFlag()
        {
            mainData.Opacity = 0;
            borders.Opacity = 0;

            await flag.ScaleTo(3, 100);
            await flag.ScaleTo(1, 1000, Easing.SpringOut);

            await mainData.FadeTo(1, 250, Easing.BounceOut);
            await borders.FadeTo(1, 250, Easing.BounceOut);

        }
    }
}