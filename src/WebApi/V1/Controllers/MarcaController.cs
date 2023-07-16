using AutoMapper;
using Core.Interfaces.Services;
using Core.Models;
using Core.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.ViewModels;

namespace WebApi.V1.Controllers
{
    public class MarcaController : ControllerPadrao
    {
        private readonly IMarcaService _marcaService;
        private readonly IMapper _mapper;

        public MarcaController(IMarcaService marcaService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Obter()
        {
            var marcas = await _marcaService.Obter();
            var marcasViewModel = _mapper.Map<IEnumerable<MarcaViewModel>>(marcas);
            return ObterRespostaPersonalizada(marcasViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Obter(Guid id)
        {
            var marcas = await _marcaService.Obter(id);
            var marcasViewModel = _mapper.Map<MarcaViewModel>(marcas);
            return ObterRespostaPersonalizada(marcasViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(string nome)
        {
            var marcaViewModel = new MarcaViewModel() { Nome = nome };
            var marca = _mapper.Map<Marca>(marcaViewModel);
            await _marcaService.Adicionar(marca);
            return ObterRespostaPersonalizada();
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(MarcaViewModel marcaViewModel)
        {
            var marca = _mapper.Map<Marca>(marcaViewModel);
            await _marcaService.Atualizar(marca);
            return ObterRespostaPersonalizada();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remover(Guid id)
        {
            await _marcaService.Remover(id);
            return ObterRespostaPersonalizada();
        }
    }
}
