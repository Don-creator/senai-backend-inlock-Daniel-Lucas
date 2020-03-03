using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;


namespace Senai.InLock.WebApi.Controllers
{
    
        [Produces("application/json")]

        [Route("api/[controller]")]

        [ApiController]

        [Authorize(Roles = "1")]
        public class TipoUsuarioController : ControllerBase
        {
        
            private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

  
            public TipoUsuarioController()
            {
                _tipoUsuarioRepository = new TipoUsuarioRepository();
            }
        
            [HttpGet]
            public IActionResult Get()
            {
                
                return Ok(_tipoUsuarioRepository.Listar());
            }

           
            [HttpPost]
            public IActionResult Post(TipoUsuarioDomain novoTipoUsuario)
            {
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

                return Created("http://localhost:5000/api/Usuario", novoTipoUsuario);
            }


            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioBuscado != null)
                {
                    return Ok(tipoUsuarioBuscado);
                }

                return NotFound("Nenhum tipo de usuário encontrado para o identificador informado");
            }

  
            [HttpPut("{id}")]
            public IActionResult Put(int id, TipoUsuarioDomain tipoUsuarioAtualizado)
            {
                TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioBuscado != null)
                {
                    try
                    {
                        _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

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
                            mensagem = "Tipo de usuário não encontrado",
                            erro = true
                        }
                    );
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioBuscado != null)
                {
                    _tipoUsuarioRepository.Deletar(id);

                    return Ok($"O tipo de usuário {id} foi deletado com sucesso!");
                }

                return NotFound("Nenhum tipo de usuário encontrado para o identificador informado");
            }
        }
    }

