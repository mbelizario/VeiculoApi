using Core.Notificacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ControllerPadrao : ControllerBase
    {
        private readonly INotificador _notificador;
        public ControllerPadrao(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected ActionResult ObterRespostaPersonalizada(object? resultado = null)
        {
            if(_notificador.ExisteNotificacoes())
            {
                return BadRequest(new
                {
                    sucesso = false,
                    dados = _notificador.ObterNotificacoes()
                });
            }

            return Ok(new
            {
                sucesso = true,
                dados = resultado
            });
        }

        protected ActionResult ObterRespostaPersonalizada(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) ObterNotificacoes(modelState);
            return ObterRespostaPersonalizada();
        }

        private void ObterNotificacoes(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var mensagem = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                _notificador.AdicionarNotificacao(mensagem);
            }
        }
    }
}
