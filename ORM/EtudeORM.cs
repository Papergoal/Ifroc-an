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
    class EtudeORM
    {
        public static EtudeViewModel getEtude(int idEtude)
        {
            EtudeDAO pDAO = EtudeDAO.getEtude(idEtude);
            EtudeViewModel p = new EtudeViewModel(pDAO.idEtudeDAO, pDAO.nomEtudeDAO, pDAO.dateEtudeDAO, pDAO.nbPersonneDAO, pDAO.idPersonneDAO);
            return p;
        }

        public static ObservableCollection<EtudeViewModel> listeEtudes()
        {
            ObservableCollection<EtudeDAO> lDAO = EtudeDAO.listeEtudes();
            ObservableCollection<EtudeViewModel> l = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in lDAO)
            {

                EtudeViewModel p = new EtudeViewModel(element.idEtudeDAO, element.nomEtudeDAO, element.dateEtudeDAO, element.nbPersonneDAO, element.idPersonneDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateEtude(EtudeViewModel p)
        {
            EtudeDAO.updateEtude(new EtudeDAO(p.idEtudeProperty, p.nomEtudeProperty, p.dateEtudeProperty, p.nbPersonneProperty, p.idPersonneProperty));
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAO.supprimerEtude(id);
        }

        public static void insertEtude(EtudeViewModel p)
        {
            EtudeDAO.insertEtude(new EtudeDAO(p.idEtudeProperty, p.nomEtudeProperty, p.dateEtudeProperty, p.nbPersonneProperty, p.idPersonneProperty));
        }
    }
}
