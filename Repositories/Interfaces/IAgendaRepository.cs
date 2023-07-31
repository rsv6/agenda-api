
using agenda_api.Models;

namespace agenda_api.Repositories.Interfaces;

public interface IAgendaRepository
{
    Task<List<Agenda>> BuscarTodasAgendas();    
    Task<Agenda> BuscarPorId(int id);
    Task<Agenda> Adicionar(Agenda agenda);
    Task<Agenda> Atualizar(Agenda agenda, int id);
    Task<Agenda> Cancelar(int id);

}