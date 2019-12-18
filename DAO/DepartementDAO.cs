using WpfApp13.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp13.DAO
{
    class DepartementDAO
    {
        public int idDepartementDAO;
        public string nomDepartementDAO;

        public DepartementDAO(int idDepartementDAO, string nomDepartementDAO)
        {
            this.idDepartementDAO = idDepartementDAO;
            this.nomDepartementDAO = nomDepartementDAO;
        }

        public static ObservableCollection<DepartementDAO> listeDepartements()
        {
            ObservableCollection<DepartementDAO> l = DepartementDAL.selectDepartements();
            return l;
        }

        public static DepartementDAO getDepartement(int idDepartement)
        {
            DepartementDAO p = DepartementDAL.getDepartement(idDepartement);
            return p;
        }

        public static void updateDepartement(DepartementDAO p)
        {
            DepartementDAL.updateDepartement(p);
        }

        public static void supprimerDepartement(int id)
        {
            DepartementDAL.supprimerDepartement(id);
        }

        public static void insertDepartement(DepartementDAO p)
        {
            DepartementDAL.insertDepartement(p);
        }
    }
}
