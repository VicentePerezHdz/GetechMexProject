using GetechMexProjec.Interfaces;
using GetechMexProjecModels;
using Microsoft.AspNetCore.Mvc;

namespace GetechMexProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaRestServiceController : ControllerBase
    {
        readonly IFacturaRepository _facturaRepository;
        public FacturaRestServiceController(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        /*[HttpGet]
        public ActionResult<IEnumerable<Factura>> Get()
        {
            try
            {
                var facturas = _facturaRepository.ObtenerTodos();
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }*/

        [HttpGet("{id}")]
        public ActionResult<Factura> findFacturasByPersona(int id)
        {
            try
            {
                var factura = _facturaRepository.ObtenerPorId(id);

                if (factura == null)
                    return NotFound($"Factura con Id {id} no encontrada.");

                return Ok(factura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult storeFactura([FromBody] Factura nuevaFactura)
        {
            try
            {
                _facturaRepository.Agregar(nuevaFactura);
                return CreatedAtAction(nameof(findFacturasByPersona), new { id = nuevaFactura.id }, nuevaFactura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

       /* [HttpPut("{id}")]
        public ActionResult Actualizar(int id, [FromBody] Factura facturaActualizada)
        {
            try
            {
                var facturaExistente = _facturaRepository.ObtenerPorId(id);

                if (facturaExistente == null)
                    return NotFound($"Factura con Id {id} no encontrada.");

                _facturaRepository.Actualizar(facturaActualizada);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            try
            {
                var facturaExistente = _facturaRepository.ObtenerPorId(id);

                if (facturaExistente == null)
                    return NotFound($"Factura con Id {id} no encontrada.");

                _facturaRepository.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }*/
    }
}
