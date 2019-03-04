

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
   
    using Region = Models.Region;

    public class CountryViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion


        #region Attributes
        private string name;
        private ObservableCollection<CountryItemViewModel> countries;
        
        private ObservableCollection<CountryItemViewModel> africa;
        private ObservableCollection<CountryItemViewModel> americas;
        private ObservableCollection<CountryItemViewModel> asia;
        private ObservableCollection<CountryItemViewModel> europe;
        private ObservableCollection<CountryItemViewModel> oceania;
        private ICommand playingCommand;

        private bool isRefreshing;
        private string filter;
        #endregion


        #region Properties
        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

        public ObservableCollection<CountryItemViewModel> Countries
        {
            get { return this.countries; }
            set { SetValue(ref this.countries, value); }
        }

        public ObservableCollection<CountryItemViewModel> Africa
        {
            get { return this.africa; }
            set { SetValue(ref this.africa, value); }
        }
        public ObservableCollection<CountryItemViewModel> Americas
        {
            get { return this.americas; }
            set { SetValue(ref this.americas, value); }
        }
        public ObservableCollection<CountryItemViewModel> Asia
        {
            get { return this.asia; }
            set { SetValue(ref this.asia, value); }
        }
        public ObservableCollection<CountryItemViewModel> Europe
        {
            get { return this.europe; }
            set { SetValue(ref this.europe, value); }
        }
        public ObservableCollection<CountryItemViewModel> Oceania
        {
            get { return this.oceania; }
            set { SetValue(ref this.oceania, value); }
        }
        public List<Country> MyCountries { get; set; }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion


        #region Constructors
        public CountryViewModel()
        {
            this.Name = "Antonio Tamez Salinas";
            this.apiService = new ApiService();
            this.LoadCountries();
            this.LoadCountries(Region.Africa);
            this.LoadCountries(Region.Americas);
            this.LoadCountries(Region.Asia);
            this.LoadCountries(Region.Europe);
            this.LoadCountries(Region.Oceania);
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
            MainViewModel.GetInstance().CountriesList = (List<Country>)response.Result;

            this.MyCountries = (List<Country>)response.Result;
            IEnumerable<CountryItemViewModel> myListCountriesItemViewModel = CountryToCountryItemViewModel();
            this.Countries = new ObservableCollection<CountryItemViewModel>(myListCountriesItemViewModel);

        }



        private async void LoadCountries(Models.Region region)
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
            this.MyCountries = (List<Country>)response.Result;
            IEnumerable<CountryItemViewModel> myListCountriesItemViewModel = CountryToCountryItemViewModel();

            switch (region)
            {
                case Region.Africa:
                    this.Africa = new ObservableCollection<CountryItemViewModel>(myListCountriesItemViewModel);
                    break;
                case Region.Americas:
                    this.Americas = new ObservableCollection<CountryItemViewModel>(myListCountriesItemViewModel);
                    break;
                case Region.Asia:
                    this.Asia = new ObservableCollection<CountryItemViewModel>(myListCountriesItemViewModel);
                    break;
                case Region.Europe:
                    this.Europe = new ObservableCollection<CountryItemViewModel>(myListCountriesItemViewModel);
                    break;
                case Region.Oceania:
                    this.Oceania = new ObservableCollection<CountryItemViewModel>(myListCountriesItemViewModel);
                    break;
            }


        }

        private IEnumerable<CountryItemViewModel> CountryToCountryItemViewModel()
        {
            return this.MyCountries.Select(c => new CountryItemViewModel
            {

                Name = c.Name,
                TopLevelDomain = c.TopLevelDomain,
                Alpha2Code = c.Alpha2Code,
                Alpha3Code = c.Alpha3Code,
                CallingCodes = c.CallingCodes,
                Capital = c.Capital,
                AltSpellings = c.AltSpellings,
                Region = c.Region,
                Subregion = c.Subregion,
                Population = c.Population,
                Latlng = c.Latlng,
                Demonym = c.Demonym,
                Area = c.Area,
                Gini = c.Gini,
                Timezones = c.Timezones,
                Borders = c.Borders,
                NativeName = c.NativeName,
                NumericCode = c.NumericCode,
                Currencies = c.Currencies,
                Languages = c.Languages,
                Translations = c.Translations,
                Flag = c.Flag,
                RegionalBlocs = c.RegionalBlocs,
                Cioc = c.Cioc,
            });
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
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Countries = new ObservableCollection<CountryItemViewModel>(
                    this.ToCountryItemViewModel());
            }
            else
            {
                this.Countries = new ObservableCollection<CountryItemViewModel>(
                    this.ToCountryItemViewModel().Where(
                        l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }

        #endregion
    }
}
