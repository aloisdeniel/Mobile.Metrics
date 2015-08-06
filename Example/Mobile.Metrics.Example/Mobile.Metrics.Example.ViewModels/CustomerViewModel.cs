using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mobile.Metrics.Example.Models.DataAccess;
using Mobile.Metrics.Example.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Example.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        public CustomerViewModel(CustomerDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
            this.UpdateCommand = new RelayCommand<int>(ExecuteUpdateCommand, CanExecuteUpdateCommand);
        }

        #region Fields

        private CustomerDataAccess dataAccess;

        private bool isUpdating;

        private string name;

        private IEnumerable<Contact> contacts;

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

        public IEnumerable<Contact> Contacts
        {
            get { return this.contacts; }
            set { this.Set(ref this.contacts, value); }
        }

        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        #endregion

        #region Commands

        public RelayCommand<int> UpdateCommand { get; private set; }

        private async void ExecuteUpdateCommand(int id)
        {
            try
            {
                var customer = await this.dataAccess.GetCustomer(id);
                this.Name = customer.Name;
                this.Contacts = customer.Contacts;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Update failed : " + e.Message);
            }
        }

        private bool CanExecuteUpdateCommand(int id)
        {
            return !this.isUpdating;
        }

        #endregion
    }
}
