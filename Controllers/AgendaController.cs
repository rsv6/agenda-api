
using agenda_api.Models;
using agenda_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        if (resultado == null) {
            return Ok("Horário já está ocupado!");
        }
        return Ok(agenda);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<dynamic>> Agenda()
    {
        AgendaRepository agendaRepository = new AgendaRepository();
        return Ok(agendaRepository.BuscarTodasAgendas().Result);
    }
}