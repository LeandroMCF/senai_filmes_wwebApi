using senai_filmes_wwebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_wwebApi.Interfaces
{
    /// <summary>
    ///  Interface responsável pelo repositório GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        // TipoRetorno NomeMetodo(parâmetros);

        /// <summary>
        ///  Retornar todos os gêneros
        /// </summary>
        /// <returns> lista de gêneros </returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        ///  Retorna um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>Um objeto que o tipo GeneroDomain que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um genero existente, passando o id pelo corrpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um gênero existente, passando o id pela url da requisição
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero">Objeto genero com as novas informações</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um genreno
        /// </summary>
        /// <param name="id">Id do genero que será deletado</param>
        void Deletar(int id);
    }
}
