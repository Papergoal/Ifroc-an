using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp13.Ctrl;
using WpfApp13.DAO;

namespace WpfApp13.ORM
{
    /*class PrelevementORM
    {
        public static PrelevementViewModel getPrelevement(int idPrelevement)
        {
            PrelevementDAO pDAO = PrelevementDAO.getPrelevement(idPrelevement);
            int idMetier = pDAO.idMetierPrelevementDAO;
            PrelevementViewModel p = new PrelevementViewModel(pDAO.idPrelevementDAO, pDAO.nomPrelevementDAO, pDAO.prenomPrelevementDAO, m);
            return p;
        }

        public static ObservableCollection<PrelevementViewModel> listePrelevements()
        {
            ObservableCollection<PrelevementDAO> lDAO = PrelevementDAO.listePrelevements();
            ObservableCollection<PrelevementViewModel> l = new ObservableCollection<PrelevementViewModel>();
            foreach (PrelevementDAO element in lDAO)
            {
                int idMetier = element.idMetierPrelevementDAO;

                PrelevementViewModel p = new PrelevementViewModel(element.idPrelevementDAO, element.nomPrelevementDAO, element.prenomPrelevementDAO, m);
                l.Add(p);
            }
            return l;
        }


        public static void updatePrelevement(PrelevementViewModel p)
        {
            PrelevementDAO.updatePrelevement(new PrelevementDAO(p.idPrelevementProperty, p.nomPrelevementProperty, p.prenomPrelevementProperty, p.metierPrelevement.idMetier));
        }

        public static void supprimerPrelevement(int id)
        {
            PrelevementDAO.supprimerPrelevement(id);
        }

        public static void insertPrelevement(PrelevementViewModel p)
        {
            PrelevementDAO.insertPrelevement(new PrelevementDAO(p.idPrelevementProperty, p.nomPrelevementProperty, p.prenomPrelevementProperty, p.metierPrelevement.idMetier));
        }
    }*/
}
