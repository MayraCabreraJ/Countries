using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.ViewModels
{
    using Countries.Views;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class CountryItemViewModel : Country
    {

        public List<Country> MyCountries { get; set; }

        #region Command

        public ICommand DetailCommand
        {
            get
            {
                return new RelayCommand(Detail);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            MyCountries = MainViewModel.GetInstance().CountriesList;
        }

        private async void Detail()
        {
             MainViewModel.GetInstance().DetailCountry = new DetailCountryViewModel(this);

            await Application.Current.MainPage.Navigation.PushAsync(new DetailCountyTabbedPage());
           // await App.Navigator.PushAsync(new DetailCountryPage());
        }

        #endregion
    }
}
