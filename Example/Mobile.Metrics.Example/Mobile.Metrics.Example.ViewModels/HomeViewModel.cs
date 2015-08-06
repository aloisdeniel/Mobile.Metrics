using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mobile.Metrics.Example.Models.DataAccess;
using Mobile.Metrics.Example.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Mobile.Metrics.Example.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(CustomerDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
            this.UpdateCommand = new RelayCommand(ExecuteUpdateCommand, CanExecuteUpdateCommand);
        }

        #region Fields

        private CustomerDataAccess dataAccess;

        private bool isUpdating;

        private IEnumerable<Customer> customers;

        #endregion

        #region Properties

        public bool IsUpdating
        {
            get { return this.isUpdating; }
            set
            {
                if (this.Set(ref this.isUpdating, value))
                {
                    this.UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public IEnumerable<Customer> Customers
        {
            get { return this.customers; }
            set { this.Set(ref this.customers, value); }
        }

        #endregion

        #region Commands

        public RelayCommand UpdateCommand { get; private set; }

        private async void ExecuteUpdateCommand()
        {
            try
            {
                this.Customers = await this.dataAccess.GetCustomers();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Update failed : " + e.Message);
            }
        }

        private bool CanExecuteUpdateCommand()
        {
            return !this.isUpdating;
        }

        #endregion
    }
}
