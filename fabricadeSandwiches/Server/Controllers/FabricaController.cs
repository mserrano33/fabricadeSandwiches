using fabricadeSandwiches.BD.Data;
using fabricadeSandwiches.BD.Data.Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fabricadeSandwiches.Server.Controllers
{
    [ApiController]
    [Route("api/Fabrica")]
    public class FabricaController : ControllerBase
    {
        private readonly Bdcontext context;

        public FabricaController(Bdcontext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await context.Productos.Where(
                e => e.Id == id).FirstOrDefaultAsync();
            if (producto == null)
            {
                return NotFound($"No existe la especialidad de Id={id}");
            }
            return producto;
                
        }


    }
}
