using senai_filmes_wwebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_wwebApi.Interfaces
{
    /// <summary>
    ///  Interface responsável pelo repositório FilmeRepository
    /// </summary>
    public interface IFilmeRepository
    {
        // TipoRetorno NomeMetodo(parâmetros);

        /// <summary>
        ///  Retornar todos os gêneros
        /// </summary>
        /// <returns> lista de gêneros </returns>
        List<FIlmeDomain> ListarTodos();

        /// <summary>
        ///  Retorna um filme através do seu id
        /// </summary>
        /// <param name="id">id do filme que será buscado</param>
        /// <returns>Um objeto que o tipo FIlmeDomain que foi buscado</returns>
        FIlmeDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoGenero">objeto que será cadastrado</param>
        void Cadastrar(FIlmeDomain novofilme);

        /// <summary>
        /// Atualiza um filme existente, passando o id pelo corrpo da requisição
        /// </summary>
        /// <param name="genero">Objeto filme com as novas informações</param>
        void AtualizarIdCorpo(FIlmeDomain filme);

        /// <summary>
        /// Atualiza um filme existente, passando o id pela url da requisição
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero">Objeto filme com as novas informações</param>
        void AtualizarIdUrl(int id, FIlmeDomain filme);

        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="id">Id do filme que será deletado</param>
        void Deletar(int id);
    }
}
