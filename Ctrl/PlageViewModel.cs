using WpfApp13.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp13.Ctrl
{
        public class PlageViewModel : INotifyPropertyChanged
        {
            private int idPlage;
            private string nomPlage;
            private string superficiePlage;
            private string idVille;

            public PlageViewModel() { }

            public PlageViewModel(int id, string nom, string idVille, string superficie)
            {
                this.idPlage = id;
                this.nomPlageProperty = nom;
                this.superficiePlageProperty = superficie;
                this.villeProperty = idVille;
        }
            public int idPlageProperty
            {
                get { return idPlage; }
            }

            public String nomPlageProperty
            {
                get { return nomPlage; }
                set
                {
                    nomPlage = value.ToUpper();
                    //this.concatProperty = value.ToUpper() + " " + prenomPlage;
                    OnPropertyChanged("nomPlageProperty");
                }

            }
            public String superficiePlageProperty
            {
                get { return superficiePlage; }
                set
                {
                    this.superficiePlage = value;
                    //this.concatProperty = this.nomPlage + " " + value;
                    OnPropertyChanged("superficiePlageProperty");
                }
            }
        public String villeProperty
        {
            get { return idVille; }
            set
            {
                this.idVille = value;
                //this.concatProperty = this.nomPlage + " " + value;
                OnPropertyChanged("villeProperty");
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
                    PlageORM.updatePlage(this);
                }
            }
        }
}
