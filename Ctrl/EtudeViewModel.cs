using WpfApp13.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp13.Ctrl
{
        public class EtudeViewModel : INotifyPropertyChanged
        {
            private int idEtude;
            private string nomEtude;
            private DateTime dateEtude;
            private string nbPersonne;
            private int Personne_idPersonne;
            //private string concat;

            public EtudeViewModel() { }

            public EtudeViewModel(int id, string nom, DateTime date, string nbpers, int idpers)
            {
                this.idEtude = id;
                this.nomEtudeProperty = nom;
                this.dateEtudeProperty = date;
                this.nbPersonneProperty = nbpers;
                this.idPersonneProperty = idpers;
            }
            public int idEtudeProperty
            {
                get { return idEtude; }
            }

            public String nomEtudeProperty
            {
                get { return nomEtude; }
                set
                {
                    nomEtude = value.ToUpper();
                    //this.concatProperty = value.ToUpper() + " " + prenomEtude;
                    OnPropertyChanged("nomEtudeProperty");
                }

            }
            public DateTime dateEtudeProperty
            {
                get { return dateEtude; }
                set
                {
                    this.dateEtude = value;
                    //this.concatProperty = this.dateEtude + " " + value;
                    OnPropertyChanged("dateEtudeProperty");
                }
            }

        public String nbPersonneProperty
        {
            get { return nbPersonne; }
            set
            {
                this.nbPersonne = value;
                //this.concatProperty = this.nbPersonne + " " + value;
                OnPropertyChanged("nbPersonneProperty");
            }
        }

        public int idPersonneProperty
        {
            get { return Personne_idPersonne; }
            set
            {
                this.Personne_idPersonne = value;
                //this.concatProperty = this.Personne_idPersonne + " " + value;
                OnPropertyChanged("Personne_idPersonneProperty");
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
                    EtudeORM.updateEtude(this);
                }
            }
        }
}
