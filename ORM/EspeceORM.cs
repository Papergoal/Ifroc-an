﻿using WpfApp13.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp13.Ctrl;

namespace WpfApp13.ORM
{
    class EspeceORM
    {
        public static EspeceViewModel getEspece(int idEspece)
        {
            EspeceDAO pDAO = EspeceDAO.getEspece(idEspece);
            EspeceViewModel p = new EspeceViewModel(pDAO.idEspeceDAO, pDAO.nomEspeceDAO);
            return p;
        }

        public static ObservableCollection<EspeceViewModel> listeEspeces()
        {
            ObservableCollection<EspeceDAO> lDAO = EspeceDAO.listeEspeces();
            ObservableCollection<EspeceViewModel> l = new ObservableCollection<EspeceViewModel>();
            foreach (EspeceDAO element in lDAO)
            {

                EspeceViewModel p = new EspeceViewModel(element.idEspeceDAO, element.nomEspeceDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateEspece(EspeceViewModel p)
        {
            EspeceDAO.updateEspece(new EspeceDAO(p.idEspeceProperty, p.nomEspeceProperty));
        }

        public static void supprimerEspece(int id)
        {
            EspeceDAO.supprimerEspece(id);
        }

        public static void insertEspece(EspeceViewModel p)
        {
            EspeceDAO.insertEspece(new EspeceDAO(p.idEspeceProperty, p.nomEspeceProperty));
        }
    }
}
