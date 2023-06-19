using Core.Constants;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Notificacoes;

namespace Service
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly INotificador _notificador;
        public MarcaService(IMarcaRepository marcaRepository, INotificador notificador)
        {
            _marcaRepository = marcaRepository;
            _notificador = notificador;
        }

        public async Task Adicionar(Marca marca) => await _marcaRepository.Adicionar(marca);

        public async Task<IEnumerable<Marca>> Obter() => await _marcaRepository.Obter();

        public async Task<Marca?> Obter(Guid id) => await _marcaRepository.Obter(id);

        public async Task Atualizar(Marca marca) => await _marcaRepository.Atualizar(marca);

        public async Task Remover(Guid id)
        {
            var marca = await Obter(id);

            if(marca == null)
            {
                _notificador.AdicionarNotificacao(Validacao.RegistroNaoEncontrado);
                return;
            }
            await _marcaRepository.Remover(marca);
        }
    }
}
