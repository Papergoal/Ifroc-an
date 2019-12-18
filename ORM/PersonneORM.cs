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
    class PersonneORM
    {
        public static PersonneViewModel getPersonne(int idPersonne)
        {
            PersonneDAO pDAO = PersonneDAO.getPersonne(idPersonne);
            PersonneViewModel p = new PersonneViewModel(pDAO.idPersonneDAO, pDAO.nomPersonneDAO, pDAO.prenomPersonneDAO);
            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonnes()
        {
            ObservableCollection<PersonneDAO> lDAO = PersonneDAO.listePersonnes();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (PersonneDAO element in lDAO)
            {

                PersonneViewModel p = new PersonneViewModel(element.idPersonneDAO, element.nomPersonneDAO, element.prenomPersonneDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updatePersonne(PersonneViewModel p)
        {
            PersonneDAO.updatePersonne(new PersonneDAO(p.idPersonneProperty, p.nomPersonneProperty, p.prenomPersonneProperty));
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAO.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneViewModel p)
        {
            PersonneDAO.insertPersonne(new PersonneDAO(p.idPersonneProperty, p.nomPersonneProperty, p.prenomPersonneProperty));
        }
    }
}
