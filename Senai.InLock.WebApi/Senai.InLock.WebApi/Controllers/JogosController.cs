using System;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    [ApiController]
    public class JogosController : ControllerBase
    {

        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_jogosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(JogosDomain novoJogo)
        {

            _jogosRepository.Cadastrar(novoJogo);

            return Created("http://localhost:5000/api/Jogos", novoJogo);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogosDomain jogoBuscado = _jogosRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                return Ok(jogoBuscado);
            }

            return NotFound("Nenhum jogo encontrado para o identificador informado");
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, JogosDomain jogoAtualizado)
        {
            JogosDomain jogoBuscado = _jogosRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                try
                {
                    _jogosRepository.Atualizar(id, jogoAtualizado);

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
                        mensagem = "Jogo não encontrado",
                        erro = true
                    }
                );
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            JogosDomain jogoBuscado = _jogosRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                _jogosRepository.Deletar(id);

                return Ok($"O jogo {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum jogo encontrado para o identificador informado");
        }
        
        [HttpGet("pesquisar/{busca}")]
        public IActionResult GetByTitle(string busca)
        {
            return Ok(_jogosRepository.BuscarPorTitulo(busca));
        }
    }
}