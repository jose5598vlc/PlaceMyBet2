using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class MercadoRepository
    {

        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<Mercado> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = " Select * from Mercado";

            try
            {

                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
                List<Mercado> mercados = new List<Mercado>();
                while(res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));
                    m = new Mercado(res.GetInt32(0),res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(3), res.GetDouble(4), res.GetInt32(5));
                    mercados.Add(m);
                }
                con.Close();
                return mercados;
            }
            catch (MySqlException c)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }

        internal List<MercadoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = " Select * from Mercado";

            try
            {

                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoDTO m = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));
                    m = new MercadoDTO(res.GetDouble(1), res.GetDouble(2), res.GetDouble(3));
                    mercados.Add(m);
                }
                con.Close();
                return mercados;
            }
            catch (MySqlException c)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }
    }
}