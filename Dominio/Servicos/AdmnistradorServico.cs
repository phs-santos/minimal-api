using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos
{
    public class AdmnistradorServico : IAdmnistradorServico
    {
        private readonly DbContexto _contexto;

        public AdmnistradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
        }
    }
}