using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProCiencia.Models;

namespace ServicoProCiencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicoesController : ControllerBase
    {
        private readonly ProCienciaContext _context;

        public InstituicoesController(ProCienciaContext context)
        {
            _context = context;
        }

        // GET: api/Instituicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instituicao>>> GetInstituicoes()
        {
            return await _context.Instituicao.ToListAsync();
        }

        // GET: api/Instituicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instituicao>> GetInstituicao(int id)
        {
            var instituicao = await _context.Instituicao.FindAsync(id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return instituicao;
        }

        // PUT: api/Instituicoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstituicao(int id, Instituicao instituicao)
        {
            if (id != instituicao.InstituicaoId)
            {
                return BadRequest();
            }

            _context.Entry(instituicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstituicaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Instituicoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Instituicao>> PostInstituicao(Instituicao instituicao)
        {
            _context.Instituicao.Add(instituicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstituicao", new { id = instituicao.InstituicaoId }, instituicao);
        }

        // DELETE: api/Instituicoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Instituicao>> DeleteInstituicao(int id)
        {
            var instituicao = await _context.Instituicao.FindAsync(id);
            if (instituicao == null)
            {
                return NotFound();
            }

            _context.Instituicao.Remove(instituicao);
            await _context.SaveChangesAsync();

            return instituicao;
        }

        private bool InstituicaoExists(int id)
        {
            return _context.Instituicao.Any(e => e.InstituicaoId == id);
        }
    }
}
