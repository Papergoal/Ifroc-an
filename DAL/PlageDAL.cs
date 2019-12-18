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
    class PlageDAL
    {
        private static MySqlConnection connection;
        public PlageDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<PlageDAO> selectPlages()
        {
            ObservableCollection<PlageDAO> l = new ObservableCollection<PlageDAO>();
            string query = "SELECT * FROM plage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PlageDAO p = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
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

        public static void updatePlage(PlageDAO p)
        {
            string query = "UPDATE plage set nom=\"" + p.nomPlageDAO + "\", superficie=\"" + p.superficiePlageDAO + "\", Ville_idVille=\"" + p.idVilleDAO + "\" where idPlage=" + p.idPlageDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPlage(PlageDAO p)
        {
            int id = getMaxIdPlage() + 1;
            string query = "INSERT INTO plage VALUES (\"" + id + "\",\"" + p.nomPlageDAO + "\",\"" + p.superficiePlageDAO + "\",\"" + p.idVilleDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPlage(int id)
        {
            string query = "DELETE FROM plage WHERE idPlage = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPlage()
        {
            string query = "SELECT MAX(idPlage) FROM plage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdPlage = reader.GetInt32(0);
            reader.Close();
            return maxIdPlage;
        }

        public static PlageDAO getPlage(int idPlage)
        {
            string query = "SELECT * FROM plage WHERE id=" + idPlage + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PlageDAO plag = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            reader.Close();
            return plag;
        }
    }
}
