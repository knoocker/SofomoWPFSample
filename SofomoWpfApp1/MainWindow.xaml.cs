using SofomoClient.ServerFacade.DataModels;
using SofomoClient.ServerFacade.Services;
using SofomoClient.ServerFacade.Tools.DataValidation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SofomoClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IReportsService reportsService;
        public ObservableCollection<string> IpAddresses { get; set; }

        IEnumerable<IpAddressReport> ipAdresReports;

        public MainWindow()
        {
            InitializeComponent();
            //TODO dependency injection of this service
            reportsService = new ReportsService();
            RefreshData();
            deleteIp.Visibility = Visibility.Collapsed;
        }

        private async void addIp_Click(object sender, RoutedEventArgs e)
        {
            if (!IpValidator.IsIpAddressValid(ipAddress.Text))
            {
                MessageBox.Show("IP address is not valid!");
            }
            else
            {
                HttpResponseMessage response = await reportsService.CreateIpAddress(ipAddress.Text);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Successfully added ip address to database");
                }
                else
                {

                    MessageBox.Show("Error adding ip address to database. The given IP already exists in the database.");
                }
                RefreshData();
            }
        }

        private async void RefreshData()
        {
            try
            {
                ipAdresReports = await reportsService.GetAllIpAddress();
                List<string> ipAddresses = ipAdresReports.Select(ip => ip.IpAddress).ToList();
                ipAddressesList.ItemsSource = ipAddresses;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void deleteIp_Click(object sender, RoutedEventArgs e)
        {

            string ip = (string)ipAddressesList.SelectedItem;
            HttpResponseMessage response = await reportsService.DeleteIpAddress(ip);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully deleted ip address");
            }
            else
            {

                MessageBox.Show("Error deleting ip address.");
            }
            RefreshData();

        }



        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void ipAddressesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ipAddressesList.SelectedIndex == -1)
            {
                ipAddressView.ClearView();
                deleteIp.Visibility = Visibility.Collapsed;
            }
            else
            {
                deleteIp.Visibility = Visibility.Visible;
                string ip = (string)ipAddressesList.SelectedItem;
                IpAddressReport ipAddressReport = ipAdresReports.FirstOrDefault(ipAddress => ipAddress.IpAddress == ip);

                ipAddressView.SetIpAddressView(ipAddressReport);
            }
        }
    }
}
