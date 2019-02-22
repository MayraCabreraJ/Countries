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
        #region Command

        public ICommand DetailCommand
        {
            get
            {
                return new RelayCommand(Detail);
            }
        }

        private async void Detail()
        {
             MainViewModel.GetInstance().DetailCountry = new DetailCountryViewModel(this);

            await Application.Current.MainPage.Navigation.PushAsync(new DetailCountryPage());
           // await App.Navigator.PushAsync(new DetailCountryPage());
        }

        #endregion
    }
}
