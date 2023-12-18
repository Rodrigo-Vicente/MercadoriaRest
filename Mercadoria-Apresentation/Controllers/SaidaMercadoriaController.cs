using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercadoria_Apresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaidaMercadoriaController : ControllerBase
    {
        private readonly ISaidaMercadoriaService _saidaMercadoriaService;
        private readonly IEntradaMercadoriaService _entradaMercadoriaService;

        public SaidaMercadoriaController(ISaidaMercadoriaService saidaMercadoriaService, IEntradaMercadoriaService entradaMercadoriaService)
        {
            _saidaMercadoriaService = saidaMercadoriaService;
            _entradaMercadoriaService = entradaMercadoriaService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SaidaMercadoriaDTO>>> ListaSaidasMercadorias()
        {
            var saidas = await _saidaMercadoriaService.GetSaidas();
            if (!saidas.Any())
            {
                return NotFound("Nenhuma entrada encontrada");
            }
            return Ok(saidas);
        }

        [HttpPost]
        public async Task<ActionResult> AddSaidaMercadoria([FromBody] SaidaMercadoriaDTO saidaMercadoriaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var todasEntradasPorMercadoria = await _entradaMercadoriaService.GetByMercadoriaId(saidaMercadoriaDTO.MercadoriaId);
            var quantidadeEntradaTotal = todasEntradasPorMercadoria.Select(x=>x.QuantidadeEntrada).Sum();

            var todasSaidasPorMercadoria = await _saidaMercadoriaService.GetByMercadoriaId(saidaMercadoriaDTO.MercadoriaId);
            var quantidadeSaidaTotal = (todasSaidasPorMercadoria.Select(x => x.QuantidadeRetirada).Sum()) + saidaMercadoriaDTO.QuantidadeRetirada;

            // Valida se a quantidade total de entrada é menor que a quantidade de saidas já cadastradas mais a nova saida
            if (quantidadeEntradaTotal < quantidadeSaidaTotal)
            {
                return BadRequest("Quantidade informada não pode ser superior ao total de entradas");
            }

            await _saidaMercadoriaService.Add(saidaMercadoriaDTO);
            return Ok(saidaMercadoriaDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSaidaMercadoria(int id, [FromBody] SaidaMercadoriaDTO saidaMercadoriaDTO)
        {
            if (id != saidaMercadoriaDTO.id)
            {
                return BadRequest("Produto incorreto");
            }
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            await _saidaMercadoriaService.Add(saidaMercadoriaDTO);
            return Ok(saidaMercadoriaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSaidaMercadoria(int id)
        {
            var saidaExiste = await _saidaMercadoriaService.GetById(id);
            if (saidaExiste == null)
            {
                return NotFound("Mercadoria não encontrada");
            }
            await _saidaMercadoriaService.Remove(id);
            return Ok("Mercadoria removida");
        }
    }
}
