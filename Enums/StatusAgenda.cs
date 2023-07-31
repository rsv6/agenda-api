using System.ComponentModel;

namespace agenda_api.Enums;
public enum StatusAgenda
{
    [Description("Está livre")]
    Livre = 0,
    [Description("Está Ocupado")]
    Ocupado = 1,
    [Description("Aguardando confirmação")]
    AguardandoConfirmacao = 2,
    [Description("Foi Cancelado")]
    Cancelado = 9
}
