using eAgenda.Dominio.ModuloAtividade;
using eAgendaMedica.Dominio;
using eAgendaMedica.Dominio.ModuloMedico;
using FluentResults;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaMedica.Aplicacao.ModuloMedico
{
    public class ServicoMedico : ServicoBase<Medico, ValidadorMedico>
    {
        private IRepositorioMedico repositorioMedico;
        private IContextoPersistencia contextoPersistencia;

        public ServicoMedico(IRepositorioMedico repositorioMedico,
                             IContextoPersistencia contextoPersistencia)
        {
            this.repositorioMedico = repositorioMedico;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Medico> Inserir(Medico Medico)
        {
            Log.Logger.Debug("Tentando inserir Medico... {@c}", Medico);

            Result resultado = Validar(Medico);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {

                repositorioMedico.Inserir(Medico);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Medico {MedicoId} inserido com sucesso", Medico.Id);

                return Result.Ok(Medico);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar inserir o Medico";

                Log.Logger.Error(ex, msgErro + " {MedicoId} ", Medico.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Medico> Editar(Medico Medico)
        {
            Log.Logger.Debug("Tentando editar Medico... {@c}", Medico);

            var resultado = Validar(Medico);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {

                repositorioMedico.Editar(Medico);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Medico {MedicoId} editado com sucesso", Medico.Id);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar editar o Medico";

                Log.Logger.Error(ex, msgErro + " {MedicoId}", Medico.Id);

                return Result.Fail(msgErro);
            }

            return Result.Ok(Medico);
        }

        public Result Excluir(Medico Medico)
        {
            Log.Logger.Debug("Tentando excluir Medico... {@c}", Medico);

            try
            {
                repositorioMedico.Excluir(Medico);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Medico {MedicoId} editado com sucesso", Medico.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir o Medico";

                Log.Logger.Error(ex, msgErro + " {MedicoId}", Medico.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Guid id)
        {
            var MedicoResult = SelecionarPorId(id);

            if (MedicoResult.IsSuccess)
                return Excluir(MedicoResult.Value);

            return Result.Fail(MedicoResult.Errors);
        }

        public Result<List<Medico>> SelecionarTodos(Guid usuarioId = new Guid())
        {
            Log.Logger.Debug("Tentando selecionar Medicos...");

            try
            {
                var Medicos = repositorioMedico.SelecionarTodos();

                Log.Logger.Information("Medicos selecionados com sucesso");

                return Result.Ok(Medicos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Medicos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Medico> SelecionarPorId(Guid id)
        {
            Log.Logger.Debug("Tentando selecionar Medico {MedicoId}...", id);

            try
            {
                var Medico = repositorioMedico.SelecionarPorId(id);

                if (Medico == null)
                {
                    Log.Logger.Warning("Medico {MedicoId} não encontrado", id);

                    return Result.Fail("Medico não encontrado");
                }

                Log.Logger.Information("Medico {MedicoId} selecionado com sucesso", id);

                return Result.Ok(Medico);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Medico";

                Log.Logger.Error(ex, msgErro + " {MedicoId}", id);

                return Result.Fail(msgErro);
            }
        }

    }
}
