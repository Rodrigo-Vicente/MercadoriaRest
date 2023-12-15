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

        public SaidaMercadoriaController(ISaidaMercadoriaService saidaMercadoriaService)
        {
            _saidaMercadoriaService = saidaMercadoriaService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaidaMercadoriaDTO>>> ListaEntradasMercadorias()
        {
            var saidas = await _saidaMercadoriaService.GetSaidas();
            if (!saidas.Any())
            {
                return NotFound("Nenhuma entrada encontrada");
            }
            return Ok(saidas);
        }

        [HttpPost]
        public async Task<ActionResult> AddEntradaMercadoria([FromBody] SaidaMercadoriaDTO saidaMercadoriaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _saidaMercadoriaService.Add(saidaMercadoriaDTO);
            return Ok(saidaMercadoriaDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEntradaMercadoria(int id, [FromBody] SaidaMercadoriaDTO saidaMercadoriaDTO)
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
        public async Task<ActionResult> DeleteMercadoria(int id)
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
