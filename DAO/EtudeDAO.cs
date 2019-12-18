using WpfApp13.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp13.DAO
{
    class EtudeDAO
    {
        public int idEtudeDAO;
        public string nomEtudeDAO;
        public DateTime dateEtudeDAO;
        public string nbPersonneDAO;
        public int idPersonneDAO;


        public EtudeDAO(int idEtudeDAO, string nomEtudeDAO, DateTime dateEtudeDAO, string nbPersonneDAO, int idPersonneDAO)
        {
            this.idEtudeDAO = idEtudeDAO;
            this.nomEtudeDAO = nomEtudeDAO;
            this.dateEtudeDAO = dateEtudeDAO;
            this.nbPersonneDAO = nbPersonneDAO;
            this.idPersonneDAO = idPersonneDAO;
        }

        public static ObservableCollection<EtudeDAO> listeEtudes()
        {
            ObservableCollection<EtudeDAO> l = EtudeDAL.selectEtudes();
            return l;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            EtudeDAO e = EtudeDAL.getEtude(idEtude);
            return e;
        }

        public static void updateEtude(EtudeDAO p)
        {
            EtudeDAL.updateEtude(p);
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAL.supprimerEtude(id);
        }

        public static void insertEtude(EtudeDAO p)
        {
            EtudeDAL.insertEtude(p);
        }
    }
}
