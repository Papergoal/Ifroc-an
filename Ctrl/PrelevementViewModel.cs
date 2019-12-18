using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp13.ORM;

namespace WpfApp13.Ctrl
{

    /*public class PrelevementViewModel : INotifyPropertyChanged
    {
        private int idPrelevement;
    private string nomPrelevement;
    private string prenomPrelevement;
    //private string concat;
    public MetierViewModel metierPrelevement;

    public PrelevementViewModel() { }

    public PrelevementViewModel(int id, string nom, string prenom, MetierViewModel metier)
    {
        this.idPrelevement = id;
        this.nomPrelevementProperty = nom;
        this.prenomPrelevementProperty = prenom;
        metierPrelevement = metier;
    }
    public int idPrelevementProperty
    {
        get { return idPrelevement; }
    }

    public String nomPrelevementProperty
    {
        get { return nomPrelevement; }
        set
        {
            nomPrelevement = value.ToUpper();
            //this.concatProperty = value.ToUpper() + " " + prenomPrelevement;
            OnPropertyChanged("nomPrelevementProperty");
        }

    }
    public String prenomPrelevementProperty
    {
        get { return prenomPrelevement; }
        set
        {
            this.prenomPrelevement = value;
            this.concatProperty = this.nomPrelevement + " " + value;
            OnPropertyChanged("prenomPrelevementProperty");
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

    public MetierViewModel MetierPrelevement
    {
        get { return metierPrelevement; }
    }

    public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                PrelevementORM.updatePrelevement(this);
            }
        }
    }*/
}
