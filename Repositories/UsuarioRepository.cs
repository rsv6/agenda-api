using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agenda_api.Connections;
using agenda_api.Models;
using Microsoft.Data.SqlClient;
using agenda_api.Repositories.Interfaces;

namespace agenda_api.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    private static string ConnectionString = new ConexaoHome().ConnexaoString;
    public async Task<Usuario> Recupera(UsuarioLogin usuarioLogin)
    {
        try
        {
            Usuario usuario = new();
            string Login = usuarioLogin.Login;
            string Senha = usuarioLogin.Senha;
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    if (Login.ToString() != "" && Senha.ToString() != "")
                    {
                        command.CommandText = "SELECT * FROM USUARIO WHERE login = '"+ Login + "' AND  senha = '" + Senha +"'";
                        // command.Parameters.AddWithValue("@login", Login);
                        // command.Parameters.AddWithValue("@senha", Login);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Usuario resultado = new()
                            {
                                Id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"] == DBNull.Value ? string.Empty : reader["nome"].ToString(),
                                Login = reader["login"] == DBNull.Value ? string.Empty : reader["login"].ToString(),
                                Nivel = reader["nivel"] == DBNull.Value ? 0 : Convert.ToInt32(reader["nivel"])
                            };
                            usuario = resultado;
                        }
                    }
                }
                connection.Close();
            }
            return usuario;
        }
        catch (System.Exception)
        {
            Console.WriteLine("Erro ao buscar login e senha no banco de dados!");
            return null;
        }

    }
}
