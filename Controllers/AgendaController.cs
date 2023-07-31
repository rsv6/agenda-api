
using agenda_api.Models;
using agenda_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace agenda_api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AgendaController : ControllerBase
{
    private static List<Agenda> agendas = new List<Agenda>();

    [HttpPost]
    public async Task<ActionResult<Agenda>> CadastrarAgenda(Agenda agenda)
    {
        AgendaRepository agendaRepository = new AgendaRepository();
        var resultado = await agendaRepository.Adicionar(agenda);
        Console.WriteLine($"Resultado {resultado}");
        return Ok(agenda);
    }

    [HttpGet]
    public async Task<ActionResult<dynamic>> Agenda()
    {
        AgendaRepository agendaRepository = new AgendaRepository();
        return Ok(agendaRepository.BuscarTodasAgendas().Result);
    }
}