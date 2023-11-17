using AutoMapper;
using eAgenda.WebApi.Controllers.Shared;
using eAgendaMedica.Aplicacao.ModuloAtividade;
using eAgendaMedica.Aplicacao.ModuloAtividade;
using eAgendaMedica.Aplicacao.ModuloMedico;
using eAgendaMedica.Dominio.ModuloAtividade;
using eAgendaMedica.Dominio.ModuloMedico;
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


        [HttpGet("visualicao-completa/{id}")]

        [ProducesResponseType(typeof(VisualizarAtividadeViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]

        public async Task<IActionResult> SelecionarPorId(Guid id)
        {

            var result = await servicoAtividade.SelecionarPorId(id);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(x => x.Message));
            }

            return Ok(mapeador.Map<VisualizarAtividadeViewModel>(result.Value));


        }






        [HttpPost]

        [ProducesResponseType(typeof(InserirAtividadeViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> InserirAtividade(InserirAtividadeViewModel inserirViewModel)
        {

            var atividade = mapeador.Map<Atividade>(inserirViewModel);

            var result = await servicoAtividade.Inserir(atividade);

            return ProcessarResultado(result.ToResult(), inserirViewModel);
        }



    }
}
