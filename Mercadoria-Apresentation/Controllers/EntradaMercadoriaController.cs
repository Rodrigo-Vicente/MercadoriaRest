using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercadoria_Apresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EntradaMercadoriaController : ControllerBase
    {
        private readonly IEntradaMercadoriaService _entradaMercadoriaService;

        public EntradaMercadoriaController(IEntradaMercadoriaService entradaMercadoriaService)
        {
            _entradaMercadoriaService = entradaMercadoriaService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntradaMercadoriaDTO>>> ListaEntradasMercadorias()
        {
            var entradas = await _entradaMercadoriaService.GetEntradas();
            if (!entradas.Any())
            {
                return NotFound("Nenhuma entrada encontrada");
            }
            return Ok(entradas);
        }

        [HttpPost]
        public async Task<ActionResult> AddEntradaMercadoria([FromBody] EntradaMercadoriaDTO entradaMercadoriaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _entradaMercadoriaService.Add(entradaMercadoriaDTO);
            return Ok(entradaMercadoriaDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEntradaMercadoria(int id, [FromBody] EntradaMercadoriaDTO entradaMercadoriaDTO)
        {
            if (id != entradaMercadoriaDTO.id)
            {
                return BadRequest("Produto incorreto");
            }
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            await _entradaMercadoriaService.Add(entradaMercadoriaDTO);
            return Ok(entradaMercadoriaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMercadoria(int id)
        {
            var entradaExiste = await _entradaMercadoriaService.GetById(id);
            if (entradaExiste == null)
            {
                return NotFound("Mercadoria não encontrada");
            }
            await _entradaMercadoriaService.Remove(id);
            return Ok("Mercadoria removida");
        }
    }
}
