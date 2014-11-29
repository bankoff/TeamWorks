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

namespace UITournament
{
    /// <summary>
    /// Interaction logic for TоurnamentView.xaml
    /// </summary>
    public partial class TоurnamentView : Window
    {
        public TоurnamentView()
        {
            InitializeComponent();
        }

        private void sprint100metresClick(object sender, RoutedEventArgs e)
        {
            Standing sprint100 = new Standing();
            sprint100.ShowDialog();
        }

    }
}