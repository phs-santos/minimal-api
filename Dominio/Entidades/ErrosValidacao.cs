using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.ModelViews;

namespace MinimalApi.Dominio.Entidades
{
    public class ErrosValidacao
    {
        public ErrosDeValidacao ErrosVeiculos(VeiculoDTO veiculoDTO)
        {
            var validacao = new ErrosDeValidacao
            {
                Mensagens = new List<string>()
            };

            if (string.IsNullOrEmpty(veiculoDTO.Nome))
                validacao.Mensagens.Add("O nome não pode ser vazio");

            if (string.IsNullOrEmpty(veiculoDTO.Marca))
                validacao.Mensagens.Add("A marca não pode ficar em branco");

            if (veiculoDTO.Ano < 1900)
                validacao.Mensagens.Add("Veículos não podem ser mais antigos que 1900");

            return validacao;
        }

        public ErrosDeValidacao ErrosAdministradores(AdministradorDTO administradorDTO)
        {
            var validacao = new ErrosDeValidacao
            {
                Mensagens = new List<string>()
            };

            if (string.IsNullOrEmpty(administradorDTO.Email))
                validacao.Mensagens.Add("O email não pode ser vazio");

            if (string.IsNullOrEmpty(administradorDTO.Senha))
                validacao.Mensagens.Add("A senha não pode ser vazia");

            if (administradorDTO.Perfil.ToString() == null)
                validacao.Mensagens.Add("O perfil não pode ser vazio");

            return validacao;
        }

    }
}