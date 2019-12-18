using WpfApp13.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp13.Ctrl
{
    public class VilleViewModel : INotifyPropertyChanged
    {
        private int idVille;
        private string nomVille;
        private string nomSpecialiste;
        private string idDepartement;
        //private string concat;

        public VilleViewModel() { }

        public VilleViewModel(int id, string nom, string nomspe, string depar)
        {
            this.idVille = id;
            this.nomVilleProperty = nom;
            this.nomSpecialisteProperty = nomspe;
            this.idDepartementProperty = depar;
        }
        public int idVilleProperty
        {
            get { return idVille; }
        }

        public String nomVilleProperty
        {
            get { return nomVille; }
            set
            {
                nomVille = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + nomSpecialiste;
                OnPropertyChanged("nomVilleProperty");
            }

        }
        public String nomSpecialisteProperty
        {
            get { return nomSpecialiste; }
            set
            {
                this.nomSpecialiste = value;
                this.concatProperty = this.idVille + " " + value;
                OnPropertyChanged("nomSpecialisteProperty");
            }
        }
        public String idDepartementProperty
        {
            get { return idDepartement; }
            set
            {
                this.idDepartement = value;
                //this.concatProperty = this.idVille + " " + value;
                OnPropertyChanged("idDepartementProperty");
            }
        }

        public String concatProperty
        {
            get { return ""; }
            set
            {
                //     this.concat = "Ajouter " + value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                VilleORM.updateVille(this);
            }
        }
    }
}
