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
    class EtudeDAL
    {
        private static MySqlConnection connection;
        public EtudeDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<EtudeDAO> selectEtudes()
        {
            ObservableCollection<EtudeDAO> l = new ObservableCollection<EtudeDAO>();
            string query = "SELECT * FROM etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EtudeDAO p = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4));
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

        public static void updateEtude(EtudeDAO p)
        {
            string query = "UPDATE etude set nomEtude=\"" + p.nomEtudeDAO + "\", dateEtude=\"" + p.dateEtudeDAO + "\", nbPersonne=\"" + p.nbPersonneDAO + "\", idPersonne=\"" + p.idPersonneDAO + "\" where idEtude=" + p.idEtudeDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEtude(EtudeDAO p)
        {
            int id = getMaxIdEtude() + 1;
            string query = "INSERT INTO etude VALUES (\"" + id + "\",\"" + p.nomEtudeDAO + "\",\"" + p.dateEtudeDAO.ToString("yyyy-MM-dd") + "\",\"" + p.nbPersonneDAO + "\",\"" + p.idPersonneDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEtude(int id)
        {
            string query = "DELETE FROM etude WHERE idEtude = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdEtude()
        {
            connection = DALConnection.connection;
            string query = "SELECT MAX(idEtude) FROM etude;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdEtude = reader.GetInt32(0);
            reader.Close();
            return maxIdEtude;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            string query = "SELECT * FROM etude WHERE id=" + idEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EtudeDAO etu = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4));
            reader.Close();
            return etu;
        }

    }
}
