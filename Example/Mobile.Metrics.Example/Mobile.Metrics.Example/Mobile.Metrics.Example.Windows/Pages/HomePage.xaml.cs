using GalaSoft.MvvmLight.Ioc;
using Mobile.Metrics.Example.Models.Entities;
using Mobile.Metrics.Example.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Mobile.Metrics.Example.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            this.DataContext = SimpleIoc.Default.GetInstance<HomeViewModel>();
        }

        private HomeViewModel ViewModel { get { return this.DataContext as HomeViewModel; } }

        private void CustomerListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var customer = e.ClickedItem as Customer;
            this.Frame.Navigate(typeof(CustomerPage), customer.Identifier);
        }
    }
}
