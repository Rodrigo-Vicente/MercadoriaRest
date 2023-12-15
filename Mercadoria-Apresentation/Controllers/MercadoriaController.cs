using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercadoria_Apresentation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MercadoriaController : ControllerBase
    {
        private readonly IMercadoriaService _mercadoriaService;

        public MercadoriaController(IMercadoriaService mercadoriaService)
        {
            _mercadoriaService = mercadoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MercadoriaDTO>>> ListaMercadorias() 
        {
            var mercadorias = await _mercadoriaService.GetMercadoria();
            if (!mercadorias.Any())
            {
                return NotFound("Nenhum produto encontrado");
            }
            return Ok(mercadorias);
        }

        [HttpPost]
        public async Task<ActionResult> AddMercadoria([FromBody] MercadoriaDTO mercadoriaDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mercadoriaService.Add(mercadoriaDTO);
            return Ok(mercadoriaDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMercadoria(int id,[FromBody] MercadoriaDTO mercadoriaDTO)
        {
            if(id != mercadoriaDTO.Id)
            {
                return BadRequest("Produto incorreto");
            }
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            await _mercadoriaService.Add(mercadoriaDTO);
            return Ok(mercadoriaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMercadoria(int id)
        {
            var mercadoriaExiste = await _mercadoriaService.GetById(id);
            if (mercadoriaExiste == null)
            {
                return NotFound("Mercadoria não encontrada");
            }
            await _mercadoriaService.Remove(id);
            return Ok("Mercadoria removida");
        }
    }
}
