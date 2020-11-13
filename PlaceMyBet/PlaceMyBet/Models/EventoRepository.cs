using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class EventoRepository
    {

        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<Evento> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select * from evento";

            try
            {

                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Evento e = null;
                List<Evento> eventos = new List<Evento>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3));
                    e = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3));
                    eventos.Add(e);
                }
                con.Close();
                return eventos;
            }
            catch (MySqlException c)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }

        internal List<EventoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "Select * from evento";

            try
            {

                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                EventoDTO e = null;
                List<EventoDTO> eventos = new List<EventoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3));
                    e = new EventoDTO(res.GetString(1), res.GetString(2), res.GetString(3));
                    eventos.Add(e);
                }
                con.Close();
                return eventos;
            }
            catch (MySqlException c)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }

        // Ejercicio 1 examen 
        internal List<EventoExamen> RetrieveEventoExamen(int idEvento)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            command.CommandText = "SELECT e.equipoLocal, e.equipoVisitante, m.tipoMercado FROM evento AS e INNER JOIN mercado AS m ON m.idEvento=e.idEvento INNER JOIN apuesta AS a ON a.idMercado=m.idEvento WHERE a.dineroApostado>10;";
            command.Parameters.AddWithValue("@idEvento", idEvento);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                EventoExamen e = null;
                List<EventoExamen> eventos = new List<EventoExamen>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetDouble(2));
                    e = new EventoExamen(res.GetString(0), res.GetString(1), res.GetDouble(2));
                    eventos.Add(e);
                }

                con.Close();
                return eventos;

            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }


        }
        }

}