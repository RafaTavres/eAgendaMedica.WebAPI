using AutoMapper;
using eAgenda.WebApi.Controllers.Shared;
using eAgendaMedica.Aplicacao.ModuloAtividade;
using eAgendaMedica.Aplicacao.ModuloAtividade;
using eAgendaMedica.Aplicacao.ModuloMedico;
using eAgendaMedica.WebAPI.ViewModels.ModuloAtividade;
using eAgendaMedica.WebAPI.ViewModels.ModuloMedico;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebAPI.Controllers
{

    [ApiController]
    [Route("api/atividades")]
    public class AtividadeController : ApiControllerBase
    {
        private readonly ServicoAtividade servicoAtividade;
        private readonly IMapper mapeador;

        public AtividadeController(ServicoAtividade servicoAtividade, IMapper mapeadorCategorias)
        {
            this.servicoAtividade = servicoAtividade;
            this.mapeador = mapeadorCategorias;
        }

        [HttpGet]

        [ProducesResponseType(typeof(List<ListarAtividadeViewModel>), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SeleciontarTodos()
        {
            var medicoResult = await servicoAtividade.SelecionarTodos();

            var viewModel = mapeador.Map<List<ListarAtividadeViewModel>>(medicoResult.Value);

            return Ok(viewModel);
        }
    }
}
