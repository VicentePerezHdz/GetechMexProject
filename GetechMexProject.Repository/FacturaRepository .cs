using GetechMexProjec.Interfaces;
using GetechMexProjecModels;

namespace GetechMexProject.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ApplicationDbContext _context;
        public FacturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Factura ObtenerPorId(int id)
        {
            return _context.Facturas.FirstOrDefault(f => f.id == id);
        }
        public IEnumerable<Factura> ObtenerTodos()
        {
            return _context.Facturas.ToList();
        }
        public void Agregar(Factura factura)
        {
            _context.Facturas.Add(factura);
            _context.SaveChanges();
        }
        public void Actualizar(Factura factura)
        {
            _context.Facturas.Update(factura);
            _context.SaveChanges();
        }
        public void Eliminar(int id)
        {
            var factura = _context.Facturas.FirstOrDefault(f => f.id == id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
                _context.SaveChanges();
            }
        }
    }
}
