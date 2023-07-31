using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agenda_api.Models;

namespace agenda_api.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Recupera(UsuarioLogin usuarioLogin);
    }
}