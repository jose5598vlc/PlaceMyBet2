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
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<Apuesta> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = " Select * from Apuesta";

            try
            {

                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta a = null;
                List<Apuesta> apuesta = new List<Apuesta>();

              while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetBoolean(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetString(6));
                    a = new Apuesta(res.GetInt32(0), res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetString(4), res.GetInt32(5), res.GetString(6));
                    apuesta.Add(a);
                }
                con.Close();
                return apuesta;
            }
            catch (MySqlException c)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = " Select * from Apuesta";

            try
            {

                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuesta = new List<ApuestaDTO>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetBoolean(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetString(6));
                    a = new ApuestaDTO(res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetString(4), res.GetInt32(5), res.GetString(6));
                    apuesta.Add(a);
                }
                con.Close();
                return apuesta;
            }
            catch (MySqlException c)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }

        internal void Save(Apuesta a, Mercado m, Usuario u)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = " INSERT INTO Mercado.tipoMercado, Apuesta.tipoApuesta, Apuesta.dineroApostado, Usuario.idUsuario FROM Mercado INNER JOIN Apuesta ON Mercado.idMercado = Apuesta.idMercado INNER JOIN Usuario ON Usuario.Email = Apuesta.Email VALUES (' " + m.tipoMercado + " , " + a.tipoApuesta + " , " + a.dineroApostado + " , " + u.idUsuario + " '); ";
            Debug.WriteLine("comando" + command.CommandText);
            
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException c)
            {
                Debug.WriteLine("Error en la conexión");
            }
        }

        /* 
         * double probabilidadOver = dineroTotalOver / dineroTotalOver + dineroTotalUnder;

            double probabilidadUnder = dineroTotalUnder / dineroTotalOver + dineroTotalUnder;


         

            double cuotaOver = 1 / probabilidadOver * 0.95;

            double cuotaUnder = 1 / probabilidadUnder * 0.95;
         * 
         * */
    }
}