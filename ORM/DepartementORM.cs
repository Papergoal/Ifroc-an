using WpfApp13.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp13.Ctrl;

namespace WpfApp13.ORM
{
    class DepartementORM
    {
        public static DepartementViewModel getDepartement(int idDepartement)
        {
            DepartementDAO pDAO = DepartementDAO.getDepartement(idDepartement);
            DepartementViewModel p = new DepartementViewModel(pDAO.idDepartementDAO, pDAO.nomDepartementDAO);
            return p;
        }

        public static ObservableCollection<DepartementViewModel> listeDepartements()
        {
            ObservableCollection<DepartementDAO> lDAO = DepartementDAO.listeDepartements();
            ObservableCollection<DepartementViewModel> l = new ObservableCollection<DepartementViewModel>();
            foreach (DepartementDAO element in lDAO)
            {

                DepartementViewModel p = new DepartementViewModel(element.idDepartementDAO, element.nomDepartementDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateDepartement(DepartementViewModel p)
        {
            DepartementDAO.updateDepartement(new DepartementDAO(p.idDepartementProperty, p.nomDepartementProperty));
        }

        public static void supprimerDepartement(int id)
        {
            DepartementDAO.supprimerDepartement(id);
        }

        public static void insertDepartement(DepartementViewModel p)
        {
            DepartementDAO.insertDepartement(new DepartementDAO(p.idDepartementProperty, p.nomDepartementProperty));
        }
    }
}