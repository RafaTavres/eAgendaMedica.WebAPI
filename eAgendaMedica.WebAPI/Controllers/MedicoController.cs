using AutoMapper;
using eAgenda.WebApi.Controllers.Shared;
using eAgendaMedica.Aplicacao.ModuloMedico;
using eAgendaMedica.Dominio.ModuloAtividade;
using eAgendaMedica.Dominio.ModuloMedico;
using eAgendaMedica.WebAPI.ViewModels.ModuloAtividade;
using eAgendaMedica.WebAPI.ViewModels.ModuloMedico;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebAPI.Controllers
{
    [ApiController]
    [Route("api/medicos")]
    public class MedicoController : ApiControllerBase
    {

        private readonly ServicoMedico servicoMedico;
        private readonly IMapper mapeador;

        public MedicoController(ServicoMedico servicoMedico, IMapper mapeadorCategorias)
        {
            this.servicoMedico = servicoMedico;
            this.mapeador = mapeadorCategorias;
        }

        [HttpGet]

        [ProducesResponseType(typeof(List<ListarMedicoViewModel>), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SeleciontarTodos()
        {
            var medicoResult = await servicoMedico.SelecionarTodos();

            var viewModel = mapeador.Map<List<ListarMedicoViewModel>>(medicoResult.Value);

            return Ok(viewModel);
        }


        [HttpPost]

        [ProducesResponseType(typeof(FormMedicoViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> InserirMedico(FormMedicoViewModel medicoViewModel)
        {

            var medico = mapeador.Map<Medico>(medicoViewModel);

            var result = await servicoMedico.Inserir(medico);

            return ProcessarResultado(result.ToResult(), medicoViewModel);
        }

        [HttpPut("{id}")]

        [ProducesResponseType(typeof(FormMedicoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> EditarMedico(Guid id, FormMedicoViewModel medicoViewModel)
        {

            var result = await servicoMedico.SelecionarPorId(id);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(x => x.Message));
            }


            var medicoAlterado = mapeador.Map(medicoViewModel, result.Value);

            var medicoResult = await servicoMedico.Editar(medicoAlterado);

            return ProcessarResultado(medicoResult.ToResult(), medicoViewModel);
        }

        [HttpPut("adicionar-uma-atividade/{id}")]

        [ProducesResponseType(typeof(FormMedicoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> AdicionarAtividadeAoMedico(Guid id,FormAtividadeViewModel formAtividade)
        {

            var result = await servicoMedico.SelecionarPorId(id);

            if (result.IsFailed)
            {
                return NotFound(result.Errors.Select(x => x.Message));
            }

            var medicoAlterado =  result.Value;

            var atividade = new Atividade();
            atividade.DataRealizacao = formAtividade.DataRealizacao;
            atividade.HoraInicio = TimeSpan.Parse(formAtividade.HoraInicio);
            atividade.HoraTermino = TimeSpan.Parse(formAtividade.HoraTermino);
            medicoAlterado.AdicionarAtividade(atividade);

            var medicoResult = await servicoMedico.Editar(medicoAlterado);

            return ProcessarResultado(medicoResult.ToResult());
        }
    }
}