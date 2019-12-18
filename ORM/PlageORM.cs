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
    class PlageORM
    {
        public static PlageViewModel getPlage(int idPlage)
        {
            PlageDAO pDAO = PlageDAO.getPlage(idPlage);
            PlageViewModel p = new PlageViewModel(pDAO.idPlageDAO, pDAO.nomPlageDAO, pDAO.superficiePlageDAO, pDAO.idVilleDAO);
            return p;
        }

        public static ObservableCollection<PlageViewModel> listePlages()
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listePlages();
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {

                PlageViewModel p = new PlageViewModel(element.idPlageDAO, element.nomPlageDAO, element.superficiePlageDAO, element.idVilleDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updatePlage(PlageViewModel p)
        {
            PlageDAO.updatePlage(new PlageDAO(p.idPlageProperty, p.nomPlageProperty, p.superficiePlageProperty, p.villeProperty));
        }

        public static void supprimerPlage(int id)
        {
            PlageDAO.supprimerPlage(id);
        }

        public static void insertPlage(PlageViewModel p)
        {
            PlageDAO.insertPlage(new PlageDAO(p.idPlageProperty, p.nomPlageProperty, p.superficiePlageProperty, p.villeProperty));
        }
    }
}
