using WpfApp13.DAL;
using WpfApp13.ORM;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp13.Ctrl;

namespace WpfApp13
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int selectedPersonneId;

        int selectedPlageId;

        int selectedDepartementId;

        int selectedEtudeId;

        PersonneViewModel myDataObject;

        PlageViewModel myDataObject2;

        EtudeViewModel myDataObject3;

        ObservableCollection<PersonneViewModel> lp;

        ObservableCollection<PlageViewModel> pl;

        ObservableCollection<DepartementViewModel> dp;

        ObservableCollection<EtudeViewModel> et;

        int compteur = 0;

        public MainWindow()
        {
            InitializeComponent();
            DALConnection.OpenConnection();

            lp = PersonneORM.listePersonnes();

            listePersonnes.ItemsSource = lp;

            pl = PlageORM.listePlages();

            listePlages.ItemsSource = pl;

            dp = DepartementORM.listeDepartements();

            listeDepartements.ItemsSource = dp;

            et = EtudeORM.listeEtudes();

            listeEtudes.ItemsSource = et;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Title = e.GetPosition(this).ToString();
        }

        public void prenomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.prenomPersonneProperty = prenomTextBox.Text;
        }
        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.nomPersonneProperty = nomTextBox.Text;
        }
        public void nom2Changed(object sender, TextChangedEventArgs e)
        {
            myDataObject2.nomPlageProperty = nompTextBox.Text;
        }
        public void superficieChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject2.superficiePlageProperty = superficieTextBox.Text;
        }

        private void listePersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePersonnes.SelectedIndex < lp.Count) && (listePersonnes.SelectedIndex >= 0))
            {
                selectedPersonneId = (lp.ElementAt<PersonneViewModel>(listePersonnes.SelectedIndex)).idPersonneProperty;
            }
        }

        private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimmer?", "My App", MessageBoxButton.YesNo);
                switch (result)
            {
                case MessageBoxResult.Yes:
                    PersonneViewModel toRemove = (PersonneViewModel)listePersonnes.SelectedItem;
                    lp.Remove(toRemove);
                    listePersonnes.Items.Refresh();
                    PersonneORM.supprimerPersonne(selectedPersonneId);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void nomPrenomButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            myDataObject = new PersonneViewModel();
            myDataObject.prenomPersonneProperty = prenomTextBox.Text;
            myDataObject.nomPersonneProperty = nomTextBox.Text;
            PersonneViewModel nouveau = new PersonneViewModel(PersonneDAL.getMaxIdPersonne() + 1, myDataObject.nomPersonneProperty, myDataObject.prenomPersonneProperty);
            lp.Add(nouveau);
            PersonneORM.insertPersonne(nouveau);
            listePersonnes.Items.Refresh();
            compteur = lp.Count();
            myDataObject = new PersonneViewModel(PersonneDAL.getMaxIdPersonne() + 1, "", "");
        }

        private void listePlages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePlages.SelectedIndex < pl.Count) && (listePlages.SelectedIndex >= 0))
            {
                selectedPlageId = (pl.ElementAt<PlageViewModel>(listePlages.SelectedIndex)).idPlageProperty;
            }
        }
        private void plageButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            myDataObject2 = new PlageViewModel();
            myDataObject2.nomPlageProperty = nompTextBox.Text;
            myDataObject2.superficiePlageProperty = superficieTextBox.Text;
            myDataObject2.villeProperty = idvilleTextBox.Text;
            PlageViewModel nouveau = new PlageViewModel(PlageDAL.getMaxIdPlage() + 1, myDataObject2.nomPlageProperty, myDataObject2.superficiePlageProperty, myDataObject2.villeProperty);
            pl.Add(nouveau);
            PlageORM.insertPlage(nouveau);
            listePlages.Items.Refresh();
            compteur = pl.Count();
            myDataObject2 = new PlageViewModel(PlageDAL.getMaxIdPlage() + 1, "", "", "");
            
        }

        private void goVilleButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window w = new MenuVilles();
            w.Show();
        }
        private void listeDepartements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeDepartements.SelectedIndex < dp.Count) && (listeDepartements.SelectedIndex >= 0))
            {
                selectedDepartementId = (dp.ElementAt<DepartementViewModel>(listeDepartements.SelectedIndex)).idDepartementProperty;
            }
        }

        private void supprimer2Button_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimmer?", "My App", MessageBoxButton.YesNo);
                switch (result)
            {
                case MessageBoxResult.Yes:
                    PlageViewModel toRemove = (PlageViewModel)listePlages.SelectedItem;
                    pl.Remove(toRemove);
                    listePlages.Items.Refresh();
                    PlageORM.supprimerPlage(selectedPlageId);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void listeEtudes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEtudes.SelectedIndex < et.Count) && (listeEtudes.SelectedIndex >= 0))
            {
                selectedEtudeId = (et.ElementAt<EtudeViewModel>(listeEtudes.SelectedIndex)).idEtudeProperty;
            }
        }

        private void etudeButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            myDataObject3 = new EtudeViewModel();
            myDataObject3.nomEtudeProperty = nomeTextBox.Text;
            myDataObject3.dateEtudeProperty = dateDatePicker.DisplayDate;
            myDataObject3.nbPersonneProperty = nbpersTextBox.Text;
            myDataObject3.idPersonneProperty = Convert.ToInt32(idpersTextBox.Text);
            EtudeViewModel nouveau = new EtudeViewModel(EtudeDAL.getMaxIdEtude() + 1, myDataObject3.nomEtudeProperty, myDataObject3.dateEtudeProperty, myDataObject3.nbPersonneProperty, myDataObject3.idPersonneProperty);
            et.Add(nouveau);
            EtudeORM.insertEtude(nouveau);
            listeEtudes.Items.Refresh();
            compteur = et.Count();
            myDataObject3 = new EtudeViewModel(EtudeDAL.getMaxIdEtude() + 1, "", myDataObject3.dateEtudeProperty, "", myDataObject3.idPersonneProperty);
        }
    }
}
