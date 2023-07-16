using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SofomoClient.ServerFacade.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
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
using System.Xml;

namespace SofomoClient.Components
{
    /// <summary>
    /// Interaction logic for IpAdresReportView.xaml
    /// </summary>
    public partial class IpAdresReportView : UserControl
    {
        public IpAdresReportView()
        {
            InitializeComponent();

            mainGrid.Visibility = Visibility.Collapsed;
        }


        public void SetIpAddressView(IpAddressReport ipAddressReport)
        {
            mainGrid.Visibility = Visibility.Visible;
            region.Content = ipAddressReport.Region;


            city.Content = ipAddressReport.City;
             country.Content = ipAddressReport.Country;
            dynamic parsedJson = JsonConvert.DeserializeObject(ipAddressReport.Content);
            jsonContent.Text = JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);

        }



        internal void ClearView()
        {
            mainGrid.Visibility = Visibility.Collapsed;
        }
    }
}
