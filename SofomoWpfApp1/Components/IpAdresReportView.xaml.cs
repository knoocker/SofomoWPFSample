using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SofomoWpfApp1.DataModels;
using SofomoWpfApp1.Tools;
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

namespace SofomoWpfApp1.Components
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
            dynamic parsedJson = JsonConvert.DeserializeObject(ipAddressReport.Content);
            region.Content = parsedJson.region_name;


            city.Content = parsedJson.city;
             country.Content = parsedJson.country_name;
            jsonContent.Text = JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);

        }



        internal void ClearView()
        {
            mainGrid.Visibility = Visibility.Collapsed;
        }
    }
}
