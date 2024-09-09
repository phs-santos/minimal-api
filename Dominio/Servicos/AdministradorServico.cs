using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;

        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
        }

        public Administrador? Incluir(Administrador administrador)
        {
            var adm = new Administrador
            {
                Email = administrador.Email,
                Senha = administrador.Senha,
                Perfil = administrador.Perfil.ToString()
            };
            _contexto.Administradores.Add(adm);
            _contexto.SaveChanges();
            return adm;
        }

        public List<Administrador> Todos(int? pagina)
        {
            var query = _contexto.Administradores.AsQueryable();

            int itensPorPagina = 10;
            if (pagina != null)
            {
                query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }

            return query.ToList();
        }

        public Administrador? BuscaPorId(int id)
        {
            return _contexto.Administradores.Find(id);
        }
    }
}