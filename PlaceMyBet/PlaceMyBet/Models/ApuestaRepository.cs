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
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=;SslMode=none";
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
                List<Apuesta> apuestas = new List<Apuesta>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetBoolean(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetString(6));
                    a = new Apuesta(res.GetInt32(0), res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetString(4), res.GetInt32(5), res.GetString(6));
                    apuestas.Add(a);
                }
                con.Close();
                return apuestas;
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
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetBoolean(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetString(6));
                    a = new ApuestaDTO(res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetString(4), res.GetInt32(5), res.GetString(6));
                    apuestas.Add(a);
                }
                con.Close();
                return apuestas;
            }
            catch (MySqlException c)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }

        internal void Save(Apuesta a)
        {
            using (MySqlConnection con = Connect())
            {
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "insert into apuesta(idMercado,tipoApuesta,cuota,dineroApostado,Email) values " +
                        "( '" + a.idMercado + "','" + a.tipoApuesta + "', '" + a.cuota + "','" + a.dineroApostado + "','" + a.Email + "');";
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

            double ProbaOver = 0;
            double ProbaUnder = 0;

            double dineroOver = 0;
            double dineroUnder = 0;

            double cuotaOver = 0;
            double cuotaUnder = 0;

            using (MySqlConnection con = Connect())
            {
                MySqlCommand command = con.CreateCommand();
                if (a.tipoApuesta == true)
                {
                    command.CommandText = "UPDATE mercado set dineroapostadoOver=dineroapostadoOver + " + a.dineroApostado + " WHERE idMercado =" + a.idMercado;
                }
                else
                {
                    command.CommandText = "UPDATE mercado set dineroapostadoUnder=dineroapostadoUnder + " + a.dineroApostado + " WHERE idMercado =" + a.idMercado;
                }

                con.Open();
                command.ExecuteNonQuery();
                command.CommandText = "SELECT dineroapostadoOver,dineroapostadoUnder from mercado";
                MySqlDataReader res = command.ExecuteReader();

                if (res.Read())
                {
                    dineroOver= res.GetDouble(0);
                    dineroUnder = res.GetDouble(1);

                    ProbaOver = dineroOver / (dineroOver + dineroUnder);
                    ProbaUnder = dineroUnder / (dineroOver + dineroUnder);
                }
                con.Close();
                cuotaOver = (1 / ProbaOver) * 0.95;
                cuotaUnder = (1 / ProbaUnder) * 0.95;

                if (dineroOver == 0 && a.tipoApuesta == true)
                {
                    cuotaOver = 0;
                }
                else if (dineroUnder == 0 && a.tipoApuesta == false)
                {
                    cuotaUnder = 0;
                }
            }
            using (MySqlConnection con = Connect())
            {
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "UPDATE mercado set infocuotaOver='" + cuotaOver + "', infocuotaUnder='" + cuotaUnder + "' WHERE idMercado =" + a.idMercado;
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }

        }

        internal List<ApuestaUsuario> RetrieveEmail(string Email)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT a.tipoApuesta, a.cuota, a.dineroApostado, e.idEvento from apuesta as a INNER JOIN mercado as m ON a.idMercado=m.idMercado INNER JOIN evento as e ON m.idMercado=e.idEvento WHERE a.email=@email;";
            command.Parameters.AddWithValue("@email", Email);
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaUsuario a = null;
                List<ApuestaUsuario> apuestas = new List<ApuestaUsuario>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetBoolean(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetInt32(3));
                    a = new ApuestaUsuario(res.GetBoolean(0), res.GetDouble(1), res.GetDouble(2), res.GetInt32(3));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
        }

        internal List<ApuestaMercado> RetrieveApuestaMercado(double tipoMercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT m.tipoMercado, a.tipoApuesta, a.cuota, a.dineroApostado, a.email from apuesta as a INNER JOIN mercado as m INNER JOIN usuario as u WHERE m.tipoMercado=@tipoMercado;";
            command.Parameters.AddWithValue("@tipoMercado", tipoMercado);
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaMercado a = null;
                List<ApuestaMercado> apuestas = new List<ApuestaMercado>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetDouble(0) + " " + res.GetBoolean(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetString(4));
                    a = new ApuestaMercado(res.GetDouble(0), res.GetBoolean(1), res.GetDouble(2), res.GetDouble(3), res.GetString(4));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
        }




    }


}