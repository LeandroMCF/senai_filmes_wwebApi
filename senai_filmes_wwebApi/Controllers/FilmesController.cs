using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_wwebApi.Domains;
using senai_filmes_wwebApi.Interfaces;
using senai_filmes_wwebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_wwebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmesRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista parra receber os dados
            List<FIlmeDomain> listaFilmes = _filmeRepository.ListarTodos();

            //Retorna o status code 200 (ok) com a lista de gênero no formato JSON
            return Ok(listaFilmes);
        }

        [HttpPost]
        public IActionResult Post(FIlmeDomain novoFilme)
        {
            _filmeRepository.Cadastrar(novoFilme);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _filmeRepository.Deletar(id);

            return StatusCode(200);
        }
    }
}
