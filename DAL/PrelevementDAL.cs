using MySql.Data.MySqlClient;
using WpfApp13.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp13.DAO;

namespace WpfApp13.DAL
{
    /*class PrelevementDAL
    {
        private static MySqlConnection connection;
        public PrelevementDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<PrelevementDAO> selectPrelevements()
        {
            ObservableCollection<PrelevementDAO> l = new ObservableCollection<PrelevementDAO>();
            string query = "SELECT * FROM Prelevement;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PrelevementDAO p = new PrelevementDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                    l.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("La base de données n'est pas connectée");
            }
            return l;
        }

        public static void updatePrelevement(PrelevementDAO p)
        {
            string query = "UPDATE Prelevement set nomPrelevement=\"" + p.nomPrelevementDAO + "\", prenomPrelevement=\"" + p.prenomPrelevementDAO + "\", idMetier=\"" + p.idMetierPrelevementDAO + "\" where idPrelevement=" + p.idPrelevementDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPrelevement(PrelevementDAO p)
        {
            int id = getMaxIdPrelevement() + 1;
            string query = "INSERT INTO Prelevement VALUES (\"" + id + "\",\"" + p.nomPrelevementDAO + "\",\"" + p.prenomPrelevementDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPrelevement(int id)
        {
            string query = "DELETE FROM Prelevement WHERE idPrelevement = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPrelevement()
        {
            string query = "SELECT MAX(idPrelevement) FROM Prelevement;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdPrelevement = reader.GetInt32(0);
            reader.Close();
            return maxIdPrelevement;
        }

        public static PrelevementDAO getPrelevement(int idPrelevement)
        {
            string query = "SELECT * FROM Prelevement WHERE id=" + idPrelevement + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PrelevementDAO prel = new PrelevementDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            reader.Close();
            return prel;
        }
    }*/
}
