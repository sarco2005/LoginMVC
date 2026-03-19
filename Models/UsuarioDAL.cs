using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TuProyecto.Models
{
    public class UsuarioDAL
    {
        private string conexion = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

        public bool ValidarUsuario(string username, string password)
        {
            bool esValido = false;

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"SELECT COUNT(1) 
                                 FROM Usuarios 
                                 WHERE Username = @Username 
                                 AND Password = @Password 
                                 AND Activo = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                esValido = count > 0;
            }

            return esValido;
        }
    }
}