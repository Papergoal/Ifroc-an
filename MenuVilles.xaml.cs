using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp13.Ctrl;
using WpfApp13.ORM;

namespace WpfApp13
{
    /// <summary>
    /// Logique d'interaction pour MenuPlages.xaml
    /// </summary>
    public partial class MenuVilles : Window
    {
        int selectedVilleId;

        ObservableCollection<VilleViewModel> l;

        public MenuVilles()
        {
            InitializeComponent();

            l = VilleORM.listeVilles();

            listeVilles.ItemsSource = l;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Title = e.GetPosition(this).ToString();
        }
        private void listeVilles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeVilles.SelectedIndex < l.Count) && (listeVilles.SelectedIndex >= 0))
            {
                selectedVilleId = (l.ElementAt<VilleViewModel>(listeVilles.SelectedIndex)).idVilleProperty;
            }
        }

        private void LeaveButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
