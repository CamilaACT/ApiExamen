using ApiExamen.Data;
using ApiExamen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        // GET: api/<TareaController>

        public TareaController(ApplicationDBContext db)
        {
            _db=db;
        }
        // GET: api/<ColorProducto>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                List<Tarea> productos = await _db.Tareas.ToListAsync();

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            //EL CODIGO EN SQL QUE QUIERO REPRESENTAR ES:
            /*SELECT P.IdProduto, TP.Nombre, P.Nombre, P.Descripcion 
                FROM sgc_ProductoTab P
                INNER JOIN sgc_TipoProducto TP ON P.TipoProductoIdTipoProducto = TP.IdTipoProducto*/

        }

        // GET api/<ColorProducto>/5 //busca por ID
        [HttpGet("{ID}")]
        public async Task<IActionResult> Get(int ID)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                Tarea tipo = await _db.Tareas.FirstOrDefaultAsync(x => x.ID == ID);

                if (tipo == null)
                {
                    return BadRequest();
                }

                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }




        // POST api/<ColorProducto>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            Tarea proucto2 = await _db.Tareas.FirstOrDefaultAsync(x => x.Nombre.Equals(tarea.ID));
            if (proucto2 == null && tarea!=null)
            {
                var producto = new Tarea
                {
                    Nombre = tarea.Nombre,
                    Estado=tarea.Estado,
                    Tareas = tarea.Tareas
                    
                };
                await _db.Tareas.AddAsync(producto);
                await _db.SaveChangesAsync();
                return Ok(producto);
            }
            return BadRequest("El Producto ya existe");
        }

        // PUT api/<ColorProducto>/5
        [HttpPut("{ID}")]
        public async Task<IActionResult> Put(int ID, [FromBody] Tarea tarea)
        {
            Tarea actualaModificar = await _db.Tareas.FirstOrDefaultAsync(x => x.ID==ID);
            

            if (tarea != null)
            {
                actualaModificar.Nombre = tarea.Nombre != null ? tarea.Nombre : actualaModificar.Nombre;
                actualaModificar.Estado = tarea.Estado != null ? tarea.Estado : actualaModificar.Estado;
                actualaModificar.Tareas=tarea.Tareas != null ? tarea.Tareas : actualaModificar.Tareas;
                _db.Tareas.Update(actualaModificar);
                await _db.SaveChangesAsync();
                return Ok(actualaModificar);
            }
            return BadRequest("El producto ya existe");
        }

        // DELETE api/<ColorProducto>/5
        [HttpDelete("{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            Tarea prod = await _db.Tareas.FirstOrDefaultAsync(x => x.ID==ID);
            if (prod != null)
            {
                _db.Tareas.Remove(prod);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpGet("Busqueda/{Nombre},{Estado}")]
        public async Task<IActionResult> GetTalla(string Nombre,String Estado)
        {
            List<Tarea> productosColoresTallas = await _db.Tareas
                .Where(x => x.Nombre.Equals(Nombre) && x.Estado.Equals(Estado))
                .ToListAsync();

            if (productosColoresTallas == null || productosColoresTallas.Count == 0)
            {
                return NotFound(); // NotFound si no se encuentran productos con ese nombre.
            }

            return Ok(productosColoresTallas);
        }


    }
}
