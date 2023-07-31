
using agenda_api.Connections;
using agenda_api.Models;
using agenda_api.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace agenda_api.Repositories;

public class AgendaRepository : IAgendaRepository
{
    private static string ConnexaoString = new ConexaoHome().ConnexaoString;
    public async Task<Agenda>Adicionar(Agenda agenda)
    {

        try
        {
            Agenda novaAgenda = new();
            // dynamic? resultado;

            string sala = agenda.Sala;
            string horarioInicial = agenda.HorarioInicial;
            string horarioFinal = agenda.HorarioFinal;
            Enums.StatusAgenda status = agenda.Status;


            using (SqlConnection connection = new SqlConnection(ConnexaoString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "INSERT INTO Agenda (sala, horarioInicial, horarioFinal, status) VALUES (@sala, @horarioInicial, @horarioFinal, @status)",
                    connection
                ))
                {

                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@sala", sala);
                    command.Parameters.AddWithValue("@horarioInicial", horarioInicial);
                    command.Parameters.AddWithValue("@horarioFinal", horarioFinal);
                    command.Parameters.AddWithValue("@status", status);

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Rows affected: {rowsAffected}");

                    // command.CommandTimeout = 60;
                    // command.Connection = connection;
                    // command.CommandText = $"INSERT INTO Agenda (sala, horarioInicial, horarioFinal, status) VALUES ('" + agenda.Sala + "', '" + agenda.HorarioInicial + "', '" +agenda.HorarioFinal + "', '" + agenda.Status + "')";
                    // command.ExecuteNonQuery();


                    // command.CommandText = "SELECT TOP(1) ID FROM Agenda ORDER BY id DESC";
                    // SqlDataReader reader = command.Execute

                    // while (reader.Read())
                    // {
                    //     resultado = reader;
                    //     Console.WriteLine(resultado);
                    // }
                }
                connection.Close();
            }

            return novaAgenda;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    public Task<Agenda> Atualizar(Agenda agenda, int id)
    {
        throw new NotImplementedException();
    }

    public Task<Agenda> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Agenda>> BuscarTodasAgendas()
    {
        List<Agenda> novaAgenda = new();

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnexaoString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Agenda";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Agenda resultado = new()
                        {
                            Id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]),
                            Sala = reader["sala"] == DBNull.Value ? string.Empty : reader["sala"].ToString(),
                            HorarioInicial = reader["horarioInicial"] == DBNull.Value ? "00h00" : reader["horarioInicial"].ToString(),
                            HorarioFinal = reader["horarioFinal"] == DBNull.Value ? "00h00" : reader["horarioFinal"].ToString(),
                            Status = (Enums.StatusAgenda)(reader["status"] == DBNull.Value ? 0 : Convert.ToInt32(reader["status"]))
                        };

                        novaAgenda.Add(resultado);
                    }
                    
                }

                connection.Close();
            }

            return novaAgenda;
        }
        catch (System.Exception ex)
        {
            return null;
        }
    }

    public Task<Agenda> Cancelar(int id)
    {
        throw new NotImplementedException();
    }
}
