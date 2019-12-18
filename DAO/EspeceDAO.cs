using WpfApp13.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp13.DAO
{
    class EspeceDAO
    {
        public int idEspeceDAO;
        public string nomEspeceDAO;


        public EspeceDAO(int idEspeceDAO, string nomEspeceDAO)
        {
            this.idEspeceDAO = idEspeceDAO;
            this.nomEspeceDAO = nomEspeceDAO;
        }

        public static ObservableCollection<EspeceDAO> listeEspeces()
        {
            ObservableCollection<EspeceDAO> l = EspeceDAL.selectEspeces();
            return l;
        }

        public static EspeceDAO getEspece(int idEspece)
        {
            EspeceDAO e = EspeceDAL.getEspece(idEspece);
            return e;
        }

        public static void updateEspece(EspeceDAO p)
        {
            EspeceDAL.updateEspece(p);
        }

        public static void supprimerEspece(int id)
        {
            EspeceDAL.supprimerEspece(id);
        }

        public static void insertEspece(EspeceDAO p)
        {
            EspeceDAL.insertEspece(p);
        }
    }
}
