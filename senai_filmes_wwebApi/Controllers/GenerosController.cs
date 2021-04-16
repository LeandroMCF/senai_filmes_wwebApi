using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_wwebApi.Domains;
using senai_filmes_wwebApi.Interfaces;
using senai_filmes_wwebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller respnsável pelas URLs referentes aos gêneros
/// </summary>
namespace senai_filmes_wwebApi.Controllers
{
    //Define o tipo de resposta da API
    [Produces("application/json")]

    //Define a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]
    //Define que é um controlador de API
    [ApiController]

    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irrá receber todos os metodos definidos na interface IGnerosRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// instancia o objeto para que haja referencia aos métodos no repositótio
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Listar todos os generos
        /// </summary>
        /// <returns>Uma lista com todos os generos</returns>
        
        [Authorize]

        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista parra receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            //Retorna o status code 200 (ok) com a lista de gênero no formato JSON
            return Ok(listaGeneros);
        }

        [Authorize(Roles = "Administrador")]

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscando = _generoRepository.BuscarPorId(id);

            if (generoBuscando == null)
            {
                return NotFound("Nenhum genero foi encontrado");
            }

            return Ok(generoBuscando);
        }

        /// <summary>
        /// cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">objeto que recebeo novo genero</param>
        /// <returns>cone 201</returns>
        
        [Authorize(Roles = "Administrador")] 

        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            _generoRepository.Cadastrar(novoGenero);

            return StatusCode(201);
        }

        [Authorize(Roles = "Administrador")]

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _generoRepository.Deletar(id);

            return StatusCode(200);
        }

        [Authorize(Roles = "Administrador")]

        [HttpPut("{id}")]
        public IActionResult PutId(int id, GeneroDomain genero)
        {
            _generoRepository.AtualizarIdUrl(id, genero);

            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtt)
        {
            GeneroDomain generoBuscando = _generoRepository.BuscarPorId(generoAtt.IdGenero);

            if (generoBuscando != null)
            {
                try
                {
                    _generoRepository.AtualizarIdCorpo(generoAtt);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound
                (
                    new
                    {
                        erro = true,
                        mensagen = "Gênero não encontrado!"
                    }
                );
        }
    }
}
