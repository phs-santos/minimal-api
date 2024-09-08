using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Dominio.Interfaces
{
    public interface IAdmnistradorServico
    {
        Administrador? Login(LoginDTO loginDTO);
    }
}