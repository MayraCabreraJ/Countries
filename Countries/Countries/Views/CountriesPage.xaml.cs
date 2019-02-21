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
    }
}