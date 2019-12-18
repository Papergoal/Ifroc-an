using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp13.DAL;

namespace WpfApp13.DAO
{
    /*class PrelevementDAO
    {
        public int idPrelevementDAO;
        public string nomPrelevementDAO;
        public string prenomPrelevementDAO;
        public int idMetierPrelevementDAO;

        public PrelevementDAO(int idPrelevementDAO, string nomPrelevementDAO, string prenomPrelevementDAO, int idMetierPrelevementDAO)
        {
            this.idPrelevementDAO = idPrelevementDAO;
            this.nomPrelevementDAO = nomPrelevementDAO;
            this.prenomPrelevementDAO = prenomPrelevementDAO;
            this.idMetierPrelevementDAO = idMetierPrelevementDAO;
        }

        public static ObservableCollection<PrelevementDAO> listePrelevements()
        {
            ObservableCollection<PrelevementDAO> l = PrelevementDAL.selectPrelevements();
            return l;
        }

        public static PrelevementDAO getPrelevement(int idPrelevement)
        {
            PrelevementDAO p = PrelevementDAL.getPrelevement(idPrelevement);
            return p;
        }

        public static void updatePrelevement(PrelevementDAO p)
        {
            PrelevementDAL.updatePrelevement(p);
        }

        public static void supprimerPrelevement(int id)
        {
            PrelevementDAL.supprimerPrelevement(id);
        }

        public static void insertPrelevement(PrelevementDAO p)
        {
            PrelevementDAL.insertPrelevement(p);
        }
    }*/
}
