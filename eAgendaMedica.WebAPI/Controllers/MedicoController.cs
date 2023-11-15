using AutoMapper;
using eAgenda.WebApi.Controllers.Shared;
using eAgendaMedica.Aplicacao.ModuloMedico;
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
            var medicoResult = servicoMedico.SelecionarTodos();

            var viewModel = mapeador.Map<List<ListarMedicoViewModel>>(medicoResult.Value);

            return Ok(viewModel);
        }
    }
}