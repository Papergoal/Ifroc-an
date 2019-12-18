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
    class VilleORM
    {
        public static VilleViewModel getVille(int idVille)
        {
            VilleDAO pDAO = VilleDAO.getVille(idVille);
            VilleViewModel p = new VilleViewModel(pDAO.idVilleDAO, pDAO.nomVilleDAO, pDAO.nomSpecialisteDAO, pDAO.idDepartementDAO);
            return p;
        }

        public static ObservableCollection<VilleViewModel> listeVilles()
        {
            ObservableCollection<VilleDAO> lDAO = VilleDAO.listeVilles();
            ObservableCollection<VilleViewModel> l = new ObservableCollection<VilleViewModel>();
            foreach (VilleDAO element in lDAO)
            {

                VilleViewModel p = new VilleViewModel(element.idVilleDAO, element.nomVilleDAO, element.nomSpecialisteDAO, element.idDepartementDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateVille(VilleViewModel p)
        {
            VilleDAO.updateVille(new VilleDAO(p.idVilleProperty, p.nomVilleProperty, p.nomSpecialisteProperty, p.idDepartementProperty));
        }

        public static void supprimerVille(int id)
        {
            VilleDAO.supprimerVille(id);
        }

        public static void insertVille(VilleViewModel p)
        {
            VilleDAO.insertVille(new VilleDAO(p.idVilleProperty, p.nomVilleProperty, p.nomSpecialisteProperty, p.idDepartementProperty));
        }
    }
}
