using AutoMapper;
using eAgendaMedica.Aplicacao.ModuloMedico;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicoController : ControllerBase
    {

        private readonly ServicoMedico servicoMedico;
        private readonly IMapper mapeador;

        public MedicoController(ServicoMedico servicoMedico, IMapper mapeadorCategorias)
        {
            this.servicoMedico = servicoMedico;
            this.mapeador = mapeadorCategorias;
        }

        [HttpGet]
        public async Task<IActionResult> SeleciontarTodos()
        {
            //var categoriaResult = servicoMedico.SelecionarTodos();

            //var viewModel = mapeador.Map<List<ListarCategoriaViewModel>>(categoriaResult.Value);

            //return Ok(viewModel);
        }
    }
}