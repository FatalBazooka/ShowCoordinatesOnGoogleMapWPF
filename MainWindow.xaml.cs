using System;
using System.Collections.Generic;
using System.Linq;
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
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ShowCoordinatesOnGoogleMapWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SettingWebBrowser();
        }
      

        private void SettingWebBrowser()
        {
            WebBrowserCtrl.Navigate(AppDomain.CurrentDomain.BaseDirectory + @"Resources\GooglePage.html");
            WebBrowserCtrl.LoadCompleted += SendCoordinates; ;
        }
        
        public void SendCoordinates(object sender, NavigationEventArgs e)
        {
            string markers = JsonSerialize(ListCoordinates);
            WebBrowserCtrl.InvokeScript("setMarkers", markers);
        }

        public static string JsonSerialize(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                serializer.WriteObject(stream, obj);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public List<Marker> ListCoordinates { get; set; } = new List<Marker>
        {
            new Marker()
            {
                Description = "asdadasd",
                Latitude = "55.619233",
                Longitude = "51.785334",
                Title = "aaa1111"
            },
            new Marker()
            {
                Description = "ddddddd",
                Latitude = "55.618095",
                Longitude = "51.821644",
                Title = "dddd22222"
            }
        };
    }

  
   
    
}
