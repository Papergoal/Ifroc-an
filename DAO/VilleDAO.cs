using WpfApp13.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp13.DAO
{
    class VilleDAO
    {
        public int idVilleDAO;
        public string nomVilleDAO;
        public string nomSpecialisteDAO;
        public string idDepartementDAO;

        public VilleDAO(int idVilleDAO, string nomVilleDAO, string nomSpecialisteDAO, string idDepartementDAO)
        {
            this.idVilleDAO = idVilleDAO;
            this.nomVilleDAO = nomVilleDAO;
            this.nomSpecialisteDAO = nomSpecialisteDAO;
            this.idDepartementDAO = idDepartementDAO;
        }

        public static ObservableCollection<VilleDAO> listeVilles()
        {
            ObservableCollection<VilleDAO> l = VilleDAL.selectVilles();
            return l;
        }

        public static VilleDAO getVille(int idVille)
        {
            VilleDAO p = VilleDAL.getVille(idVille);
            return p;
        }

        public static void updateVille(VilleDAO p)
        {
            VilleDAL.updateVille(p);
        }

        public static void supprimerVille(int id)
        {
            VilleDAL.supprimerVille(id);
        }

        public static void insertVille(VilleDAO p)
        {
            VilleDAL.insertVille(p);
        }
    }
}
