using WebApplicationProjetN5.Models.Entities;

namespace WebApplicationProjetN5.Models.Services.Interfaces
{
    public interface IReparationService
    {
        public IList<Reparation> GetAllReparations();
        void SaveReparation(Reparation Reparation);

        void DeleteReparation(int id);

        int GetReparationId(Reparation Reparation);
    }
}
