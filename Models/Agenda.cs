using agenda_api.Enums;

namespace agenda_api.Models;

public class Agenda
{
    public int Id { get; set; }
    public string? Sala { get; set; }
    public string? HorarioInicial { get; set; }
    public string? HorarioFinal { get; set; }
    public StatusAgenda Status { get; set; }
}
