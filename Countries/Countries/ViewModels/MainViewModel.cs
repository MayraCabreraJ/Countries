﻿ 

namespace Countries.ViewModels
{
    using System.Collections.Generic;
    using Models;

    public class MainViewModel
    {

        #region Properties
        public List<Country> CountriesList
        {
            get;
            set;
        }
        #endregion

        #region ViewModels
        public CountryViewModel Countries
        {
            get;
            set;
        }

        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Countries = new CountryViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();

            }

            return instance;
        }
        #endregion
    }
}
