using MySql.Data.MySqlClient;
using WpfApp13.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp13.DAL
{
    class VilleDAL
    {
        private static MySqlConnection connection;
        public VilleDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<VilleDAO> selectVilles()
        {
            ObservableCollection<VilleDAO> l = new ObservableCollection<VilleDAO>();
            string query = "SELECT * FROM ville;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VilleDAO p = new VilleDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    l.Add(p);
                }
                reader.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("La base de données n'est pas connectée");
            }
            return l;
        }

        public static void updateVille(VilleDAO p)
        {
            string query = "UPDATE ville set idVille=\"" + p.idVilleDAO + "\", nomSpecialiste=\"" + p.nomSpecialisteDAO + "\", idDepartement=\"" + p.idDepartementDAO +";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertVille(VilleDAO p)
        {
            int id = getMaxIdVille() + 1;
            string query = "INSERT INTO ville VALUES (\"" + id + "\",\"" + p.idVilleDAO + "\",\"" + p.nomSpecialisteDAO + "\",\"" + p.idDepartementDAO +"\"); ";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerVille(int id)
        {
            string query = "DELETE FROM ville WHERE idVille = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdVille()
        {
            string query = "SELECT MAX(idVille) FROM ville;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdVille = reader.GetInt32(0);
            reader.Close();
            return maxIdVille;
        }

        public static VilleDAO getVille(int idVille)
        {
            string query = "SELECT * FROM ville WHERE id=" + idVille + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            VilleDAO vil = new VilleDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            reader.Close();
            return vil;
        }
    }
}
