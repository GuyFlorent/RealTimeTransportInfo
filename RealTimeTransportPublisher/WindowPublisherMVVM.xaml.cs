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
using RealTimeTransportPublisher.VueModelTrain;
namespace RealTimeTransportPublisher
{ 
    /// <summary>
    /// Logique d'interaction pour WindowPublisherMVVM.xaml
    /// </summary>
    public partial class WindowPublisherMVVM : Window
    {
        
        public WindowPublisherMVVM()
        {
            InitializeComponent();
            this.DataContext = new VueModelTrain.VueModelTrain();
        }
    }
}
