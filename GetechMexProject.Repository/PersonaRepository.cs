using GetechMexProjec.Interfaces;
using GetechMexProjecModels;

namespace GetechMexProject.Repository
{
    public class PersonaRepository: IPersonaRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Persona ObtenerPorId(string identificador)
        {
            return _context.Personas.FirstOrDefault(p => p.identificacion == identificador);
        }
        public IEnumerable<Persona> ObtenerTodos()
        {
            return _context.Personas.ToList();
        }
        public void Agregar(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }
        public void Actualizar(Persona persona)
        {
            _context.Personas.Update(persona);
            _context.SaveChanges();
        }
        public void Eliminar(string id)
        {
            var persona = _context.Personas.FirstOrDefault(p => p.identificacion == id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
        }
    }
}
