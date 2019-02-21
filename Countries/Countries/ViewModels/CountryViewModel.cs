

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
        private ObservableCollection<Country> countries;
        

        private ObservableCollection<Country> africa;
        private ObservableCollection<Country> americas;
        private ObservableCollection<Country> asia;
        private ObservableCollection<Country> europe;
        private ObservableCollection<Country> oceania;
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

        public ObservableCollection<Country> Africa
        {
            get { return this.africa; }
            set { SetValue(ref this.africa, value); }
        }

        public ObservableCollection<Country> Americas
        {
            get { return this.americas; }
            set { SetValue(ref this.americas, value); }
        }
        public ObservableCollection<Country> Asia
        {
            get { return this.asia; }
            set { SetValue(ref this.asia, value); }
        }
        public ObservableCollection<Country> Europe
        {
            get { return this.europe; }
            set { SetValue(ref this.europe, value); }
        }
        public ObservableCollection<Country> Oceania
        {
            get { return this.oceania; }
            set { SetValue(ref this.oceania, value); }
        }
        public List<Country> MyCountries { get; set; }
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
            var list = (List<Country>)response.Result;
            this.Countries = new ObservableCollection<Country>(list.Take(10));
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
            var list = (List<Country>)response.Result;

            switch (region)
            {
                case Region.Africa:
                    this.Africa = new ObservableCollection<Country>(list);
                    break;
                case Region.Americas:
                    this.Americas = new ObservableCollection<Country>(list);
                    break;
                case Region.Asia:
                    this.Asia = new ObservableCollection<Country>(list);
                    break;
                case Region.Europe:
                    this.Europe = new ObservableCollection<Country>(list);
                    break;
                case Region.Oceania:
                    this.Oceania = new ObservableCollection<Country>(list);
                    break;
            }

            
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
