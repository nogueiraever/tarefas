using Microsoft.AspNetCore.Mvc;
using System;
using Tarefas.Aplicacao;
using Tarefas.Dominio;
using Tarefas.Infra.Dtos;

namespace Tarefas.Api.Controllers
{
    [Route("api/v1/tarefas/")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IManterTarefas manterTarefas;

        public TarefasController(IManterTarefas manterTarefas)
        {
            this.manterTarefas = manterTarefas ?? throw new ArgumentNullException(nameof(manterTarefas));
        }

        [HttpPut]
        public ActionResult Alterar([FromBody]TarefaDto tarefaDto)
        {
            try
            {
                manterTarefas.Atualizar(tarefaDto);
                return Ok();
            }
            catch (NegocioException negocioException)
            {
                return new ResultadoBase(negocioException.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao alterar a tarefa");
            }
        }

        [HttpPut("concluir")]
        public ActionResult Concluir([FromQuery]long id)
        {
            try
            {
                manterTarefas.Concluir(id);
                return Ok();
            }
            catch (NegocioException negocioException)
            {
                return new ResultadoBase(negocioException.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao concluir a tarefa");
            }
        }

        [HttpPost]
        public ActionResult Criar([FromBody]TarefaDto tarefaDto)
        {
            try
            {
                manterTarefas.Criar(tarefaDto);
                return Ok();
            }
            catch (NegocioException negocioException)
            {
                return new ResultadoBase(negocioException.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao criar a tarefa");
            }
        }

        [HttpGet]
        public ActionResult Listar()
        {
            try
            {
                return Ok(manterTarefas.Listar());
            }
            catch (NegocioException negocioException)
            {
                return new ResultadoBase(negocioException.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao listar as tarefas");
            }
        }

        [HttpPut("reativar")]
        public ActionResult Reativar([FromQuery]long id)
        {
            try
            {
                manterTarefas.Reativar(id);
                return Ok();
            }
            catch (NegocioException negocioException)
            {
                return new ResultadoBase(negocioException.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao concluir a tarefa");
            }
        }

        [HttpDelete]
        public ActionResult Remover([FromQuery]long id)
        {
            try
            {
                manterTarefas.Remover(id);
                return Ok();
            }
            catch (NegocioException negocioException)
            {
                return new ResultadoBase(negocioException.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao remover a tarefa");
            }
        }
    }
}