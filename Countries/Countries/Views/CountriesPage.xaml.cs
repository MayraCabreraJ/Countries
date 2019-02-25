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
    public partial class CountriesPage : ContentPage
    {

        
        public CountriesPage()
        {

            InitializeComponent();

            LottieView.OnClick += LottieView_OnClick;

        }

      

        private void LottieView_OnClick(object sender, EventArgs e)
        {
            //LottieView.Play();
           // LottieView.Progress = 25f;
        }

        private async void ViewCell_Appearing(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var view = cell.View;

            view.TranslationX = -100;
            view.Opacity = 0;

            await Task.WhenAny<bool>
                (
                    view.TranslateTo(0, 0, 250, Easing.SinIn),
                    view.FadeTo(1,500,Easing.BounceIn)
                );
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //wait this.FadeTo(0, 250, Easing.SinInOut);
        }
    }
}