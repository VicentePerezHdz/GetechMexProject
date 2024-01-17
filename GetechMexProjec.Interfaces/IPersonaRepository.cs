using GetechMexProjecModels;

namespace GetechMexProjec.Interfaces
{
    public interface IPersonaRepository
    {
        Persona ObtenerPorId(string identificador);
        IEnumerable<Persona> ObtenerTodos();
        void Agregar(Persona persona);
        void Actualizar(Persona persona);
        void Eliminar(string id);
    }
}
