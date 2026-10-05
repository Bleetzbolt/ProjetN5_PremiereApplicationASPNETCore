using WebApplicationProjetN5.Models.Entities;

namespace WebApplicationProjetN5.Models.Repositories.Interfaces
{
    public interface IReparationRepository
    {
        public IList<Reparation> GetAllReparations();
        void SaveReparation(Reparation Reparation);
        Reparation? GetReparation(int id);
        void DeleteReparation(int id);
    }
}
