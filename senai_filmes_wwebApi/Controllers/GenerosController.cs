﻿using Microsoft.AspNetCore.Http;
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
        private IGeneroRepository _generoRepository { get; set;  }

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
        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista parra receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            //Retorna o status code 200 (ok) com a lista de gênero no formato JSON
            return Ok(listaGeneros);
        }
    }
}