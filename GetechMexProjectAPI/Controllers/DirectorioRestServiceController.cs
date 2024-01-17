using GetechMexProjec.Interfaces;
using GetechMexProjecModels;
using Microsoft.AspNetCore.Mvc;

namespace GetechMexProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorioRestServiceController : ControllerBase
    {
        readonly IPersonaRepository _personRepository;
        public DirectorioRestServiceController(IPersonaRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Persona>> findPersonas()
        {
            try
            {
                var personas = _personRepository.ObtenerTodos();
                return Ok(personas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Persona> findPersonaByIdentificacion(string identificador)
        {
            try
            {
                var persona = _personRepository.ObtenerPorId(identificador);

                if (persona == null)
                    return NotFound($"Persona con Identificador {identificador} no encontrada.");

                return Ok(persona);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult storePersona([FromBody] Persona nuevaPersona)
        {
            try
            {
                _personRepository.Agregar(nuevaPersona);
                return CreatedAtAction(nameof(findPersonaByIdentificacion), new { id = nuevaPersona.id }, nuevaPersona);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult storePersona(string id, [FromBody] Persona personaActualizada)
        {
            try
            {
                var personaExistente = _personRepository.ObtenerPorId(id);

                if (personaExistente == null)
                    return NotFound($"Persona con Id {id} no encontrada.");

                _personRepository.Actualizar(personaActualizada);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult deletePersonaByIdentificacion(string id)
        {
            try
            {
                var personaExistente = _personRepository.ObtenerPorId(id);

                if (personaExistente == null)
                    return NotFound($"Persona con Id {id} no encontrada.");

                _personRepository.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
