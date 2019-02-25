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

        #endregion


        #region Constructor
        public DetailCountryViewModel(Country country)
        {
            this.Country = country;
            this.LoadBorders();
            this.LoadData();
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
