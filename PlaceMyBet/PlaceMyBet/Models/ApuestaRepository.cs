using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class ApuestaRepository
    {

        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=LORENA;password=LORENA2001;SslMode=none";
            MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal Apuesta Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = " Select * from Apuesta";

            try
            {

                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta a = null;
                if (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetBoolean(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
                    a = new Apuesta(res.GetInt32(0), res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetString(4), res.GetInt32(5), res.GetInt32(6));
                }

                return a;
            }
            catch (MySqlException a)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }
    }
}