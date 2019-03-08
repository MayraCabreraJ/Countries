using Countries.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Countries.ViewModels
{
    public class DetailCountryViewModel : BaseViewModel
    {

        

        #region Attributes
        private Country country;
        private bool isRefreshing;
        private ObservableCollection<Border> borders;
        private ObservableCollection<CountryData> countryData;
        private ObservableCollection<Currency> currency;
        private ObservableCollection<RegionalBloc> regionalBloc;


        #endregion

        #region Properties
        public Country Country { get; set; }

        public string Flag { get; set; }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }
        public ObservableCollection<Border> Borders
        {
            get { return this.borders; }
            set { this.SetValue(ref this.borders, value); }
        }
        public ObservableCollection<CountryData> CountryData
        {
            get { return this.countryData; }
            set { this.SetValue(ref this.countryData, value); }
        }

        public ObservableCollection<Currency> Currency
        {
            get { return this.currency; }
            set { this.SetValue(ref this.currency, value); }
        }

        public ObservableCollection<RegionalBloc> RegionalBloc
        {
            get { return this.regionalBloc; }
            set { this.SetValue(ref this.regionalBloc, value); }
        }
        #endregion


        #region Constructor
        public DetailCountryViewModel(Country country)
        {
            this.Country = country;
            this.LoadBorders();
            this.LoadData();
            this.LoadCountryData();
            this.LoadCurrencies();
            this.LoadRegionalBloc();


        }

        private void LoadRegionalBloc()
        {
            this.RegionalBloc = new ObservableCollection<RegionalBloc>();
            foreach(var item in this.Country.RegionalBlocs)
            {
                this.RegionalBloc.Add(
                    new RegionalBloc{
                        Acronym = item.Acronym,
                        Name = item.Name,
                    });
            }
        }

        private void LoadCurrencies()
        {
            this.Currency = new ObservableCollection<Currency>();

            foreach (var item in this.Country.Currencies)
            {
                this.Currency.Add(new Currency
                {
                    Code = item.Code,
                    Name = item.Name,
                    Symbol = item.Symbol,
                });
            }
        }

        private void LoadCountryData()
        {
            this.CountryData = new ObservableCollection<CountryData>();
            this.CountryData.Add(new CountryData { Label = "Alpha 2 Code", Data = this.Country.Alpha2Code });
            this.CountryData.Add(new CountryData { Label = "Alpha 3 Code", Data = this.Country.Alpha3Code });
            this.CountryData.Add(new CountryData { Label = "Area", Data = this.Country.Area.ToString() });
            this.CountryData.Add(new CountryData { Label = "Capital", Data = this.Country.Capital });
            this.CountryData.Add(new CountryData { Label = "Cioc", Data = this.Country.Cioc });
            this.CountryData.Add(new CountryData { Label = "Demonym", Data = this.Country.Demonym });
            this.CountryData.Add(new CountryData { Label = "Name", Data = this.Country.Name });
            this.CountryData.Add(new CountryData { Label = "Native Name", Data = this.Country.NativeName });
            this.CountryData.Add(new CountryData { Label = "Numeric Code", Data = this.Country.NumericCode });
            this.CountryData.Add(new CountryData { Label = "Population", Data = this.Country.Population.ToString() });
            this.CountryData.Add(new CountryData { Label = "Region", Data = this.Country.Region });
            this.CountryData.Add(new CountryData { Label = "Subregion", Data = this.Country.Subregion }); 
        }

        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach(var border in this.Country.Borders)
            {
                var land = MainViewModel.GetInstance().CountriesList.
                    Where(l => l.Alpha3Code == border).
                    FirstOrDefault();

                if(land != null)
                {
                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name,
                    });
                }

                    
            }
        }

        private void LoadData()
        {
            this.IsRefreshing = true;
            Flag = this.Country.Flag;
            this.IsRefreshing = false;

        


        }
        #endregion

    }
}
