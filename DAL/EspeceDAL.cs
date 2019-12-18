﻿using MySql.Data.MySqlClient;
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
    class EspeceDAL
    {
        private static MySqlConnection connection;
        public EspeceDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<EspeceDAO> selectEspeces()
        {
            ObservableCollection<EspeceDAO> l = new ObservableCollection<EspeceDAO>();
            string query = "SELECT * FROM espece;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EspeceDAO p = new EspeceDAO(reader.GetInt32(0), reader.GetString(1));
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

        public static void updateEspece(EspeceDAO p)
        {
            string query = "UPDATE espece set nomEspece=\"" + p.nomEspeceDAO;
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEspece(EspeceDAO p)
        {
            int id = getMaxIdEspece() + 1;
            string query = "INSERT INTO espece VALUES (\"" + id + "\",\"" + p.nomEspeceDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEspece(int id)
        {
            string query = "DELETE FROM espece WHERE idEspece = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdEspece()
        {
            string query = "SELECT MAX(idEspece) FROM espece;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdEspece = reader.GetInt32(0);
            reader.Close();
            return maxIdEspece;
        }

        public static EspeceDAO getEspece(int idEspece)
        {
            string query = "SELECT * FROM espece WHERE id=" + idEspece + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EspeceDAO esp = new EspeceDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return esp;
        }
    }
}
