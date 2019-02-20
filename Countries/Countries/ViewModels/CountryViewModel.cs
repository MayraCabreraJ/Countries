

namespace Countries.ViewModels
{
    using Countries.Services;
    using System.Collections.ObjectModel;
    using Models;
    using Xamarin.Forms;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using System;

    public class CountryViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion


        #region Attributes
        private string name;
        private ObservableCollection<Country> countries;
        private ObservableCollection<Country> countriesRegion;
        private ICommand playingCommand;
       
        #endregion


        #region Properties

    
      

        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

        public ObservableCollection<Country> Countries
        {
            get { return this.countries; }
            set { SetValue(ref this.countries, value); }
        }

        public ObservableCollection<Country> CountriesRegion
        {
            get { return this.countriesRegion; }
            set { SetValue(ref this.countriesRegion, value); }
        }

        public List<Country> MyCountries { get; set; }
        #endregion


        #region Constructors
        public CountryViewModel()
        {
            this.Name = "Antonio Tamez Salinas";
            this.apiService = new ApiService();
            this.LoadCountries();
            this.LoadCountries("Americas");
        }


        #endregion


        #region Methods
        private async void LoadCountries()
        {
            var response = await this.apiService.GetList<Country>(
         "http://restcountries.eu",
         "/rest",
         "/v2/all");

            if (!response.IsSuccess)
            {
                //this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var list = (List<Country>)response.Result;
            this.Countries = new ObservableCollection<Country>(list.Take(10));
        }
   
        private async void LoadCountries(string region)
        {
            var controller = $"/v2/region/{region}";

            var response = await this.apiService.GetList<Country>(
         "http://restcountries.eu",
         "/rest",
         controller);

            if (!response.IsSuccess)
            {
                //this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var list = (List<Country>)response.Result;
            this.CountriesRegion = new ObservableCollection<Country>(list);
        }


        private IEnumerable<CountryItemViewModel> ToCountryItemViewModel()
        {
            return MainViewModel.GetInstance().CountriesList.Select(l => new CountryItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }
        #endregion


        #region Commands
        public ICommand PlayingCommand
        {
            get
            {
                return new RelayCommand(Playing);
            }
            
        }

        private void Playing()
        {
             
        }
        #endregion
    }
}
