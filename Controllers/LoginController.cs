using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agenda_api.Models;
using agenda_api.Repositories;
using agenda_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace agenda_api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class LoginController : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult<dynamic>> Authenticate([FromBody] UsuarioLogin usuarioLogin)
    {
        Usuario usuario = new();
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        var getUsuario = await usuarioRepository.Recupera(usuarioLogin);

        if (getUsuario == null || getUsuario.Login == null)
        {
            return NotFound(new { message = "Usuário ou senha inválidos" });
        }

        usuario.Login = getUsuario.Login;
        usuario.Nivel = getUsuario.Nivel;

        var token = TokenService.GenerateToken(usuario);

        // return Ok(getUsuario);
        return new 
        {
            usuario,
            token
        };
    }
}
