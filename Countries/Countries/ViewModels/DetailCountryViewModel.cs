using Countries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Countries.ViewModels
{
    public class DetailCountryViewModel : BaseViewModel
    {
        #region Attributes
        private Country country;
        private bool isRefreshing;
        #endregion

        #region Properties
        public Country Country { get; set; }

        public string Flag { get; set; }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }
        #endregion


        #region Constructor
        public DetailCountryViewModel(Country country)
        {
            this.Country = country;
            this.LoadData();
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
