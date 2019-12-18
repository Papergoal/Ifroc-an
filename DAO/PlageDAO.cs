using WpfApp13.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp13.DAO
{
    class PlageDAO
    {
        public int idPlageDAO;
        public string nomPlageDAO;
        public string superficiePlageDAO;
        public string idVilleDAO;

        public PlageDAO(int idPlageDAO, string nomPlageDAO, string superficiePlageDAO, string idVilleDAO)
        {
            this.idPlageDAO = idPlageDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.superficiePlageDAO = superficiePlageDAO;
            this.idVilleDAO = idVilleDAO;
        }

        public static ObservableCollection<PlageDAO> listePlages()
        {
            ObservableCollection<PlageDAO> l = PlageDAL.selectPlages();
            return l;
        }

        public static PlageDAO getPlage(int idPlage)
        {
            PlageDAO p = PlageDAL.getPlage(idPlage);
            return p;
        }

        public static void updatePlage(PlageDAO p)
        {
            PlageDAL.updatePlage(p);
        }

        public static void supprimerPlage(int id)
        {
            PlageDAL.supprimerPlage(id);
        }

        public static void insertPlage(PlageDAO p)
        {
            PlageDAL.insertPlage(p);
        }
    }
}
