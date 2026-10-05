using WebApplicationProjetN5.Data;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;

namespace WebApplicationProjetN5.Models.Repositories.Implementation
{
    public class ReparationRepository : IReparationRepository
    {
        private static GarageDBContext _context;

        public ReparationRepository(GarageDBContext context)
        {
            _context = context;
        }

        public IList<Reparation> GetAllReparations()
        {
            return _context.Reparations.ToList();
        }

        public void SaveReparation(Reparation Reparation)
        {
            _context.Reparations.Add(Reparation);
            _context.SaveChanges();
        }

        public Reparation? GetReparation(int id)
        {
            return _context.Reparations.Find(id);
        }

        public void DeleteReparation(int id)
        {
            var ReparationToDelete = GetReparation(id);
            if (ReparationToDelete != null)
            {
                _context.Reparations.Remove(ReparationToDelete);
                _context.SaveChanges();
            }

        }
    }
}
