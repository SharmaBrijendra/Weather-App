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
using System.Windows.Shapes;
using Weather.ViewModels;

namespace Weather.Views
{
    /// <summary>
    /// Interaction logic for WeatherHomePageView.xaml
    /// </summary>
    public partial class WeatherHomePageView : Window
    {
        public WeatherHomePageView()
        {
            InitializeComponent();
            this.DataContext = new WeatherHomePageViewModel();
        }
    }
}
